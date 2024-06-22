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
        private string pattern = @"^\w+\s+and\s+blank$";
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
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
        }




        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsGV.Position;
            flagOptionGV = "UPDATE";
            oldMaGV = txtMAGV.Text.Trim();


            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = false;
            btnGhi.Enabled = true;
            txtMAGV.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidateGiaoVien() == true)
            {
                try
                {
                    bdsGV.EndEdit();
                    bdsGV.ResetCurrentItem();
                    this.GIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.GIAOVIENTableAdapter.Update(this.DS.GIAOVIEN);


                    btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                    btnGhi.Enabled = btnPhucHoi.Enabled = false;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                    MessageBox.Show("Loi ghi giao vien", ex.Message, MessageBoxButtons.OK);
                    return;
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

            if (!Regex.IsMatch(ho, pattern) )
            {
                MessageBox.Show("Ho  chi nhan chu va khoang trang", "", MessageBoxButtons.OK);
                txtHO.Focus();
                return false;
            }

            if (!Regex.IsMatch(ten, pattern))
            {
                MessageBox.Show(" ten chi nhan chu va khoang trang", "", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }

            if (txtMAGV.Text.Trim() == "")
            {
                MessageBox.Show("Ma giao vien khong dc bo trong", "", MessageBoxButtons.OK);
                txtMAGV.Focus();
                return false;
            }


            if (txtHO.Text.Trim() == "")
            {
                MessageBox.Show("Ho khong dc bo trong", "", MessageBoxButtons.OK);
                txtHO.Focus();
                return false;
            }

            if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Ten khong dc bo trong", "", MessageBoxButtons.OK);
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
            }
            return true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maGV = "";
            // check data grid have rows > 0 
            if (bdsBoDe.Count > 0 || bdsGVDK.Count > 0)
            {
                MessageBox.Show("Khong the xoa giao vien nay ", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Ban co that su muon xoa giao vien nay khong?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
                    MessageBox.Show("Loi xoa giao vien: " + ex.Message, "", MessageBoxButtons.OK);
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
            if (btnAdd.Enabled == false) bdsGV.Position = vitri;
            gIAOVIENGridControl.Enabled = true;
            panelControl2.Enabled = true;
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            frmGiaoVien_Load(sender, e);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi reload " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void txtMAKH_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}