using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THI_TN
{
    public partial class frmSinhVien : DevExpress.XtraEditors.XtraForm
    {
        public frmSinhVien()
        {
            InitializeComponent();
        }
        private string malop;
        private int vitri = 0;
        private string flagOptionSV;
        private string oldMASinhVien;
        string pattern = @"^[A-Za-z ]+$";

        private SqlConnection conn_publisher = new SqlConnection();
        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.BANGDIEMTableAdapter.Fill(this.DS.BANGDIEM);
            this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
            this.LOPTableAdapter.Fill(this.DS.LOP);


            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.BANGDIEMTableAdapter.Connection.ConnectionString = Program.connstr;

            cbxCoSo.DataSource = Program.bds_dspm;
            cbxCoSo.DisplayMember = "TENCOSO";
            cbxCoSo.ValueMember = "TENSERVER";
            cbxCoSo.SelectedIndex = Program.mChiNhanh;


            cbxLop.DataSource = bdsLop;

            cbxLop.DisplayMember = "TENLOP";
            cbxLop.ValueMember = "MALOP";

            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            txtMALOP.Enabled = false;
            panelControl4.Enabled = false;
            if (Program.mGroup == "CoSo")
            {
                cbxCoSo.Enabled = false;
            }else if (Program.mGroup == "Truong")
            {
                cbxCoSo.Enabled = true;
                btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = false;
                btnGhi.Enabled = btnPhucHoi.Enabled = false;
                panelControl4.Enabled = false;
                sINHVIENGridControl.Enabled = true;
            }
        }
        

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLop.Position;
            flagOptionSV = "ADD";
            bdsSV.AddNew();
            string maLop = ((DataRowView)bdsLop[vitri])["MALOP"].ToString();
            txtMALOP.Enabled = false;
            txtMALOP.Text = maLop;
            txtMASV.Focus();
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            panelControl4.Enabled = true;
            sINHVIENGridControl.Enabled = false;
            lOPGridControl.Enabled = false;
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
                MessageBox.Show("Loi ket noi ve co so moi", "", MessageBoxButtons.OK);
            }
            else
            {
                this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.BANGDIEMTableAdapter.Connection.ConnectionString = Program.connstr;

                this.BANGDIEMTableAdapter.Fill(this.DS.BANGDIEM);
                this.LOPTableAdapter.Fill(this.DS.LOP);
                this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
            }
        }

     






        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLop.Position;
            flagOptionSV = "UPDATE";
            oldMASinhVien = txtMASV.Text.Trim();
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            panelControl4.Enabled = true;
            lOPGridControl.Enabled = false;
            lOPGridControl.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidateSinhVien() == true)
            {
                if (MessageBox.Show("Bạn có thật sự muốn ghi thông tin sinh viên không?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        bdsSV.EndEdit();
                        bdsSV.ResetCurrentItem();
                        this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.SINHVIENTableAdapter.Update(this.DS.SINHVIEN);


                        btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = true;
                        btnGhi.Enabled = btnPhucHoi.Enabled = false;
                        panelControl4.Enabled = true;
                        sINHVIENGridControl.Enabled = true;
                        lOPGridControl.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.ToString());
                        MessageBox.Show("Lỗi ghi sinh viên", ex.Message, MessageBoxButtons.OK);
                        return;
                    }
                }
                   
            }
            else
            {
                return;
            }
        }

        private bool ValidateSinhVien()
        {
            string masv = txtMASV.Text.Trim();
            string ho = txtHo.Text.Trim();
            string ten = txtTen.Text.Trim();
            string password = txtPassword.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string ngaySinh = txtNgaySinh.Text.Trim();
            if (masv == "")
            {
                MessageBox.Show("Mã sinh viên không được bỏ trống", "", MessageBoxButtons.OK);
                txtMASV.Focus();
                return false;
            }
            if (masv.Length > 8)
            {
                MessageBox.Show("Mã sinh viên không được vượt quá 8 ký tự", "", MessageBoxButtons.OK);
                txtMASV.Focus();
                return false;
            }

            if (!Regex.IsMatch(ho, pattern))
            {
                MessageBox.Show("Họ chỉ nhẫn chữ hoặc khoảng trắng", "", MessageBoxButtons.OK);
                txtHo.Focus();
                return false;
            }

            if (!Regex.IsMatch(ten, pattern))
            {
                MessageBox.Show("Tên chỉ nhẫn chữ hoặc khoảng trắng", "", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }


            if (password == "")
            {
                MessageBox.Show("Mật khẩu không được bỏ trống", "", MessageBoxButtons.OK);
                txtPassword.Focus();
                return false;
            }


            if (flagOptionSV == "ADD")
            {

                String queryCheckMaLop = "DECLARE @return_value int \n" +
                   "EXEC @return_value = [dbo].[SP_CHECKID] \n " +
                   "@Id = N'" + txtMASV.Text.Trim() + "',\n " +
                   "@Type = N'MASV' \n " +
                   "SELECT 'Return Value' = @return_value";

                int resultMa = Program.CheckDataHelper(queryCheckMaLop);
                Console.WriteLine(resultMa);


                if (resultMa == -1)
                {
                    XtraMessageBox.Show("Lỗi kết nối cơ sở dữ liệu", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (resultMa == 1)
                {
                    XtraMessageBox.Show("Mã sinh viên đã tồn tại ở cơ sở này", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (resultMa == 2)
                {
                    XtraMessageBox.Show("Mã sinh viên đã tồn tại ở cơ sở khác", "", MessageBoxButtons.OK);
                    return false;
                }

            }
            if (flagOptionSV == "UPDATE")
            {
                if (!this.txtMASV.Text.Trim().ToString().Equals(oldMASinhVien))
                {
                    String queryCheckMaLop = "DECLARE @return_value int \n" +
                    "EXEC @return_value = [dbo].[SP_CHECKID] \n " +
                    "@Id = N'" + txtMASV.Text.Trim() + "',\n " +
                    "@Type = N'MASV' \n " +
                    "SELECT 'Return Value' = @return_value";
                    int resultMa = Program.CheckDataHelper(queryCheckMaLop);

                    if (resultMa == -1)
                    {
                        XtraMessageBox.Show("Lỗi kết nối cơ sở dữ liệu", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultMa == 1)
                    {
                        XtraMessageBox.Show("Mã sinh viên đã tồn tại ở cơ sở này", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultMa == 2)
                    {
                        XtraMessageBox.Show("Mã sinh viên đã tồn tại ở cơ sở khác", "", MessageBoxButtons.OK);
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maSinhVien = "";
            if (bdsBangDiem.Count > 0 )
            {
                MessageBox.Show("Không thể xóa sinh viên này vì sinh viên này đã có bảng điểm", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa sinh viên này không?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    maSinhVien = ((DataRowView)bdsSV[bdsSV.Position])["MASV"].ToString();
                    bdsSV.RemoveCurrent();
                    this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.SINHVIENTableAdapter.Update(this.DS.SINHVIEN);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi xoa sinh vien: " + ex.Message, "", MessageBoxButtons.OK);
                    this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
                    bdsSV.Position = bdsSV.Find("MASV", maSinhVien);
                    return;
                }
                if (bdsSV.Count == 0)
                {
                    btnXoa.Enabled = false;
                }
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.BANGDIEMTableAdapter.Fill(this.DS.BANGDIEM);
                this.LOPTableAdapter.Fill(this.DS.LOP);
                this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);

                panelControl2.Enabled = false;
                btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnHuy.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = true;
                btnGhi.Enabled = btnPhucHoi.Enabled = false;
                lOPGridControl.Enabled = sINHVIENGridControl.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }
        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsSV.CancelEdit();
            if (btnAdd.Enabled == false) bdsLop.Position = vitri;
            sINHVIENGridControl.Enabled = true;
            lOPGridControl.Enabled  = true;
            panelControl2.Enabled = true;
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnHuy.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            if (vitri > 0)
            {
                bdsSV.Position = vitri;
            }
        }


        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            panelControl4.Enabled = false;
            sINHVIENGridControl.Enabled = true;
            lOPGridControl.Enabled = true;
        }











        private void nGAYSINHLabel_Click(object sender, EventArgs e)
        {

        }

        private void nGAYSINHDateEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}