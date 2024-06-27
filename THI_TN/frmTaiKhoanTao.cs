using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THI_TN
{
    public partial class frmTaiKhoanTao : DevExpress.XtraEditors.XtraForm
    {
        public frmTaiKhoanTao()
        {
            InitializeComponent();
        }

        private string role = "";

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmTaiKhoanTao_Load(object sender, EventArgs e)
        {
            loadCbxHoTen();
            if (cbxHoTen.SelectedValue != null)
            {
                txtUsername.Text = cbxHoTen.SelectedValue.ToString();
                rbTruong.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
                rbCoSo.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
                rbGiaoVien.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            }else
            {
                txtUsername.Text = txtLogin.Text = "";
                txtMatKhau.Text = txtXacNhanMK.Text = "";
            }
            if (Program.mGroup == "CoSo")
            {
                rbCoSo.Enabled = true;
                rbGiaoVien.Enabled = true;
                rbTruong.Enabled = false;
            }
            else if (Program.mGroup == "Truong")
            {
                rbCoSo.Enabled = false;
                rbGiaoVien.Enabled = false;
                rbTruong.Enabled = true;
            }

        }

        private void loadCbxHoTen()
        {
            DataTable dt = new DataTable();
            string cmd = "EXEC [dbo].[SP_TAIKHOAN_DS_GV_CHUACOTK]";
            dt = Program.ExecSqlQuery(cmd);

            BindingSource bdsGv = new BindingSource();
            bdsGv.DataSource = dt;
            cbxHoTen.DataSource = bdsGv;
            cbxHoTen.DisplayMember = "HOTEN";
            cbxHoTen.ValueMember = "MAGV";
        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {



            string mk = txtMatKhau.Text.Trim();
            string confirmMk = txtXacNhanMK.Text.Trim();
            if (mk != confirmMk)
            {
                XtraMessageBox.Show("Mật khẩu và xác nhận mật khẩu không trùng nhau", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có thật sự muốn thêm tài khoản này không?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String queryTaoTaiKhoan = "DECLARE @return_value int \n" +
                  "EXEC @return_value = [dbo].[SP_TAIKHOAN_CREATE] \n " +
                  "@loginanme = N'" + txtLogin.Text.Trim() + "',\n " +
                  "@matkhau = N'" + txtMatKhau.Text.Trim() + "',\n " +
                  "@username = N'" + txtUsername.Text.Trim() + "',\n " +
                   "@role = N'" + role + "'\n " +
                  "SELECT 'Return Value' = @return_value";
                Console.WriteLine(queryTaoTaiKhoan);

                int resultMa = Program.CheckDataHelper(queryTaoTaiKhoan);
                Console.WriteLine(resultMa);
                // 2
                // 0 : success

                if (resultMa == 2)
                {
                    XtraMessageBox.Show("Lỗi kết nối cơ sở dữ liệu", "", MessageBoxButtons.OK);
                    return;
                }
                else if (resultMa == 0)
                {
                    XtraMessageBox.Show("Tạo tài khoản thành công", "", MessageBoxButtons.OK);
                    frmTaiKhoanTao_Load(sender, e);
                    return;
                }
            }
                
        }



        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                if (((RadioButton)sender) == rbTruong)
                {
                    role = "TRUONG";
                }
                else if (((RadioButton)sender) == rbCoSo)
                {
                    role = "COSO";
                }
                else if (((RadioButton)sender) == rbGiaoVien)
                {
                    role = "GIANGVIEN";

                }
                
            }
        }


        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxHoTen_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (cbxHoTen.SelectedValue != null)
            {
                txtUsername.Text = cbxHoTen.SelectedValue.ToString();
            }
        }

        private void txtUsername_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}