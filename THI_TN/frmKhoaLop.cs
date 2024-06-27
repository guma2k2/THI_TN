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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace THI_TN
{
    public partial class frmKhoaLop : DevExpress.XtraEditors.XtraForm
    {
        public frmKhoaLop()
        {
            InitializeComponent();
        }

        private string flagOptionKhoa;
        private string flagOptionLop;
        private string oldMaKhoa;
        private string oldTenKhoa;
        private string oldMaLop;
        private string oldTenLop;
        private int vitriKhoa = 0, vitriLop = 0;


        private void frmKhoaLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DS.COSO' table. You can move, or remove it, as needed.
            DS.EnforceConstraints = false;
            this.GIAOVIEN_DANGKYTableAdapter.Fill(this.DS.GIAOVIEN_DANGKY);
            this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
            this.GIAOVIENTableAdapter.Fill(this.DS.GIAOVIEN);
            this.LOPTableAdapter.Fill(this.DS.LOP);
            this.KHOATableAdapter.Fill(this.DS.KHOA);
            this.cOSOTableAdapter.Fill(this.DS.COSO);


            this.cOSOTableAdapter.Connection.ConnectionString = Program.connstr;

            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.GIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
            this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;

            cbxCoSo.DataSource = Program.bds_dspm;
            cbxCoSo.DisplayMember = "TENCOSO";
            cbxCoSo.ValueMember = "TENSERVER";
            Console.WriteLine(Program.mChiNhanh);
            cbxCoSo.SelectedIndex = Program.mChiNhanh;

            cbxKhoa.DataSource = bdsKhoa;
            cbxKhoa.DisplayMember = "TENKH";
            cbxKhoa.ValueMember = "MAKH";

            cbxCs.DataSource = bdsCoSo;
            cbxCs.DisplayMember = "TENCS";
            cbxCs.ValueMember = "MACS";
            if (Program.mGroup == "CoSo")
            {
                cbxCoSo.Enabled = false;
            }

            btnGhiKhoa.Enabled = btnPhucHoi.Enabled = false;
            btnGhiLop2.Enabled = btnPhucHoiLop2.Enabled = false;

            panelControl5.Enabled = panelControl8.Enabled = false;

        }





        private void cbxCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCoSo.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }

            Program.servername = cbxCoSo.SelectedValue.ToString();
            Console.WriteLine(cbxCoSo.SelectedValue.ToString());
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
                this.GIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
                this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;

                this.GIAOVIEN_DANGKYTableAdapter.Fill(this.DS.GIAOVIEN_DANGKY);
                this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
                this.GIAOVIENTableAdapter.Fill(this.DS.GIAOVIEN);
                this.LOPTableAdapter.Fill(this.DS.LOP);
                this.KHOATableAdapter.Fill(this.DS.KHOA);

                
            }
        }

        private void btnAddKhoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flagOptionKhoa = "ADD";
            txtMaKhoa.Enabled = true;
            bdsKhoa.AddNew();
            txtMaCS.Text = ((DataRowView)bdsKhoa[0])["MACS"].ToString();
            btnAddKhoa.Enabled = btnSuaKhoa.Enabled =btnXoaKhoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = false;
            btnGhiKhoa.Enabled = btnPhucHoi.Enabled = true;
            panelControl5.Enabled = true;
            kHOAGridControl.Enabled = false;

            Boolean disableLop = false;
            updateStatusOfLop(disableLop);
            txtMaKhoa.Focus();
        }


        private void updateStatusOfLop(Boolean status)
        {

            btnThemLop.Enabled = btnSuaLop.Enabled = btnXoaLop.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = status;
            btnGhiLop2.Enabled = btnPhucHoiLop2.Enabled = status;
            panelControl8.Enabled = status;
            lOPGridControl.Enabled = status;
        }


        private void updateStatusOfKhoa(Boolean status)
        {

            btnAddKhoa.Enabled = btnSuaKhoa.Enabled = btnXoaKhoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = status;
            btnGhiKhoa.Enabled = btnPhucHoi.Enabled = status;
            panelControl5.Enabled = status;
            kHOAGridControl.Enabled = status;
        }


        private void btnSuaKhoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitriKhoa = bdsKhoa.Position;
            flagOptionKhoa = "UPDATE";
            oldMaKhoa = txtMaKhoa.Text.Trim();
            oldTenKhoa = txtTenKhoa.Text.Trim();

            btnAddKhoa.Enabled = btnSuaKhoa.Enabled = btnXoaKhoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = false;
            btnGhiKhoa.Enabled = btnPhucHoi.Enabled = true;
            panelControl4.Enabled = true;
            kHOAGridControl.Enabled = false;

            Boolean statusLop = false;
            updateStatusOfLop(statusLop);


            txtMaKhoa.Enabled = false;
        }

        private void btnGhiKhoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidateKhoa() == true)
            {
                try
                {
                    bdsKhoa.EndEdit();
                    bdsKhoa.ResetCurrentItem();
                    this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
                    this.KHOATableAdapter.Update(this.DS.KHOA);


                    btnAddKhoa.Enabled = btnSuaKhoa.Enabled = btnXoaKhoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = true;
                    btnGhiKhoa.Enabled = btnPhucHoi.Enabled = false;
                    panelControl4.Enabled = false;
                    panelControl8.Enabled = false;
                    kHOAGridControl.Enabled = true;
                    Boolean statusLop = true;
                    updateStatusOfLop(statusLop);
                    btnGhiLop2.Enabled = btnPhucHoiLop2.Enabled = false;
                    panelControl8.Enabled = false;

                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                    MessageBox.Show("Loi ghi KHOA", ex.Message, MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private bool ValidateKhoa()
        {
            if (txtMaKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Mã khoa không được bỏ trống", "", MessageBoxButtons.OK);
                txtMaKhoa.Focus();
                return false;
            }
            if (txtTenKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Tên khoa không được bỏ trống", "", MessageBoxButtons.OK);
                txtTenKhoa.Focus();
                return false;
            }

            if (flagOptionKhoa == "ADD")
            {

                String queryCheckMaKhoa = "DECLARE @return_value int \n" +
                   "EXEC @return_value = [dbo].[SP_CHECKID] \n " +
                   "@Id = N'" + txtMaKhoa.Text.Trim() + "',\n " +
                   "@Type = N'MAKH' \n " +
                   "SELECT 'Return Value' = @return_value";

                int resultMa = Program.CheckDataHelper(queryCheckMaKhoa);
                Console.WriteLine(resultMa);


                if (resultMa == -1)
                {
                    XtraMessageBox.Show("Lỗi kết nối database", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (resultMa == 1)
                {
                    XtraMessageBox.Show("Mã khoa đã tồn tại ở site hiện tại", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (resultMa == 2)
                {
                    XtraMessageBox.Show("Mã khoa đã tồn tại ở site khác", "", MessageBoxButtons.OK);
                    return false;
                }

                String queryCheckTenKhoa = "DECLARE @return_value int \n" +
                   "EXEC @return_value = [dbo].[SP_CHECKNAME] \n " +
                   "@Name = N'" + txtTenKhoa.Text + "',\n " +
                   "@Type = N'TENKH' \n " +
                   "SELECT 'Return Value' = @return_value";
                int resultTen = Program.CheckDataHelper(queryCheckTenKhoa);

                if (resultTen == -1)
                {
                    XtraMessageBox.Show("Lỗi kết nối database", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (resultTen == 1)
                {
                    XtraMessageBox.Show("Tên khoa đã tồn tại ở site hiện tại", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (resultTen == 2)
                {
                    XtraMessageBox.Show("Tên khoa đã tồn tại ở site khác", "", MessageBoxButtons.OK);
                    return false;
                }

            }
            if (flagOptionKhoa == "UPDATE")
            {
                if (!this.txtMaKhoa.Text.Trim().ToString().Equals(oldMaKhoa))
                {
                    String queryCheckMaLop = "DECLARE @return_value int \n" +
                    "EXEC @return_value = [dbo].[SP_CHECKID] \n " +
                    "@Id = N'" + txtMaKhoa.Text.Trim() + "',\n " +
                    "@Type = N'MAKH' \n " +
                    "SELECT 'Return Value' = @return_value";
                    int resultMa = Program.CheckDataHelper(queryCheckMaLop);

                    if (resultMa == -1)
                    {
                        XtraMessageBox.Show("Lỗi kết nối database", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultMa == 1)
                    {
                        XtraMessageBox.Show("Mã khoa đã tồn tại ở site hiện tại", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultMa == 2)
                    {
                        XtraMessageBox.Show("Mã khoa đã tồn tại ở site khác", "", MessageBoxButtons.OK);
                        return false;
                    }
                }
                if (!this.txtTenKhoa.Text.Trim().ToString().Equals(oldTenKhoa))
                {
                    String queryCheckTenLop = "DECLARE @return_value int \n" +
                    "EXEC @return_value = [dbo].[SP_CHECKNAME] \n " +
                    "@Name = N'" + txtTenKhoa.Text.Trim() + "',\n " +
                    "@Type = N'TENKHOA' \n " +
                    "SELECT 'Return Value' = @return_value";
                    int resultTen = Program.CheckDataHelper(queryCheckTenLop);

                    if (resultTen == -1)
                    {
                        XtraMessageBox.Show("Lỗi kết nối database", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultTen == 1)
                    {
                        XtraMessageBox.Show("Tên khoa đã tồn tại ở site hiện tại", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultTen == 2)
                    {
                        XtraMessageBox.Show("Tên khoa đã tồn tại ở site khác", "", MessageBoxButtons.OK);
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnXoaKhoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maKhoa = "";
            if (bdsLop.Count > 0)
            {
                MessageBox.Show("Không thể xóa khoa này do khóa này đang có lớp", "", MessageBoxButtons.OK);
                return;
            }

            if (bdsGV.Count > 0)
            {
                MessageBox.Show("Không thể xóa khoa này do có giáo viên thuộc khoa này", "", MessageBoxButtons.OK);
                return;
            }


            if (MessageBox.Show("Bạn có thật sự muốn xóa khoa này không?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    maKhoa = ((DataRowView)bdsKhoa[bdsKhoa.Position])["MAKH"].ToString();
                    bdsKhoa.RemoveCurrent();
                    this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
                    this.KHOATableAdapter.Update(this.DS.KHOA);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa khoa: " + ex.Message, "", MessageBoxButtons.OK);
                    this.KHOATableAdapter.Fill(this.DS.KHOA);
                    bdsKhoa.Position = bdsKhoa.Find("MAKH", maKhoa);
                    return;
                }
                if (bdsKhoa.Count == 0)
                {
                    btnXoaKhoa.Enabled = false;
                }
            }
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.GIAOVIEN_DANGKYTableAdapter.Fill(this.DS.GIAOVIEN_DANGKY);
                this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
                this.GIAOVIENTableAdapter.Fill(this.DS.GIAOVIEN);
                this.LOPTableAdapter.Fill(this.DS.LOP);
                this.KHOATableAdapter.Fill(this.DS.KHOA);

                updateStatusOfKhoa(true);
                updateStatusOfLop(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThemLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flagOptionLop = "ADD";
            bdsLop.AddNew();
            txtMaKhOfLop.Text = ((DataRowView)bdsKhoa[bdsKhoa.Position])["MAKH"].ToString();
            btnThemLop.Enabled = btnSuaLop.Enabled = btnXoaLop.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = false;
            btnGhiLop2.Enabled = btnPhucHoiLop2.Enabled = true;
            panelControl8.Enabled = true;
            lOPGridControl.Enabled = false;

            Boolean statusKhoa = false;
            updateStatusOfKhoa(statusKhoa);
            txtMaLop.Focus();
        }

        private void btnSuaLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitriLop = bdsLop.Position;
            flagOptionLop = "UPDATE";
            oldMaLop = txtMaLop.Text.Trim();
            oldTenLop = txtTenLop.Text.Trim();

            btnThemLop.Enabled = btnSuaLop.Enabled = btnXoaLop.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = false;
            btnGhiLop2.Enabled = btnPhucHoiLop2.Enabled = true;
            panelControl5.Enabled = true;
            lOPGridControl.Enabled = false;

            Boolean statusKhoa = false;
            updateStatusOfKhoa(statusKhoa);



            txtMaLop.Enabled = false;
            txtMaKhOfLop.Enabled = false;
        }

        private void btnGhiLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidateLop() == true)
            {
                try
                {
                    bdsLop.EndEdit();
                    bdsLop.ResetCurrentItem();
                    this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.LOPTableAdapter.Update(this.DS.LOP);

                    btnThemLop.Enabled = btnSuaLop.Enabled = btnXoaLop.Enabled = false;
                    btnGhiLop.Enabled = btnPhucHoi.Enabled = true;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                    MessageBox.Show("Loi ghi LOP", ex.Message, MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                return;
            }
        }


        private bool ValidateLop()
        {
            if (txtMaLop.Text.Trim() == "")
            {
                MessageBox.Show("Mã lớp không được bỏ trống", "", MessageBoxButtons.OK);
                txtMaLop.Focus();
                return false;
            }
            if (txtTenLop.Text.Trim() == "")
            {
                MessageBox.Show("Tên lớp không được bỏ trống", "", MessageBoxButtons.OK);
                txtTenLop.Focus();
                return false;
            }

            if (flagOptionLop == "ADD")
            {

                String queryCheckMaLop = "DECLARE @return_value int \n" +
                   "EXEC @return_value = [dbo].[SP_CHECKID] \n " +
                   "@Id = N'" + txtMaLop.Text.Trim() + "',\n " +
                   "@Type = N'MALOP' \n " +
                   "SELECT 'Return Value' = @return_value";

                int resultMa = Program.CheckDataHelper(queryCheckMaLop);
                Console.WriteLine(resultMa);


                if (resultMa == -1)
                {
                    XtraMessageBox.Show("Lỗi kết nối database", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (resultMa == 1)
                {
                    XtraMessageBox.Show("Mã lớp đã tồn tại ở site hiện tại", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (resultMa == 2)
                {
                    XtraMessageBox.Show("Mã lớp đã tồn tại ở site khác", "", MessageBoxButtons.OK);
                    return false;
                }

                String queryCheckTenLop = "DECLARE @return_value int \n" +
                   "EXEC @return_value = [dbo].[SP_CHECKNAME] \n " +
                   "@Name = N'" + txtTenLop.Text.Trim() + "',\n " +
                   "@Type = N'TENLOP' \n " +
                   "SELECT 'Return Value' = @return_value";
                int resultTen = Program.CheckDataHelper(queryCheckTenLop);

                if (resultTen == -1)
                {
                    XtraMessageBox.Show("Lỗi kết nối database", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (resultTen == 1)
                {
                    XtraMessageBox.Show("Tên lớp đã tồn tại ở site hiện tại", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (resultTen == 2)
                {
                    XtraMessageBox.Show("Tên lớp đã tồn tại ở site khác", "", MessageBoxButtons.OK);
                    return false;
                }

            }
            if (flagOptionKhoa == "UPDATE")
            {
                if (!this.txtMaLop.Text.Trim().ToString().Equals(oldMaLop))
                {
                    String queryCheckMaLop = "DECLARE @return_value int \n" +
                    "EXEC @return_value = [dbo].[SP_CHECKID] \n " +
                    "@Id = N'" + txtMaLop.Text.Trim() + "',\n " +
                    "@Type = N'MALOP' \n " +
                    "SELECT 'Return Value' = @return_value";
                    int resultMa = Program.CheckDataHelper(queryCheckMaLop);

                    if (resultMa == -1)
                    {
                        XtraMessageBox.Show("Lỗi kết nối database", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultMa == 1)
                    {
                        XtraMessageBox.Show("Mã lớp đã tồn tại ở site hiện tại", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultMa == 2)
                    {
                        XtraMessageBox.Show("Mã lớp đã tồn tại ở site khác", "", MessageBoxButtons.OK);
                        return false;
                    }
                }
                if (!this.txtTenLop.Text.Trim().ToString().Equals(oldTenLop))
                {
                    String queryCheckTenLop = "DECLARE @return_value int \n" +
                    "EXEC @return_value = [dbo].[SP_CHECKNAME] \n " +
                    "@Name = N'" + txtTenLop.Text.Trim() + "',\n " +
                    "@Type = N'TENLOP' \n " +
                    "SELECT 'Return Value' = @return_value";
                    int resultTen = Program.CheckDataHelper(queryCheckTenLop);

                    if (resultTen == -1)
                    {
                        XtraMessageBox.Show("Lỗi kết nối database", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultTen == 1)
                    {
                        XtraMessageBox.Show("Tên lớp đã tồn tại ở site hiện tại", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultTen == 2)
                    {
                        XtraMessageBox.Show("Tên lớp đã tồn tại ở site khác", "", MessageBoxButtons.OK);
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnXoaLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maLop = "";
            if (bdsSV.Count > 0)
            {
                MessageBox.Show("Không thể xóa lớp do có sinh viên thuộc lớp này", "", MessageBoxButtons.OK);
                return;
            }

            if (bdsGVDK.Count > 0)
            {
                MessageBox.Show("Không thể xóa lớp do có giáo viên đăng ký thi ", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa lớp này không?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    maLop = ((DataRowView)bdsLop[bdsLop.Position])["MALOP"].ToString();
                    bdsLop.RemoveCurrent();
                    this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.LOPTableAdapter.Update(this.DS.LOP);
                    btnPhucHoi.Enabled = btnGhiKhoa.Enabled = false;
                    btnPhucHoiLop2.Enabled = btnGhiLop2.Enabled = false;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa lớp: " + ex.Message, "", MessageBoxButtons.OK);
                    this.LOPTableAdapter.Fill(this.DS.LOP);
                    bdsLop.Position = bdsLop.Find("MALOP", maLop);
                    return;
                }
                if (bdsLop.Count == 0)
                {
                    btnXoaLop.Enabled = false;
                }
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnGhiLop2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidateLop() == true)
            {
                try
                {
                    bdsLop.EndEdit();
                    bdsLop.ResetCurrentItem();
                    this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.LOPTableAdapter.Update(this.DS.LOP);

                    btnThemLop.Enabled = btnSuaLop.Enabled = btnXoaLop.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = true;
                    btnGhiLop2.Enabled = btnPhucHoiLop2.Enabled = false;
                    panelControl5.Enabled = false;
                    lOPGridControl.Enabled = true;

                    Boolean statusKhoa = true;
                    updateStatusOfKhoa(statusKhoa);

                    btnGhiKhoa.Enabled = btnPhucHoi.Enabled = false;
                    panelControl5.Enabled = false;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                    MessageBox.Show("Lỗi ghi lớp", ex.Message, MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                return;
            }
        }

       
        // btn phuc hoi lop

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLop.CancelEdit();
            if (btnThemLop.Enabled == false) bdsLop.Position = vitriLop;
            lOPGridControl.Enabled = true;
            panelControl8.Enabled = true;
            btnThemLop.Enabled = btnSuaLop.Enabled = btnXoaLop.Enabled = true;
            btnGhiLop2.Enabled = btnPhucHoiLop.Enabled = false;

            btnAddKhoa.Enabled = btnSuaKhoa.Enabled = btnXoaKhoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = true;
            btnGhiKhoa.Enabled = btnPhucHoi.Enabled = false;
            panelControl5.Enabled = false;
            kHOAGridControl.Enabled = true;
            if (vitriLop > 0)
            {
                bdsLop.Position = vitriLop;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           this.Close();
        }

        private void panelControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKhoa.CancelEdit();
            if (btnAddKhoa.Enabled == false) bdsKhoa.Position = vitriKhoa;
            kHOAGridControl.Enabled = true;
            panelControl2.Enabled = false;
            kHOAGridControl.Enabled = true;
            btnAddKhoa.Enabled = btnSuaKhoa.Enabled = btnXoaKhoa.Enabled = true;
            btnGhiKhoa.Enabled = btnPhucHoi.Enabled = false;



            btnThemLop.Enabled = btnSuaLop.Enabled = btnXoaLop.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = true;
            btnGhiLop2.Enabled = btnPhucHoiLop2.Enabled = false;
            panelControl8.Enabled = false;
            lOPGridControl.Enabled = true;

            if (vitriKhoa > 0)
            {
                bdsKhoa.Position = vitriKhoa;
            }
        }
    }
}