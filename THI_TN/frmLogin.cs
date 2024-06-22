using DevExpress.XtraEditors;
using DevExpress.XtraWaitForm;
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
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection conn_publisher = new SqlConnection();
        private bool isSinhVien = false;
        public frmLogin()
        {
            InitializeComponent();
        }
        public void LayDSPM(String cmd)
        {
            DataTable dt = new DataTable();
            if (conn_publisher.State == ConnectionState.Closed)
            {
                conn_publisher.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn_publisher);
            da.Fill(dt);
            conn_publisher.Close();
            Program.bds_dspm.DataSource = dt;
            cbChiNhanh.DataSource = Program.bds_dspm;
            cbChiNhanh.DisplayMember = "TENCOSO";
            cbChiNhanh.ValueMember = "TENSERVER";
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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() == "" || txtMK.Text.Trim() == "")
            {
                MessageBox.Show("Login name va mat khau ko dc bo trong", "", MessageBoxButtons.OK);
                return;
            }


            if (isSinhVien == true)
            {
                Program.mlogin = "SVKN";
                Program.password = "123456";
                if (Program.KetNoi() == 0) return;
                string sql2 = "EXEC dbo.SP_Lay_Thong_Tin_SV_DangNhap '" + txtLogin.Text + "', '" + txtMK.Text + "'";
                Program.myReader = Program.ExecSqlDataReader(sql2);
                if (Program.myReader == null)
                {
                    return;
                }
                Program.myReader.Read();
                if (Program.myReader.HasRows == false)
                {
                    MessageBox.Show("DN THAT BAI MA SINH VIEN KHONG TON TAI HOAC MAT KHAU KHONG CHINH XAC");
                    return;
                }
                try
                {
                    Program.mHoten = Program.myReader.GetString(1);
                    Program.username = Program.myReader.GetString(0);
                    Program.mGroup = "Sinhvien";
                    Program.myReader.Close();
                }
                catch (Exception) { }
                Program.conn.Close();
            }
            else
            {
                Program.mlogin = txtLogin.Text;
                Program.password = txtMK.Text;
                if (Program.KetNoi() == 0) return;

                Program.mChiNhanh = cbChiNhanh.SelectedIndex;
                Program.mLoginDN = Program.mlogin;
                Program.passwordDN = Program.password;
                string sql = "EXEC dbo.SP_Lay_Thong_Tin_GV_Tu_Login '" + Program.mlogin + "'";
                Program.myReader = Program.ExecSqlDataReader(sql);
                if (Program.myReader == null)
                {
                    return;
                }
                Program.myReader.Read();
                Program.mGroup = Program.myReader.GetString(2);
                Program.mHoten = Program.myReader.GetString(1);
                Program.username = Program.myReader.GetString(0);
                Program.myReader.Close();


            }

            MessageBox.Show("Dang nhap thanh cong");

            /*if (Program.mGroup != "PKT")
            {
                LayDSPM("SELECT * FROM [dbo].[GET_Subscribes]");
            }*/
            Form f = new frmMain();
            f.ShowDialog();
        }




        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = cbChiNhanh.SelectedValue.ToString();
            }
            catch (Exception)
            { }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (KetNoi_CSDLGOC() == 0) return;
            LayDSPM("SELECT * FROM [dbo].[GET_Subscribes]");
            cbChiNhanh.SelectedIndex = 1;
            cbChiNhanh.SelectedIndex = 0;
        }

        private void cbSinhVien_CheckedChanged(object sender, EventArgs e)
        {
            isSinhVien = !isSinhVien;
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            Close();
            Program.mainForm.Close();
        }
    }
}