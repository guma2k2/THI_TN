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
    public partial class frmChuanBiThi : DevExpress.XtraEditors.XtraForm
    {
        public frmChuanBiThi()
        {
            InitializeComponent();
        }


        private void frmChuanBiThi_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.LOPTableAdapter.Fill(this.DS.LOP);
            this.MONHOCTableAdapter.Fill(this.DS.MONHOC);
            this.GIAOVIEN_DANGKYTableAdapter.Fill(this.DS.GIAOVIEN_DANGKY);

            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;


            cbxCoSo.DataSource = Program.bds_dspm;
            cbxCoSo.DisplayMember = "TENCOSO";
            cbxCoSo.ValueMember = "TENSERVER";
            cbxCoSo.SelectedIndex = Program.mChiNhanh;

            txtMAGV.Text = Program.username;

            cbxTenMonHoc.DataSource = bdsMonHoc;
            cbxTenMonHoc.DisplayMember = "TENMH";
            cbxTenMonHoc.ValueMember = "MAMH";


            cbxTenLop.DataSource = bdsLop;
            cbxTenLop.DisplayMember = "TENLOP";
            cbxTenLop.ValueMember = "MALOP";


            cbxTrinhDo.SelectedIndex = 0;

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
                this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;


                this.LOPTableAdapter.Fill(this.DS.LOP);
                this.MONHOCTableAdapter.Fill(this.DS.MONHOC);
                this.GIAOVIEN_DANGKYTableAdapter.Fill(this.DS.GIAOVIEN_DANGKY);
            }
        }

        private void cbxTenMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTenMonHoc.SelectedValue != null)
            {
                txtMAMH.Text = cbxTenMonHoc.SelectedValue.ToString();
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (validateChuanBiThi() == true)
            {
                try
                {
                    bdsGV_DK.EndEdit();
                    bdsGV_DK.ResetCurrentItem();
                    this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.GIAOVIEN_DANGKYTableAdapter.Update(this.DS.GIAOVIEN_DANGKY);


                    /* sINHVIENGridControl.Enabled = true;*/
                    /* btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                     btnGhi.Enabled = btnPhucHoi.Enabled = false;*/
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                    MessageBox.Show("Loi ghi bo de", ex.Message, MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private bool validateChuanBiThi()
        {
           
            // ngay thi > hien tai 
            // lan thi 1 or 2
            if (cbxLan.Text.Trim() == "" )
            {

            } else if (int.Parse(cbxLan.Text) < 1 ||    int.Parse(cbxLan.Text) > 2){
                MessageBox.Show("Ma sinh vien khong dc bo trong", "", MessageBoxButtons.OK);
                cbxLan.Focus();
                return false;
            }

            int soCauThi = int.Parse(cbxSoCauThi.Text); // 10 x 100
            if (soCauThi < 10 || soCauThi  > 100)
            {
                MessageBox.Show("Ma sinh vien khong dc bo trong", "", MessageBoxButtons.OK);
                cbxLan.Focus();
                return false;
            }
            // thoi gian thi 2 < x < 60 
            int thoiGianThi = int.Parse(cbxThoiGian.Text);
            if (thoiGianThi < 2 || soCauThi > 60)
            {
                MessageBox.Show("Ma sinh vien khong dc bo trong", "", MessageBoxButtons.OK);
                cbxLan.Focus();
                return false;
            }

            String queryCheckExist = "DECLARE @return_value int \n" +
                   "EXEC @return_value = [dbo].[SP_CBT_CHECKEXIST] \n " +
                   "@malop = N'" + txtMALOP.Text.Trim() + "',\n " +
                   "@mamh = N'" + txtMAMH.Text.Trim() + "',\n " +
                   "@lan = N'" + cbxLan.Text.Trim() + "',\n " +
                   "SELECT 'Return Value' = @return_value";
            try
            {
                int result1 = Program.CheckDataHelper(queryCheckExist);
                if (result1 == -1)
                {
                    XtraMessageBox.Show("Loi ket noi database", "", MessageBoxButtons.OK);
                    return false;
                }
                else if (result1 == 1)
                {
                    XtraMessageBox.Show("Thong tin dang ky da ton tai", "", MessageBoxButtons.OK);
                    return false;
                }else if (result1 == 2)
                {
                    XtraMessageBox.Show("Thong tin dang ky da ton tai o co so khac", "", MessageBoxButtons.OK);
                    return false;
                }
            } catch (SqlException  ex)
            {
                XtraMessageBox.Show(ex.Message, "", MessageBoxButtons.OK);
                return false;
            }
           

            String queryCheckCount = "DECLARE @return_value int \n" +
                   "EXEC @return_value = [dbo].[SP_CBT_CHECKCOUNT_DETHI] \n " +
                   "@mamh = N'" + txtMAMH.Text.Trim() + "',\n " +
                   "@socauthi = N'" + cbxSoCauThi.Text.Trim() + "',\n " +
                   "@trinhdo = N'" + txtTrinhDo.Text.Trim() + "',\n " +
                   "SELECT 'Return Value' = @return_value";
           try
            {
                int result2 = Program.CheckDataHelper(queryCheckCount);
                if (result2 == 1)
                {
                    return true;
                }
            } catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, "", MessageBoxButtons.OK);
                return false;
            }
           
            return true;
        }

        private void cbxTenLop_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbxTenLop.SelectedValue != null)
            {
                txtMALOP.Text = cbxTenLop.SelectedValue.ToString();
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsGV_DK.AddNew();
            txtMAGV.Text = Program.username;
        }

        private void cbxTrinhDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(cbxTrinhDo.SelectedIndex);
            if (cbxTrinhDo.SelectedIndex == 0)
            {
                txtTrinhDo.Text = "A";
            }
            else if (cbxTrinhDo.SelectedIndex == 1)
            {
                txtTrinhDo.Text = "B";
            }
            else
            {
                txtTrinhDo.Text = "C";
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}