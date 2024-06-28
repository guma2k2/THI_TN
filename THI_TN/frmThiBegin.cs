using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask.Design;
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

namespace THI_TN
{
    public partial class frmThiBegin : DevExpress.XtraEditors.XtraForm
    {
        public frmThiBegin()
        {
            InitializeComponent();
        }
        private int soCauThi;
        private int thoiGian; // minutes;
        private string trinhDo;
        private List<Question> questions = new List<Question>();
        private SqlConnection conn_publisher = new SqlConnection();
        private int lanthi = 0;
        private void frmThiBegin_Load(object sender, EventArgs e)
        {
            txtHoten.Text = Program.mHoten.ToString(); 
            string malop = loadInfoClass();
            loadInfoMonHocByLop(malop);
            cbxMonhoc.SelectedIndex = 0;
        }

        private void loadInfoMonHocByLop(string malop)
        {
            if (KetNoi_CSDLGOC() == 0) return;
            String dateNow = DateTime.Now.ToString();
            Console.WriteLine(dateNow);
            string sql = "EXEC dbo.SP_THI_GET_MONHOC '" + Program.username + "', '" + malop + "'" ;
            DataTable dt = new DataTable();
            if (conn_publisher.State == ConnectionState.Closed)
            {
                conn_publisher.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(sql, conn_publisher);
            da.Fill(dt);
            conn_publisher.Close();
            cbxMonhoc.DataSource = dt;
            cbxMonhoc.DisplayMember = "TENMH";
            cbxMonhoc.ValueMember = "MAMH";

            Console.WriteLine(cbxMonhoc.SelectedValue.ToString());
            if (cbxMonhoc.SelectedValue != null)
            {
                string mamh = cbxMonhoc.SelectedValue.ToString();
                groupThi.Visible = true;
                loadLanThiAndNgayThi(txtMalop.Text.ToString(), mamh);
                btnThi.Enabled = true;
            }
            else
            {
                groupThi.Visible = false;
                btnThi.Enabled = false;
            }
        }

        private void loadLanThiAndNgayThi(string malop, string mamh)
        {
            if (Program.KetNoi() == 0) return;
            string sql = "EXEC dbo.[SP_THI_GET_LAN_NGAYTHI] '" + malop + "', '" + mamh + "'";
            Program.myReader = Program.ExecSqlDataReader(sql);

            if (Program.myReader.Read())
            {
                string socauthiFormat = "Số câu thi: ";
                string thoigianFormat = "Thời gian thi: ";
                string trinhDoFormat = "Trình độ: ";
                Console.WriteLine(Program.myReader.GetInt16(0).ToString());
                txtLan.Text = Program.myReader.GetInt16(0).ToString();
                txtNgaythi.DateTime = Program.myReader.GetDateTime(1);
                socauthiFormat = socauthiFormat + Program.myReader.GetInt16(2).ToString();
                thoigianFormat = thoigianFormat + Program.myReader.GetInt16(3).ToString();
                trinhDoFormat = trinhDoFormat + Program.myReader.GetString(4);

                lbSoCauThi.Text = socauthiFormat;
                lbThoiGian.Text = thoigianFormat;
                lbTrinhDo.Text = trinhDoFormat;

                soCauThi = Program.myReader.GetInt16(2);
                trinhDo = Program.myReader.GetString(4);
                thoiGian = Program.myReader.GetInt16(3);
                lanthi = Program.myReader.GetInt16(0);
            }
        }
        private int KetNoi_CSDLGOC()
        {
            if (conn_publisher != null && conn_publisher.State == ConnectionState.Open)
            {
                conn_publisher.Close();
            }
            try
            {
                conn_publisher.ConnectionString = Program.constr_publisher;
                conn_publisher.Open();
                return 1;
            }
            catch
            {
                MessageBox.Show("Loi ket noi");
                return 0;

            }
        }

        private string loadInfoClass()
        {
            if (Program.KetNoi() == 0) return "";
            string masv = Program.username;
            string sql = "EXEC dbo.SP_THI_GET_LOPHOC_BY_SV '" + masv + "'";
            Program.myReader = Program.ExecSqlDataReader(sql);
            if (Program.myReader == null)
            {
                throw new Exception("Class not found");
            }
            Program.myReader.Read();
            string malop = Program.myReader.GetString(0);
            txtMalop.Text = malop;
            txtTenlop.Text = Program.myReader.GetString(1);
            Program.myReader.Close();
            return malop;
        }
        

        private void btnThi_Click(object sender, EventArgs e)
        {
            string mamh = cbxMonhoc.SelectedValue.ToString();
            string tenmh = cbxMonhoc.Text.ToString();
            string sqlGetDethi = "EXEC dbo.SP_THI_GET_QUESTION '" + mamh + "', '" + trinhDo + "', '" + soCauThi + "' ";
            if (Program.KetNoi() == 0) return;
            Program.myReader = Program.ExecSqlDataReader(sqlGetDethi);
            if (Program.myReader == null)
            {
                throw new Exception("Class not found");
            }

            while (Program.myReader.Read())
            {
                Question question = new Question();
                int cauhoi = Program.myReader.GetInt32(0);
                string noiDung = Program.myReader.GetString(1);
                string A = Program.myReader.GetString(2);
                string B = Program.myReader.GetString(3);
                string C = Program.myReader.GetString(4);
                string D = Program.myReader.GetString(5);
                string dapAn = Program.myReader.GetString(6);
                question.cauHoi = cauhoi;
                question.noidung = noiDung;
                question.a = A;
                question.b = B;
                question.c = C;
                question.d = D;
                question.dapan = dapAn;
                question.daChon = "";
                questions.Add(question);
            }
            BangDiem bangDiem = new BangDiem();
            bangDiem.mamh = mamh;
            bangDiem.lan = lanthi;
            bangDiem.ngayThi = txtNgaythi.DateTime;
            bangDiem.diem = 0;


            Form frm = this.CheckExistForm(typeof(frmThiDoing));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmThiDoing f = new frmThiDoing(questions, soCauThi, thoiGian, tenmh, bangDiem);
                this.Close();
                f.Show();
            }
        }

        private Form CheckExistForm(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }
            return null;
        }


        private void cbxMonhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMonhoc.SelectedValue != null)
            {
                string mamh = cbxMonhoc.SelectedValue.ToString();
                groupThi.Visible = true;
                loadLanThiAndNgayThi(txtMalop.Text.ToString(), mamh);
                btnThi.Enabled = true;
            }
            else
            {
                groupThi.Visible = false;
                btnThi.Enabled = false;
            }
        }

        private void txtLan_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtNgaythi_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtHoten_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTenlop_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtMalop_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
    }
}