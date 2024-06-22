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
            DS.EnforceConstraints = false;
            this.GIAOVIEN_DANGKYTableAdapter.Fill(this.DS.GIAOVIEN_DANGKY);
            this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
            this.GIAOVIENTableAdapter.Fill(this.DS.GIAOVIEN);
            this.LOPTableAdapter.Fill(this.DS.LOP);
            this.KHOATableAdapter.Fill(this.DS.KHOA);


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
            if (Program.mGroup != "CoSo")
            {
                cbxCoSo.Enabled = false;
            }
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
            btnAddKhoa.Enabled = btnSuaKhoa.Enabled =btnXoaKhoa.Enabled = false;
            btnGhiKhoa.Enabled = btnPhucHoi.Enabled = true;
            txtMaKhoa.Focus();
        }

        private void btnSuaKhoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitriKhoa = bdsKhoa.Position;
            flagOptionKhoa = "UPDATE";
            oldMaKhoa = txtMaKhoa.Text.Trim();
            oldTenKhoa = txtTenKhoa.Text.Trim();

            btnAddKhoa.Enabled = btnSuaKhoa.Enabled = btnXoaKhoa.Enabled = false;
            btnGhiKhoa.Enabled = btnPhucHoi.Enabled = true;
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


                    btnAddKhoa.Enabled = btnSuaKhoa.Enabled = btnXoaKhoa.Enabled = true;
                    btnGhiKhoa.Enabled = btnPhucHoi.Enabled = false;
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
                MessageBox.Show("Ma khoa khong dc bo trong", "", MessageBoxButtons.OK);
                txtMaKhoa.Focus();
                return false;
            }
            if (txtTenKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Ten khoa khong dc bo trong", "", MessageBoxButtons.OK);
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
                    XtraMessageBox.Show("Loi ket noi database", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (resultMa == 1)
                {
                    XtraMessageBox.Show("Ma lop da ton tai o khoa hien tai", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (resultMa == 2)
                {
                    XtraMessageBox.Show("Ma lop da ton tai o khoa khac", "", MessageBoxButtons.OK);
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
                    XtraMessageBox.Show("Loi ket noi database", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (resultTen == 1)
                {
                    XtraMessageBox.Show("Ten mon hoc da ton tai ", "", MessageBoxButtons.OK);
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
                        XtraMessageBox.Show("Loi ket noi database", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultMa == 1)
                    {
                        XtraMessageBox.Show("Ma sinh vien da ton tai o khoa hien tai", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultMa == 2)
                    {
                        XtraMessageBox.Show("Ma lop da ton tai o khoa khac", "", MessageBoxButtons.OK);
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
                        XtraMessageBox.Show("Loi ket noi database", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultTen == 1)
                    {
                        XtraMessageBox.Show("Ten mon hoc da ton tai ", "", MessageBoxButtons.OK);
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnXoaKhoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maKhoa = "";
            // check data grid have rows > 0 
            if (bdsLop.Count > 0 || bdsGV.Count > 0)
            {
                MessageBox.Show("Khong the xoa khoa nay", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Ban co that su muon xoa khoa nay khong?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
                    MessageBox.Show("Loi xoa khoa: " + ex.Message, "", MessageBoxButtons.OK);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi reload " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThemLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flagOptionLop = "ADD";
            txtMaLop.Enabled = true;
            bdsLop.AddNew();
            txtMaKhoaOfLop.Text = ((DataRowView)bdsKhoa[bdsKhoa.Position])["MAKH"].ToString();
            Console.WriteLine(((DataRowView)bdsKhoa[bdsKhoa.Position])["MAKH"].ToString());
           
            btnThemLop.Enabled = btnSuaLop.Enabled = btnXoaLop.Enabled = false;
            btnGhiLop.Enabled = btnPhucHoi.Enabled = true;
        }

        private void btnSuaLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitriLop = bdsLop.Position;
            flagOptionLop = "UPDATE";
            oldMaLop = txtMaLop.Text.Trim();
            oldTenLop = txtTenLop.Text.Trim();

            btnThemLop.Enabled = btnSuaLop.Enabled = btnXoaLop.Enabled = false;
            btnGhiLop.Enabled = btnPhucHoi.Enabled = true;
            txtMaLop.Enabled = false;
            txtMaKhoaOfLop.Enabled = false;
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
                MessageBox.Show("Ma lop khong dc bo trong", "", MessageBoxButtons.OK);
                txtMaLop.Focus();
                return false;
            }
            if (txtTenLop.Text.Trim() == "")
            {
                MessageBox.Show("Ten lop khong dc bo trong", "", MessageBoxButtons.OK);
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
                    XtraMessageBox.Show("Loi ket noi database", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (resultMa == 1)
                {
                    XtraMessageBox.Show("Ma lop da ton tai o khoa hien tai", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (resultMa == 2)
                {
                    XtraMessageBox.Show("Ma lop da ton tai o khoa khac", "", MessageBoxButtons.OK);
                    return false;
                }

                String queryCheckTenLop = "DECLARE @return_value int \n" +
                   "EXEC @return_value = [dbo].[SP_CHECKNAME] \n " +
                   "@Name = N'" + txtTenKhoa.Text + "',\n " +
                   "@Type = N'TENLOP' \n " +
                   "SELECT 'Return Value' = @return_value";
                int resultTen = Program.CheckDataHelper(queryCheckTenLop);

                if (resultTen == -1)
                {
                    XtraMessageBox.Show("Loi ket noi database", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (resultTen == 1)
                {
                    XtraMessageBox.Show("Ten lop da ton tai ", "", MessageBoxButtons.OK);
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
                        XtraMessageBox.Show("Loi ket noi database", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultMa == 1)
                    {
                        XtraMessageBox.Show("Ma lop da ton tai o khoa hien tai", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultMa == 2)
                    {
                        XtraMessageBox.Show("Ma lop da ton tai o khoa khac", "", MessageBoxButtons.OK);
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
                        XtraMessageBox.Show("Loi ket noi database", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultTen == 1)
                    {
                        XtraMessageBox.Show("Ten lop da ton tai ", "", MessageBoxButtons.OK);
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnXoaLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maLop = "";
            // check data grid have rows > 0 
            if (bdsSV.Count > 0 || bdsGVDK.Count > 0)
            {
                MessageBox.Show("Khong the xoa lop nay", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Ban co that su muon xoa lop nay khong?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    maLop = ((DataRowView)bdsLop[bdsLop.Position])["MALOP"].ToString();
                    bdsLop.RemoveCurrent();
                    this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.LOPTableAdapter.Update(this.DS.LOP);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi xoa lop: " + ex.Message, "", MessageBoxButtons.OK);
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

       
        // btn phuc hoi lop

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLop.CancelEdit();
            if (btnThemLop.Enabled == false) bdsLop.Position = vitriLop;
            lOPGridControl.Enabled = true;
            /*panelControl2.Enabled = true;*/
            btnThemLop.Enabled = btnSuaLop.Enabled = btnXoaLop.Enabled = true;
            btnGhiLop2.Enabled = btnPhucHoiLop.Enabled = false;
            frmKhoaLop_Load(sender, e);
            if (vitriLop > 0)
            {
                bdsLop.Position = vitriLop;
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKhoa.CancelEdit();
            if (btnAddKhoa.Enabled == false) bdsKhoa.Position = vitriKhoa;
            kHOAGridControl.Enabled = true;
            /*panelControl2.Enabled = true;*/
            btnAddKhoa.Enabled = btnSuaKhoa.Enabled = btnXoaKhoa.Enabled = true;
            btnGhiKhoa.Enabled = btnPhucHoi.Enabled = false;
            frmKhoaLop_Load(sender, e);
            if (vitriKhoa > 0)
            {
                bdsKhoa.Position = vitriKhoa;
            }
        }
    }
}