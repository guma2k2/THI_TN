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
        private SqlConnection conn_publisher = new SqlConnection();
        private int soCauThi;
        private int thoiGian; // minutes;
        private string trinhDo;
        private List<Question> questions = new List<Question>();
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
            string sql = "EXEC dbo.SP_THI_GET_MONHOC_BY_LOP '" + malop + "', '" + dateNow + "'";
            DataTable dt = new DataTable();
            if (conn_publisher.State == ConnectionState.Closed)
            {
                conn_publisher.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(sql, conn_publisher);
            da.Fill(dt);
            conn_publisher.Close();
            cbxMonhoc.DataSource = dt;
            cbxMonhoc.DisplayMember = "TENMONHOC";
            cbxMonhoc.ValueMember = "MAMH";
            string mamh = cbxMonhoc.SelectedValue.ToString();

            loadLanThiByLopAndMonHoc(malop, mamh);

            int lan = int.Parse(cbxMonhoc.SelectedValue.ToString());
            loadNgayThiByLopAndMonHocAndLan(malop, mamh, lan);
        }



        private void loadNgayThiByLopAndMonHocAndLan(string malop, string mamh, int lan)
        {
            if (KetNoi_CSDLGOC() == 0) return;
            String dateNow = DateTime.Now.ToString();
            string sql = "EXEC dbo.SP_THI_GET_ALL_LAN '" + malop + "', '" + mamh + "', '" + lan;
            if (conn_publisher.State == ConnectionState.Closed)
            {
                conn_publisher.Open();
            }
            Program.myReader = Program.ExecSqlDataReader(sql);

            if (Program.myReader.Read())
            {
                txtNgaythi.DateTime = Program.myReader.GetDateTime(0);
            }
        }
        private void loadLanThiByLopAndMonHoc(string malop, string mamh)
        {
            if (KetNoi_CSDLGOC() == 0) return;
            String dateNow = DateTime.Now.ToString();
            string sql = "EXEC dbo.SP_THI_GET_ALL_LAN '" + malop + "', '" + mamh + "'";
            DataTable dt = new DataTable();
            if (conn_publisher.State == ConnectionState.Closed)
            {
                conn_publisher.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(sql, conn_publisher);
            da.Fill(dt);
            conn_publisher.Close();
            cbxMonhoc.DataSource = dt;
            cbxMonhoc.DisplayMember = "LAN";
            cbxMonhoc.ValueMember = "LAN";
        }

        private string loadInfoClass()
        {

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

        private void btnThi_Click(object sender, EventArgs e)
        {
            // get gvdk by mamh malop lan 
            string malop = txtMalop.Text.ToString().Trim();
            string mamh = cbxMonhoc.SelectedValue.ToString();
            string tenmh = cbxMonhoc.Text.ToString();
            Console.WriteLine(mamh);
            Console.WriteLine(tenmh);
            string lanthi = txtLan.Text.ToString() ;

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
            } else
            {
                MessageBox.Show("Lop chua duoc dang ky thi");
                return;
            }
            Program.myReader.Close();
            Console.WriteLine(soCauThi);
            Console.WriteLine(thoiGian);
            Console.WriteLine(trinhDo);
            // lay de thi 

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
            // go to next page

            frmThiDoing f = new frmThiDoing(questions, soCauThi, thoiGian, tenmh, bangDiem);
            f.Show();
        }

       
        private void cbxMonhoc_SelectedIndexChanged(object sender, EventArgs e)
        {

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