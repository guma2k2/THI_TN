using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;

namespace THI_TN
{
    public partial class frmThiDoing : DevExpress.XtraEditors.XtraForm
    {

        private int soCauThi, thoigianthi, totalSeconds;
        private string tenmh;
        private int currenIndexQuestionSelected = 0;
        private List<Question> questions = new List<Question>();
        private BangDiem bangDiem = new BangDiem();
        private static SqlConnection conn = new SqlConnection();
        private float diemThi = 0f;
        public frmThiDoing(List<Question> questions, int soCauThi, int thoiGianThi, string tenmh, BangDiem bangDiem)
        {
            InitializeComponent();
            this.questions = questions;
            this.soCauThi = soCauThi;
            this.thoigianthi = thoiGianThi;
            this.tenmh = tenmh;
            this.totalSeconds = 0;
            this.bangDiem = bangDiem;
            this.ControlBox = false;
        }
        

        private void lb_index_Click(object sender, EventArgs e)
        {

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currenIndexQuestionSelected == 0)
            {
                return;
            } else
            {
                --currenIndexQuestionSelected;
                setQuestion();
            }
        }

        private void frmTracNghiem_Load(object sender, EventArgs e)
        {
            setQuestion();
            timerThi.Tick += Timer_Tick;
            totalSeconds = thoigianthi * 60;
            timerThi.Start();
            rb_a.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rb_b.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rb_c.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rb_d.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);   
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currenIndexQuestionSelected  == soCauThi -1)
            {
                return;
            }
            else
            {
                ++currenIndexQuestionSelected;
                setQuestion();
            }
        }

        private void setQuestion ()
        {
            lb_index.Text = (currenIndexQuestionSelected + 1).ToString();
            lb_question.Text = questions[currenIndexQuestionSelected].noidung;
            Question currentQuestion = questions[currenIndexQuestionSelected];
            rb_a.Text = currentQuestion.a;
            rb_b.Text = currentQuestion.b;
            rb_c.Text = currentQuestion.c;
            rb_d.Text = currentQuestion.d;

           if (currentQuestion.daChon != "")
            {
                Console.WriteLine(currentQuestion.daChon);
                rb_a.Checked = currentQuestion.daChon == "A";
                rb_b.Checked = currentQuestion.daChon == "B";
                rb_c.Checked = currentQuestion.daChon == "C";
                rb_d.Checked = currentQuestion.daChon == "D";
            } else
            {
                rb_a.Checked = false;
                rb_b.Checked = false;
                rb_c.Checked = false;
                rb_d.Checked = false;
            }

        }


        private string FormatMinutes(int totalMinutes)
        {
            // Calculate hours and minutes
            int minutes = totalMinutes / 60;
            int seconds = totalMinutes % 60;

            // Format the time string
            string formattedTime = $"{minutes:D2}:{seconds:D2}";
            return formattedTime;
        }

        private void radioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                if (((RadioButton)sender) == rb_a)
                {
                    updateQuestion("A");

                }
                else if (((RadioButton)sender) == rb_b)
                {
                    updateQuestion("B");
                } else if (((RadioButton)sender) == rb_c)
                {
                    updateQuestion("C");

                }
                else if (((RadioButton)sender) == rb_d)
                {
                    updateQuestion("D");
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            totalSeconds--;
            lb_timer.Text = FormatMinutes(totalSeconds);

            // Check if countdown reaches zero
            if (totalSeconds <= 0)
            {
                timerThi.Stop(); // Stop the timer when countdown reaches zero
                MessageBox.Show("Countdown finished!");
            }
        }

        private void updateQuestion(string daChon)
        {
            // Find the item with the specified id
            Question itemToUpdate = questions[currenIndexQuestionSelected];

            // Update the item if found
            if (itemToUpdate != null)
            {
                itemToUpdate.daChon = daChon;
            }
            else
            {
                Console.WriteLine($"Item with Id  not found.");
            }
        }

        private void btnNopBai_Click(object sender, EventArgs e)
        {
            timerThi.Stop();
            calculateMark();
            Console.WriteLine(diemThi.ToString());
            ResultExam result = new ResultExam();
            result.lan = bangDiem.lan;
            result.tenMh = tenmh;
            result.diem = diemThi;
            result.ngayThi = bangDiem.ngayThi;
            if (Program.mGroup == "GV")
            {
                frmThiResult frm = new frmThiResult(result);
                
                frm.Show();

                return;
            } 
            DataTable ctBaiThiTable = createDataTableCtBaiThi();
            saveBangDiem(ctBaiThiTable);
            frmThiResult f = new frmThiResult(result);
            f.Show();
            this.Close();
        }

        private DataTable createDataTableCtBaiThi()
        {
            DataTable target = new DataTable();
            target.Columns.Add("CAUHOI", typeof(int));
            target.Columns.Add("DACHON", typeof(string));
            target.Columns.Add("CAUSO", typeof(int));
            for(int i = 0; i < questions.Count; i++) 
            {
                Question q = questions[i];
                target.Rows.Add(q.cauHoi, q.daChon, i+1);
            }
            return target;
        }

        private void calculateMark()
        {
            int count = 0;
           foreach(Question q in questions)
            {
                if (q.dapan == q.daChon)
                {
                    count++;
                }
            }
            // socauthi : 10
            // count : ?
            float resnewMarkult = 10f * count / soCauThi;
            diemThi = (float)Math.Round(resnewMarkult, 1);

        }

        private void saveBangDiem(DataTable ctBaiThiTable)
        {
            String connectionstring = Program.connstr;
            conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("SP_THI_SAVE_CT_BAITHI", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ctbaithi_table", ctBaiThiTable);
            cmd.Parameters.AddWithValue("@masv", Program.username);
            cmd.Parameters.AddWithValue("@mamh", bangDiem.mamh);
            cmd.Parameters.AddWithValue("@lan", bangDiem.lan);
            cmd.Parameters.AddWithValue("@ngaythi", bangDiem.ngayThi);
            cmd.Parameters.AddWithValue("@diem", diemThi);
            Console.WriteLine(diemThi.ToString());
            conn.Open();
            int rowAffected = 0;
            try
            {
                rowAffected = cmd.ExecuteNonQuery();
            } catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            conn.Close();
        }

        private void rb_a_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rb_b_CheckedChanged(object sender, EventArgs e)
        {
        }

       

        private void rb_c_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rb_d_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}