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
        private string flagOption;
        private int vitri = 0;

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


            cbxTenMonHoc.DataSource = bdsMonHoc;
            cbxTenMonHoc.DisplayMember = "TENMH";
            cbxTenMonHoc.ValueMember = "MAMH";


            cbxTenLop.DataSource = bdsLop;
            cbxTenLop.DisplayMember = "TENLOP";
            cbxTenLop.ValueMember = "MALOP";


            
            if (Program.mGroup == "CoSo")
            {
                cbxCoSo.Enabled = false;
            }
            else if (Program.mGroup == "Truong")
            {
                cbxCoSo.Enabled = true;
                btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = false;
                btnGhi.Enabled = btnPhucHoi.Enabled = false;
                panelControl1.Enabled = false;
                gIAOVIEN_DANGKYGridControl.Enabled = false;
                cbxTenMonHoc.Enabled = cbxTenLop.Enabled = false;
            }


           


            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            panelControl1 .Enabled = false;
            gIAOVIEN_DANGKYGridControl.Enabled = true;
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

                if (MessageBox.Show("Bạn có thật sự muốn đăng kí thi?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        bdsGV_DK.EndEdit();
                        bdsGV_DK.ResetCurrentItem();
                        this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.GIAOVIEN_DANGKYTableAdapter.Update(this.DS.GIAOVIEN_DANGKY);

                        gIAOVIEN_DANGKYGridControl.Enabled = true;
                        btnPhucHoi.Enabled = btnGhi.Enabled = false;
                        btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = true;
                        panelControl1.Enabled = false;
                        cbxTenMonHoc.Enabled = cbxTenLop.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.ToString());
                        MessageBox.Show("Lỗi ghi giáo viên đăng kí", ex.Message, MessageBoxButtons.OK);
                        return;
                    }
                }

                
            }
            else
            {
                return;
            }
        }

        private bool validateChuanBiThi()
        {

            if (cbxLan.Text.Trim() == "")
            {
                MessageBox.Show("Lần thi ko dc bo trong", "", MessageBoxButtons.OK);
                cbxLan.Focus();
                return false;
            }
            else if (int.Parse(cbxLan.Text.ToString()) < 1 || int.Parse(cbxLan.Text.ToString()) > 2)
            {
                MessageBox.Show("Lần thi chỉ 1 hoặc 2", "", MessageBoxButtons.OK);
                cbxLan.Focus();
                return false;
            }

            int soCauThi = int.Parse(cbxSoCauThi.Text.ToString()); // 10 x 100
            if (soCauThi < 10 || soCauThi > 100)
            {
                MessageBox.Show("Số câu thi phải lớn hơn bằng 10 và nhỏ hơn bằng 100", "", MessageBoxButtons.OK);
                cbxLan.Focus();
                return false;
            }
            int thoiGianThi = int.Parse(cbxThoiGian.Text.ToString());
            if (thoiGianThi < 2 || soCauThi > 60)
            {
                MessageBox.Show("Thời gian thi phải lớn bằng 2 và nhỏ hơn bằng 60", "", MessageBoxButtons.OK);
                cbxLan.Focus();
                return false;
            }

            DateTime selectedDate = cbxNgayThi.DateTime;
            DateTime today = DateTime.Today;

            if (selectedDate < today)
            {
                MessageBox.Show("Ngày thi phải lớn hôm nay", "", MessageBoxButtons.OK);
                cbxNgayThi.Focus();
                return false;
            }
            

            if (flagOption == "ADD")
            {
                String queryCheckExist = "DECLARE @return_value int \n" +
                 "EXEC @return_value = [dbo].[SP_CBT_CHECKEXIST] \n " +
                 "@malop = N'" + txtMALOP.Text.Trim() + "',\n " +
                 "@mamh = N'" + txtMAMH.Text.Trim() + "',\n " +
                 "@lan = N'" + cbxLan.Text.Trim() + "',\n " +
                 "@ngaythi = N'" + cbxNgayThi.Text.Trim() + "'\n" +
                 "SELECT 'Return Value' = @return_value";
                try
                {
                    Program.CheckDataHelper(queryCheckExist);
                }
                catch (SqlException ex)
                {
                    XtraMessageBox.Show(ex.Message, "", MessageBoxButtons.OK);
                    return false;
                }
            }




            String queryCheckCount = "DECLARE @return_value int \n" +
                   "EXEC @return_value = [dbo].[SP_CBT_CHECKCOUNT_DETHI] \n " +
                   "@mamh = N'" + txtMAMH.Text.Trim() + "',\n " +
                   "@socauthi = N'" + cbxSoCauThi.Text.Trim() + "',\n " +
                   "@trinhdo = N'" + txtTrinhDo.Text.Trim() + "'\n " +
                   "SELECT 'Return Value' = @return_value";
            try
            {
                int result2 = Program.CheckDataHelper(queryCheckCount);
                if (result2 == 1)
                {
                    return true;
                }
            }
            catch (SqlException ex)
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
            cbxTrinhDo.SelectedIndex = 0;
            txtTrinhDo.Text = "A";
            txtMAGV.Text = Program.username;
            vitri = bdsGV_DK.Position;
            flagOption = "ADD";
            cbxTenMonHoc.Focus();
            txtMALOP.Text = cbxTenLop.SelectedValue.ToString();
            txtMAMH.Text = cbxTenMonHoc.SelectedValue.ToString();


            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            panelControl1.Enabled = true;
            gIAOVIEN_DANGKYGridControl.Enabled = false;
            cbxTenMonHoc.Enabled = cbxTenLop.Enabled = true;
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
            vitri = bdsGV_DK.Position;
            flagOption = "UPDATE";
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = false;
            cbxTenMonHoc.Enabled = cbxTenLop.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            panelControl1.Enabled = true;
            gIAOVIEN_DANGKYGridControl.Enabled = false;
            cbxTenMonHoc.Enabled = cbxTenLop.Enabled = true;
        }

      

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsGV_DK.CancelEdit();
            if (btnAdd.Enabled == false)
            {
                bdsGV_DK.Position = vitri;
            }
            gIAOVIEN_DANGKYGridControl.Enabled = true;
            panelControl1.Enabled = false;
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            cbxTenMonHoc.Enabled = cbxTenLop.Enabled = true;
            if (vitri > 0)
            {
                bdsGV_DK.Position = vitri;
            }
        }

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsGV_DK.Position;

            String queryCheckCount = "DECLARE @return_value int \n" +
                   "EXEC @return_value = [dbo].[SP_CBT_CAN_DELETE] \n " +
                   "@malop = N'" + txtMALOP.Text.Trim() + "',\n " +
                   "@mamh = N'" + txtMAMH.Text.Trim() + "',\n " +
                   "@lan = N'" + cbxLan.Text.Trim() + "'\n " +
                   "SELECT 'Return Value' = @return_value";
            int result2 = Program.CheckDataHelper(queryCheckCount);
            if (result2 == -1)
            {
                MessageBox.Show("Giáo viên đã đăng kí cho một lớp thi", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có thật sử muốn xóa giáo viên đăng kí này không?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    bdsGV_DK.RemoveCurrent();
                    this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.GIAOVIEN_DANGKYTableAdapter.Update(this.DS.GIAOVIEN_DANGKY);

                    gIAOVIEN_DANGKYGridControl.Enabled = true;
                    panelControl1.Enabled = false;
                    btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = true;
                    btnGhi.Enabled = btnPhucHoi.Enabled = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa giáo viên đăng ký: " + ex.Message, "", MessageBoxButtons.OK);
                    this.GIAOVIEN_DANGKYTableAdapter.Fill(this.DS.GIAOVIEN_DANGKY);
                    bdsGV_DK.Position = vitri;
                    return;
                }
                if (bdsGV_DK.Count == 0)
                {
                    btnXoa.Enabled = false;
                }
            }
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void gIAOVIEN_DANGKYGridControl_MouseDown(object sender, MouseEventArgs e)
        {

            if (txtTrinhDo.Text == "A")
            {
                cbxTrinhDo.SelectedIndex = 0;
            }
            else if (txtTrinhDo.Text == "B")
            {
                cbxTrinhDo.SelectedIndex = 1;
            }
            else
            {
                cbxTrinhDo.SelectedIndex = 2;
            }
        }
    }
}