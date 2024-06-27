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

namespace THI_TN
{
    public partial class frmBeginThiThu : DevExpress.XtraEditors.XtraForm
    {
        public frmBeginThiThu()
        {
            InitializeComponent();
        }
        private SqlConnection conn_publisher = new SqlConnection();
        private int soCauThi;
        private int thoiGian; // minutes;
        private string trinhDo;
        private List<Question> questions = new List<Question>();


        private int lanthi = 0;

        private void btnThi_Click(object sender, EventArgs e)
        {
            string malop = cbxLop.Text.ToString().Trim();
            string mamh = cbxMonHoc.SelectedValue.ToString();
            string tenmh = cbxMonHoc.Text.ToString();
            Console.WriteLine(mamh);
            Console.WriteLine(tenmh);
            string lanthi = txtLan.Text.ToString();

            string sql = "EXEC dbo.SP_THI_GET_GVDK '" + malop + "', '" + mamh + "', '" + lanthi + "' ";
            Program.myReader = Program.ExecSqlDataReader(sql);
            if (Program.myReader == null)
            {
                throw new Exception("Class not found");
            }
            Program.myReader.Read();
            if (Program.myReader.HasRows)
            {
                soCauThi = Program.myReader.GetInt16(0);
                thoiGian = Program.myReader.GetInt16(1);
                trinhDo = Program.myReader.GetString(2);
            }
            else
            {
                MessageBox.Show("Lớp chưa được đăng kí thi");
                return;
            }
            Program.myReader.Close();
            Console.WriteLine(soCauThi);
            Console.WriteLine(thoiGian);
            Console.WriteLine(trinhDo);

            string sqlGetDethi = "EXEC dbo.SP_THI_GET_QUESTION '" + mamh + "', '" + trinhDo + "', '" + soCauThi + "' ";

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
            bangDiem.lan = int.Parse(lanthi);
            bangDiem.ngayThi = txtNgaythi.DateTime;
            bangDiem.diem = 0;

            frmThiDoing f = new frmThiDoing(questions, soCauThi, thoiGian, tenmh, bangDiem);
            f.Show();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLop.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmBeginThiThu_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.LOPTableAdapter.Fill(this.DS.LOP);
            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;


            cbxCoSo.DataSource = Program.bds_dspm;
            cbxCoSo.DisplayMember = "TENCOSO";
            cbxCoSo.ValueMember = "TENSERVER";
            cbxCoSo.SelectedIndex = Program.mChiNhanh;

            cbxLop.DataSource = bdsLop;
            cbxLop.DisplayMember = "TENLOP";
            cbxLop.ValueMember = "MALOP";

            if (cbxLop.SelectedValue != null)
            {
                string malop = cbxLop.SelectedValue.ToString();
                txtMalop.Text = malop;
                loadInfoMonHocByLop(malop);
            }

            if (Program.mGroup == "CoSo")
            {
                cbxCoSo.Enabled = false;
            }else if (Program.mGroup == "GV")
            {
                cbxCoSo.Enabled = true;
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

        private void loadInfoMonHocByLop(string malop)
        {
            if (KetNoi_CSDLGOC() == 0) return;
            String dateNow = DateTime.Now.ToString();
            Console.WriteLine(dateNow);
            string sql = "EXEC dbo.SP_THI_GET_MONHOC '" + Program.username + "', '" + malop + "'";
            DataTable dt = new DataTable();
            if (conn_publisher.State == ConnectionState.Closed)
            {
                conn_publisher.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(sql, conn_publisher);
            da.Fill(dt);
            conn_publisher.Close();
            cbxMonHoc.DataSource = dt;
            cbxMonHoc.DisplayMember = "TENMH";
            cbxMonHoc.ValueMember = "MAMH";

            if (cbxMonHoc.SelectedValue != null)
            {
                string mamh = cbxMonHoc.SelectedValue.ToString();
                loadLanThiAndNgayThi(malop, mamh);
                btnThi.Enabled = true;
            }
            else
            {
                btnThi.Enabled = false;
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


        private void cbxLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLop.SelectedValue != null)
            {
                string malop = cbxLop.SelectedValue.ToString();
                txtMalop.Text = malop;
                loadInfoMonHocByLop(malop);
            }
        }

        private void cbxCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCoSo.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }

            Program.servername = cbxCoSo.SelectedValue.ToString();
            if (cbxCoSo.SelectedIndex != Program.mChiNhanh)
            {
                Program.mlogin = Program.remoteLogin;
                Program.password = Program.remotePassowrd;
            }
            else
            {
                Program.mlogin = Program.mLoginDN;
                Program.password = Program.passwordDN;

            }

            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối cơ sở mới", "", MessageBoxButtons.OK);
            }
            else
            {
                this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPTableAdapter.Fill(this.DS.LOP);
            }
        }

        private void cbxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMonHoc.SelectedValue != null)
            {
                string mamh = cbxMonHoc.SelectedValue.ToString();
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
    }
}