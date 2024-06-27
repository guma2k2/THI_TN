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
    public partial class frmTaiKhoanXoa2 : DevExpress.XtraEditors.XtraForm
    {
        public frmTaiKhoanXoa2()
        {
            InitializeComponent();
        }

        private void cbxHoTen_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxHoTen.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
            txtMANV.Text = cbxHoTen.SelectedValue.ToString();
            txtMatKhau.Text = "123456";
            txtXacNhanMK.Text = "123456";
            txtTaiKhoan.Text = getTaiKhoanByUsername();
            loadRoleByUsername();
        }

        private void loadRoleByUsername()
        {
            string sql = "EXEC dbo.[SP_TAIKHOAN_GET_ROLE] '" + txtMANV.Text.ToString() + "'";
            Program.myReader = Program.ExecSqlDataReader(sql);
            if (Program.myReader == null)
            {
                throw new Exception("Class not found");
            }
            Program.myReader.Read();
            string role = Program.myReader.GetString(0);
            Console.WriteLine(role);
            Program.myReader.Close();
            if (role == "CoSo")
            {
                rbCoSo.Checked = true;
            }
            else if (role == "Truong")
            {
                rbTruong.Checked = true;
            }
            else
            {
                rbGiaoVien.Checked = true;
            }
        }

        private string getTaiKhoanByUsername()
        {
            string sql = "EXEC dbo.[SP_TAIKHOAN_GETLOGIN_BY_USERNAME] '" + txtMANV.Text.ToString() + "'";
            Program.myReader = Program.ExecSqlDataReader(sql);
            if (Program.myReader == null)
            {
                throw new Exception("Class not found");
            }
            Program.myReader.Read();
            string login = Program.myReader.GetString(0);
            Program.myReader.Close();
            return login;
        }

        private void frmTaiKhoanXoa2_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string cmd = "EXEC [dbo].[SP_TAIKHOAN_DS_GV_COTK]";
            dt = Program.ExecSqlQuery(cmd);

            BindingSource bdsGv = new BindingSource();
            bdsGv.DataSource = dt;
            cbxHoTen.DataSource = bdsGv;
            cbxHoTen.DisplayMember = "HOTEN";
            cbxHoTen.ValueMember = "MAGV";
            rgVaiTro.Enabled = txtTaiKhoan.Enabled = txtMANV.Enabled = txtMatKhau.Enabled = txtXacNhanMK.Enabled= false;
            if (cbxHoTen.SelectedValue != null)
            {
                txtMANV.Text = cbxHoTen.SelectedValue.ToString();
                txtMatKhau.Text = "123456";
                txtXacNhanMK.Text = "123456";
                txtTaiKhoan.Text = getTaiKhoanByUsername();
                loadRoleByUsername();
            }
        }

        private void btnXoaTK_Click_1(object sender, EventArgs e)
        {
            String queryXoaTaiKhoan = "DECLARE @return_value int \n" +
                "EXEC @return_value = [dbo].[SP_TAIKHOAN_DELETE] \n " +
                "@loginname = N'" + txtTaiKhoan.Text.Trim() + "', \n " +
                "@username = N'" + txtMANV.Text.Trim() + "'\n " +
                "SELECT 'Return Value' = @return_value";
            Console.WriteLine(queryXoaTaiKhoan);
            if (MessageBox.Show("Bạn có thật sự muốn xóa tài khoản này không?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    int resultMa = Program.CheckDataHelper(queryXoaTaiKhoan);
                    if (resultMa == 0)
                    {
                        XtraMessageBox.Show("Xóa tài khoản thành công", "", MessageBoxButtons.OK);
                        frmTaiKhoanXoa2_Load(sender, e);
                    }
                }
                catch (SqlException ex)
                {
                    XtraMessageBox.Show(ex.Message, "", MessageBoxButtons.OK);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}