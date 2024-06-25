using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THI_TN
{
    public partial class frmGiaoVien : DevExpress.XtraEditors.XtraForm
    {
        public frmGiaoVien()
        {
            InitializeComponent();
        }

        private string flagOptionGV;
        private string oldMaGV;
        private int vitri = 0;
        string pattern = @"^[A-Za-z ]+$";
        private void frmGiaoVien_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.BODETableAdapter.Fill(this.DS.BODE);
            this.GIAOVIEN_DANGKYTableAdapter.Fill(this.DS.GIAOVIEN_DANGKY);
            this.GIAOVIENTableAdapter.Fill(this.DS.GIAOVIEN);
            this.KHOATableAdapter.Fill(this.DS.KHOA);

            this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
            this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.GIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;

            cbxCoSo.DataSource = Program.bds_dspm;
            cbxCoSo.DisplayMember = "TENCOSO";
            cbxCoSo.ValueMember = "TENSERVER";
            cbxCoSo.SelectedIndex = Program.mChiNhanh;

            cbxKhoa.DataSource = bdsKhoa;
            cbxKhoa.DisplayMember = "TENKH";
            cbxKhoa.ValueMember = "MAKH";


            if (Program.mGroup == "CoSo")
            {
                cbxCoSo.Enabled = false;
            } else if (Program.mGroup == "Truong")
            {
                disableEditGiaoVien();
            }

            btnGhi.Enabled = btnPhucHoi.Enabled = false;
        }

        private void disableEditGiaoVien()
        {
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            panelControl4.Enabled = false;
            gIAOVIENGridControl.Enabled = true;
            kHOAGridControl.Enabled = true;
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
                this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
                this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                this.GIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;

                this.BODETableAdapter.Fill(this.DS.BODE);
                this.GIAOVIEN_DANGKYTableAdapter.Fill(this.DS.GIAOVIEN_DANGKY);
                this.GIAOVIENTableAdapter.Fill(this.DS.GIAOVIEN);
                this.KHOATableAdapter.Fill(this.DS.KHOA);
            }
        }

       

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsKhoa.Position;
            flagOptionGV = "ADD";
            bdsGV.AddNew();
            txtMAGV.Focus();
            txtMAKH.Text = ((DataRowView)bdsKhoa[vitri])["MAKH"].ToString();
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            panelControl4.Enabled = true;
            gIAOVIENGridControl.Enabled = false;
            kHOAGridControl.Enabled = false;
        }




        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsKhoa.Position;
            flagOptionGV = "UPDATE";
            oldMaGV = txtMAGV.Text.Trim();
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            panelControl4.Enabled = true;
            gIAOVIENGridControl.Enabled = false;
            kHOAGridControl.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidateGiaoVien() == true)
            {
                if (MessageBox.Show("Bạn có thật sự muốn ghi thông tin giáo viên không?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        bdsGV.EndEdit();
                        bdsGV.ResetCurrentItem();
                        this.GIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.GIAOVIENTableAdapter.Update(this.DS.GIAOVIEN);


                        btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = true;
                        btnGhi.Enabled = btnPhucHoi.Enabled = false;
                        panelControl4.Enabled = false;
                        gIAOVIENGridControl.Enabled = true;
                        kHOAGridControl.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.ToString());
                        MessageBox.Show("Loi ghi giao vien", ex.Message, MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            else
            {
                return;
            }
        }

        private bool ValidateGiaoVien()
        {

            string ho = txtHO.Text.Trim(); 
            string ten = txtTen.Text.Trim();
            string magv = txtMAGV.Text.Trim();  
            if (magv == "")
            {
                MessageBox.Show("Mã giáo viên không được bỏ trống", "", MessageBoxButtons.OK);
                txtMAGV.Focus();
                return false;
            }

            if (magv.Length > 8) {
                MessageBox.Show("Mã giảng viên không được vượt quá 8 ký tự", "", MessageBoxButtons.OK);
                txtMAGV.Focus();
                return false;
            }


            if (ho == "")
            {
                MessageBox.Show("Họ không được bỏ trống", "", MessageBoxButtons.OK);
                txtHO.Focus();
                return false;
            }

            if (!Regex.IsMatch(ho, pattern))
            {
                MessageBox.Show("Họ chỉ nhận chữ hoặc khoảng trắng", "", MessageBoxButtons.OK);
                txtHO.Focus();
                return false;
            }

            if (ten == "")
            {
                MessageBox.Show("Tên không được bỏ trống", "", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }


            if (!Regex.IsMatch(ten, pattern))
            {
                MessageBox.Show("Tên chỉ nhận chữ hoặc khoảng trắng", "", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }

        

            if (flagOptionGV == "ADD")
            {

                String queryCheckMaLop = "DECLARE @return_value int \n" +
                   "EXEC @return_value = [dbo].[SP_CHECKID] \n " +
                   "@Id = N'" + txtMAGV.Text.Trim() + "',\n " +
                   "@Type = N'MAGV' \n " +
                   "SELECT 'Return Value' = @return_value";
                Console.WriteLine(queryCheckMaLop);

                int resultMa = Program.CheckDataHelper(queryCheckMaLop);
                Console.WriteLine(resultMa);


                if (resultMa == -1)
                {
                    XtraMessageBox.Show("Lỗi kết nối cơ sở dữ liệu", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (resultMa == 1)
                {
                    XtraMessageBox.Show("Mã giảng viên đã tồn tại", "", MessageBoxButtons.OK);
                    return false;
                }

            }
            if (flagOptionGV == "UPDATE")
            {
                if (!this.txtMAGV.Text.Trim().ToString().Equals(oldMaGV))
                {
                    String queryCheckMaLop = "DECLARE @return_value int \n" +
                    "EXEC @return_value = [dbo].[SP_CHECKID] \n " +
                    "@Id = N'" + txtMAGV.Text.Trim() + "',\n " +
                    "@Type = N'MAGV' \n " +
                    "SELECT 'Return Value' = @return_value";
                    int resultMa = Program.CheckDataHelper(queryCheckMaLop);

                    if (resultMa == -1)
                    {
                        XtraMessageBox.Show("Lỗi kết nối cơ sở dữ liệu", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultMa == 1)
                    {
                        XtraMessageBox.Show("Mã giảng viên đã tồn tại", "", MessageBoxButtons.OK);
                        return false;
                    }
                  
                }
            }
            return true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maGV = "";
            if (bdsBoDe.Count > 0)
            {
                MessageBox.Show("Giáo viên này đã tạo ra bộ đề ", "", MessageBoxButtons.OK);
                return;
            }

            if (bdsGVDK.Count > 0)
            {
                MessageBox.Show("Giáo viên đã đăng kí cho một lớp thi", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sử muốn xóa giáo viên này không?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    maGV = ((DataRowView)bdsGV[bdsGV.Position])["MAGV"].ToString();
                    bdsGV.RemoveCurrent();
                    this.GIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.GIAOVIENTableAdapter.Update(this.DS.GIAOVIEN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa giáo viên: " + ex.Message, "", MessageBoxButtons.OK);
                    this.GIAOVIENTableAdapter.Fill(this.DS.GIAOVIEN);
                    bdsGV.Position = bdsGV.Find("MAGV", maGV);
                    return;
                }
                if (bdsGV.Count == 0)
                {
                    btnXoa.Enabled = false;
                }
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsGV.CancelEdit();
            Console.WriteLine(bdsKhoa.Position);
            if (btnAdd.Enabled == false)
            {
                bdsKhoa.Position = vitri;
            }
            gIAOVIENGridControl.Enabled = true;
            panelControl4.Enabled = false;
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            kHOAGridControl.Enabled = true;
            if (vitri > 0)
            {
                bdsGV.Position = vitri;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.BODETableAdapter.Fill(this.DS.BODE);
                this.GIAOVIEN_DANGKYTableAdapter.Fill(this.DS.GIAOVIEN_DANGKY);
                this.GIAOVIENTableAdapter.Fill(this.DS.GIAOVIEN);
                this.KHOATableAdapter.Fill(this.DS.KHOA);

                gIAOVIENGridControl.Enabled = true;
                panelControl4.Enabled = false;
                btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled= true;
                btnGhi.Enabled = btnPhucHoi.Enabled = false;
                kHOAGridControl.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void txtMAKH_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            panelControl4.Enabled = true;
            gIAOVIENGridControl.Enabled = false;
            kHOAGridControl.Enabled = false;
        }

        private void cbxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxKhoa.SelectedValue != null)
            {
                txtMAKH.Text = cbxKhoa.SelectedValue.ToString();
            }
        }
    }
}