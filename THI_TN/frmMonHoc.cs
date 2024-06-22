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
    public partial class frmMonHoc : DevExpress.XtraEditors.XtraForm
    {
        public frmMonHoc()
        {
            InitializeComponent();
        }
        private string oldMaMonHoc;
        private string oldTenMonHoc;
        private string flagOptionMonHoc;
        private int vitri = 0;
        // btnAdd
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsMonHoc.Position;
            txtMAMH.Enabled = true;
            flagOptionMonHoc = "ADD";
            bdsMonHoc.AddNew();
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMơi.Enabled = btnThoat.Enabled= false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            panelControl2.Enabled = true;
            mONHOCGridControl.Enabled = false;
        }


        // btn Sua
        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsMonHoc.Position;
            flagOptionMonHoc = "UPDATE";
            oldMaMonHoc = txtMAMH.Text.Trim();
            oldTenMonHoc = txtTenMH.Text.Trim();
            txtMAMH.Enabled = false;
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMơi.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            panelControl2.Enabled = true;
            mONHOCGridControl.Enabled = false;
        }


        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.BANGDIEMTableAdapter.Fill(this.DS.BANGDIEM);
            this.BODETableAdapter.Fill(this.DS.BODE);
            this.GIAOVIEN_DANGKYTableAdapter.Fill(this.DS.GIAOVIEN_DANGKY);
            this.MONHOCTableAdapter.Fill(this.DS.MONHOC);

            this.BANGDIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
            this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;

            panelControl2.Enabled = false;

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }






        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidateMonHoc() == true)
            {
                try
                {
                    bdsMonHoc.EndEdit();
                    bdsMonHoc.ResetCurrentItem();
                    this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.MONHOCTableAdapter.Update(this.DS.MONHOC);


                    btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                    btnGhi.Enabled = btnPhucHoi.Enabled = false;
                    txtMAMH.Enabled = true;
                    /*panelControl1.Enabled = false;*/
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Loi ghi lop hoc", ex.Message, MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private bool ValidateMonHoc()
        {
            if (txtMAMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn học không được bỏ trống", "", MessageBoxButtons.OK);
                txtMAMH.Focus();
                return false;
            }
            if (txtTenMH.Text.Trim() == "")
            {
                MessageBox.Show("Tên môn học không được bỏ trống", "", MessageBoxButtons.OK);
                txtTenMH.Focus();
                return false;
            }

            if (txtMAMH.Text.Length > 5)
            {
                MessageBox.Show("Mã môn học không được vượt quá 5 ký tự", "", MessageBoxButtons.OK);
                txtMAMH.Focus();
                return false;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa môn học này không?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (flagOptionMonHoc == "ADD")
                {

                    String queryCheckMaLop = "DECLARE @return_value int \n" +
                       "EXEC @return_value = [dbo].[SP_CHECKID] \n " +
                       "@Id = N'" + txtMAMH.Text + "',\n " +
                       "@Type = N'MAMONHOC' \n " +
                       "SELECT 'Return Value' = @return_value";

                    int resultMa = Program.CheckDataHelper(queryCheckMaLop);
                    if (resultMa == -1)
                    {
                        XtraMessageBox.Show("Lỗi kết nối database", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultMa == 1)
                    {
                        XtraMessageBox.Show("Mã môn học đã tồn tại", "", MessageBoxButtons.OK);
                        return false;
                    }



                    String queryCheckTenLop = "DECLARE @return_value int \n" +
                        "EXEC @return_value = [dbo].[SP_CHECKNAME] \n " +
                        "@Name = N'" + txtTenMH.Text + "',\n " +
                        "@Type = N'TENMONHOC' \n " +
                        "SELECT 'Return Value' = @return_value";
                    Console.WriteLine(queryCheckTenLop);
                    int resultTen = Program.CheckDataHelper(queryCheckTenLop);
                    Console.WriteLine(resultTen);

                    if (resultTen == -1)
                    {
                        XtraMessageBox.Show("Lỗi kết nối database", "", MessageBoxButtons.OK);
                        return false;
                    }
                    else if (resultTen == 1)
                    {
                        XtraMessageBox.Show("Tên môn học đã tồn tại", "", MessageBoxButtons.OK);
                        return false;
                    }
                }
                if (flagOptionMonHoc == "UPDATE")
                {
                    if (!this.txtMAMH.Text.Trim().ToString().Equals(oldMaMonHoc))
                    {
                        String queryCheckMaLop = "DECLARE @return_value int \n" +
                        "EXEC @return_value = [dbo].[SP_CHECKID] \n " +
                        "@Id = N'" + txtMAMH.Text + "',\n " +
                        "@Type = N'MAMONHOC' \n " +
                        "SELECT 'Return Value' = @return_value";
                        int resultMa = Program.CheckDataHelper(queryCheckMaLop);

                        if (resultMa == -1)
                        {
                            XtraMessageBox.Show("Lỗi kết nối database", "", MessageBoxButtons.OK);
                            return false;
                        }
                        else if (resultMa == 1)
                        {
                            XtraMessageBox.Show("Mã môn học đã tồn tại", "", MessageBoxButtons.OK);
                            return false;
                        }
                    }

                    if (!this.txtTenMH.Text.Trim().ToString().Equals(oldTenMonHoc))
                    {
                        String queryCheckTenLop = "DECLARE @return_value int \n" +
                        "EXEC @return_value = [dbo].[SP_CHECKNAME] \n " +
                        "@Name = N'" + txtTenMH.Text + "',\n " +
                        "@Type = N'TENMONHOC' \n " +
                        "SELECT 'Return Value' = @return_value";
                        int resultTen = Program.CheckDataHelper(queryCheckTenLop);

                        if (resultTen == -1)
                        {
                            XtraMessageBox.Show("Lỗi kết nối database", "", MessageBoxButtons.OK);
                            return false;
                        }
                        else if (resultTen == 1)
                        {
                            XtraMessageBox.Show("Tên môn học đã tồn tại", "", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }
            }



         
            return true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maMonHoc = "";

            if (bdsBangDiem.Count > 0)
            {
                MessageBox.Show("Môn học đã có trong bảng điểm", "", MessageBoxButtons.OK);
                return;
            }

            if (bdsBoDe.Count > 0)
            {
                MessageBox.Show("Môn học đã có trong bộ đề", "", MessageBoxButtons.OK);
                return;
            }

            if (bdsGV.Count > 0)
            {
                MessageBox.Show("Môn học đã được đăng kí thi", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có thật sự muốn xóa môn học này không?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    maMonHoc = ((DataRowView)bdsMonHoc[bdsMonHoc.Position])["MAMH"].ToString();
                    bdsMonHoc.RemoveCurrent();
                    this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.MONHOCTableAdapter.Update(this.DS.MONHOC);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa môn học: " + ex.Message, "", MessageBoxButtons.OK);
                    this.MONHOCTableAdapter.Fill(this.DS.MONHOC);
                    bdsMonHoc.Position = bdsMonHoc.Find("MALOP", maMonHoc);
                    return;
                }
                if (bdsMonHoc.Count == 0)
                {
                    btnXoa.Enabled = false;
                }
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsMonHoc.CancelEdit();
            if (btnAdd.Enabled == false) bdsMonHoc.Position = vitri;
            mONHOCGridControl.Enabled = true;
            panelControl2.Enabled = fa;
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMơi.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            frmMonHoc_Load(sender, e);
            if (vitri > 0)
            {
                bdsMonHoc.Position = vitri;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


        // btn Lam moi 
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.MONHOCTableAdapter.Fill(this.DS.MONHOC);
                btnGhi.Enabled = btnPhucHoi.Enabled = btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                txtMAMH.Enabled = true;
                panelControl2.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi reload " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void txtMAMH_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}