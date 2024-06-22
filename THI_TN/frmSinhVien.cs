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
        string pattern = @"^\w+\s+and\s+blank$";

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

            if (Program.mGroup != "CoSo")
            {
                cbxCoSo.Enabled = false;
            }
        }
        

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLop.Position;
            flagOptionSV = "ADD";
            bdsSV.AddNew();
            txtMASV.Enabled = true;
            string maLop = ((DataRowView)bdsLop[vitri])["MALOP"].ToString();
            Console.WriteLine(maLop);
            txtMALOP.Enabled = true;
            txtMALOP.Text = maLop;
            txtMASV.Focus();
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
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


            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = false;
            btnGhi.Enabled = true;
            txtMASV.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidateSinhVien() == true)
            {
                try
                {
                    bdsSV.EndEdit();
                    bdsSV.ResetCurrentItem();
                    this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.SINHVIENTableAdapter.Update(this.DS.SINHVIEN);


                    /* sINHVIENGridControl.Enabled = true;*/
                    btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                    btnGhi.Enabled = btnPhucHoi.Enabled = false;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                    MessageBox.Show("Loi ghi sinh vien", ex.Message, MessageBoxButtons.OK);
                    return;
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

            if (!Regex.IsMatch(ho, pattern))
            {
                MessageBox.Show("Ho  chi nhan chu va khoang trang", "", MessageBoxButtons.OK);
                txtHo.Focus();
                return false;
            }

            if (!Regex.IsMatch(ten, pattern))
            {
                MessageBox.Show(" ten chi nhan chu va khoang trang", "", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }
            if (masv == "")
            {
                MessageBox.Show("Ma sinh vien khong dc bo trong", "", MessageBoxButtons.OK);
                txtMASV.Focus();
                return false;
            }
            if (masv.Length > 8)
            {
                MessageBox.Show("Ma sinh vien khong qua 8 ky tu", "", MessageBoxButtons.OK);
                txtMASV.Focus();
                return false;
            }
           

            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Mat khau khong dc bo trong", "", MessageBoxButtons.OK);
                txtPassword.Focus();
                return false;
            }


            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Dia chi khong dc bo trong", "", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }

            if (txtNgaySinh.Text.Trim() == "")
            {
                MessageBox.Show("Ngay sinh khong dc bo trong", "", MessageBoxButtons.OK);
                txtNgaySinh.Focus();
                return false;
            }


            if (flagOptionSV == "ADD")
            {

                String queryCheckMaLop = "DECLARE @return_value int \n" +
                   "EXEC @return_value = [dbo].[SP_CHECKID] \n " +
                   "@Id = N'" + txtMASV.Text.Trim() + "',\n " +
                   "@Type = N'MASV' \n " +
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
            string maSinhVien = "";
            // check data grid have rows > 0 
            if (bdsBangDiem.Count > 0 )
            {
                MessageBox.Show("Khong the xoa sinh vien nay vi da dang ki mon", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Ban co that su muon xoa sinh vien nay khong?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi reload " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }
        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsSV.CancelEdit();
            if (btnAdd.Enabled == false) bdsSV.Position = vitri;
            sINHVIENGridControl.Enabled = true;
            panelControl2.Enabled = true;
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            frmSinhVien_Load(sender, e);
            if (vitri > 0)
            {
                bdsSV.Position = vitri;
            }
        }














        private void nGAYSINHLabel_Click(object sender, EventArgs e)
        {

        }

        private void nGAYSINHDateEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

       
    }
}