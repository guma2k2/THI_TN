using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmBoDe : DevExpress.XtraEditors.XtraForm
    {
        public frmBoDe()
        {
            InitializeComponent();
        }
        private int vitri;
        private string flagOptionNhapDe;
        private void frmBoDe_Load(object sender, EventArgs e)
        {
            
            DS.EnforceConstraints = false;
            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.MONHOCTableAdapter.Fill(this.DS.MONHOC);

            this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
            this.BODETableAdapter.Fill(this.DS.BODE);


            this.CT_BAITHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.CT_BAITHITableAdapter.Fill(this.DS.CT_BAITHI);

            cbxMonHoc.DataSource = bdsMonHoc;
            cbxMonHoc.DisplayMember = "TENMH";
            cbxMonHoc.ValueMember = "MAMH";
            txtMAGV.Text = Program.username;
            if (Program.mGroup == "GV")
            {
                loadBoDe();
            }else if (Program.mGroup == "Truong")
            {
                disableEditBoDe();
            }
            btnPhucHoi.Enabled = btnGhi.Enabled = false;
            loadCbxTrinhDo();
            loadCbxDapAn();
        }

        private void disableEditBoDe()
        {

            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            panelControl2.Enabled = false;
            bODEGridControl.Enabled = true;
        }
        private void loadBoDe()
        {
            String maGV = Program.username;
            String sql = "EXEC [dbo].[SP_GET_BODE_BY_GV] '" + maGV + "'";
            DataTable tableBoDe = Program.ExecSqlQuery(sql);
            this.bdsBoDe.DataSource = tableBoDe;
           /* this.gridBoDe.DataSource = this.bdsBoDe;*/
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsBoDe.Position;
            flagOptionNhapDe = "ADD";
            cbxMonHoc.Focus();
            bdsBoDe.AddNew();
            txtMAMH.Text = cbxMonHoc.SelectedValue.ToString();
            txtMAGV.Text = Program.username;
            cbxTrinhDo.SelectedIndex = 0;
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            panelControl2.Enabled = true;
            bODEGridControl.Enabled = false;
            txtCauHoi.Text = getMaxValueCauHoi() + "";
        }

        private int getMaxValueCauHoi ()
        {
            int maxValue = 0;
            for (int i = 0; i < gridBoDe.RowCount; i++)
            {
                int value = Convert.ToInt32(gridBoDe.GetRowCellValue(i, "CAUHOI"));
                if (value > maxValue)
                {
                    maxValue = value;
                }
            }
            return maxValue + 1;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsBoDe.Position;
            flagOptionNhapDe = "UPDATE";


            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            panelControl2.Enabled = true;
            bODEGridControl.Enabled = false;

        }
        private bool ValicateBoDe()
        {

            if (txtNoiDung.Text.Trim() == "")
            {
                MessageBox.Show("Nội dung câu hỏi không được bỏ trống", "", MessageBoxButtons.OK);
                txtNoiDung.Focus();
                return false;
            }


            if (txtTrinhDo.Text.Trim() == "")
            {
                MessageBox.Show("Trình độ không được bỏ trống", "", MessageBoxButtons.OK);
                txtTrinhDo.Focus();
                return false;
            }


            if (txtA.Text.Trim() == "")
            {
                MessageBox.Show("Câu trả lời A không được bỏ trống", "", MessageBoxButtons.OK);
                txtA.Focus();
                return false;
            }

            if (txtB.Text.Trim() == "")
            {
                MessageBox.Show("Câu trả lời B không được bỏ trống", "", MessageBoxButtons.OK);
                txtB.Focus();
                return false;
            }

            if (txtC.Text.Trim() == "")
            {
                MessageBox.Show("Câu trả lời C không được bỏ trống", "", MessageBoxButtons.OK);
                txtC.Focus();
                return false;
            }

            if (txtD.Text.Trim() == "")
            {
                MessageBox.Show("Câu trả lời D không được bỏ trống", "", MessageBoxButtons.OK);
                txtD.Focus();
                return false;
            }

            if (txtDapAn.Text.Trim() == "" && (txtDapAn.Text.Trim() != "A" && txtDapAn.Text.Trim() != "B" && txtDapAn.Text.Trim() != "C" && txtDapAn.Text.Trim() != "D"))
            {
                MessageBox.Show("Đáp án không được bỏ trống và khác A B C D", "", MessageBoxButtons.OK);
                txtD.Focus();
                return false;
            }
            return true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValicateBoDe() == true)
            {
                if (MessageBox.Show("Bạn có thật sự muốn ghi bộ đề này không?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        bdsBoDe.EndEdit();
                        bdsBoDe.ResetCurrentItem();
                        this.bdsBoDe.DataSource = this.DS.BODE;
                        this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
                        this.BODETableAdapter.Update(this.DS.BODE);



                        btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = true;
                        btnGhi.Enabled = btnPhucHoi.Enabled = false;
                        panelControl2.Enabled = false;
                        bODEGridControl.Enabled = true;
                    }
                    catch (SqlException ex)
                    {
                        Console.Write(ex.ToString());
                        MessageBox.Show("Lỗi ghi bộ đề", ex.Message, MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maBode = "";

            if (bdsCTBAITHI.Count > 0)
            {
                MessageBox.Show("Bộ đề này đã được cho thi", "", MessageBoxButtons.OK);
                return;
            } 
            if (MessageBox.Show("Bạn có thật sự muốn xóa bộ đề này không?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    maBode = ((DataRowView)bdsBoDe[bdsBoDe.Position])["CAUHOI"].ToString();
                    bdsBoDe.RemoveCurrent();
                    this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
                    this.BODETableAdapter.Update(this.DS.BODE);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi xoa bo de: " + ex.Message, "", MessageBoxButtons.OK);
                    this.BODETableAdapter.Fill(this.DS.BODE);
                    bdsBoDe.Position = bdsBoDe.Find("CAUHOI", maBode);
                    return;
                }
                if (bdsBoDe.Count == 0)
                {
                    btnXoa.Enabled = false;
                }
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsBoDe.CancelEdit();
            if (btnAdd.Enabled == false) bdsBoDe.Position = vitri;
            bODEGridControl.Enabled = true;
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            if (vitri > 0)
            {
                bdsBoDe.Position = vitri;
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
                this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.MONHOCTableAdapter.Fill(this.DS.MONHOC);

                this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
                this.BODETableAdapter.Fill(this.DS.BODE);
                if (Program.mGroup == "GV")
                {
                    loadBoDe();
                }
                txtMAGV.Text = Program.username;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi reload " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void cbxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMonHoc.SelectedValue != null)
            {
                txtMAMH.Text = cbxMonHoc.SelectedValue.ToString();
            }
        }

        private void bLabel_Click(object sender, EventArgs e)
        {

        }

        private void cbxMonHoc_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbxMonHoc.SelectedValue != null)
            {
                txtMAMH.Text = cbxMonHoc.SelectedValue.ToString();
            }
        }

        private void cbxTrinhDo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
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


        private void loadCbxTrinhDo(object sender, MouseEventArgs e)
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



            if (txtDapAn.Text == "A")
            {
                cbxDapAn.SelectedIndex = 0;
            }
            else if (txtDapAn.Text == "B")
            {
                cbxDapAn.SelectedIndex = 1;
            }
            else if (txtDapAn.Text == "C")
            {
                cbxDapAn.SelectedIndex = 2;
            }
            else
            {
                cbxDapAn.SelectedIndex = 3;
            }
        }

        private void loadCbxTrinhDo( )
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

        private void cbxDapAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDapAn.SelectedIndex == 0)
            {
                txtDapAn.Text = "A";
            }
            else if (cbxDapAn.SelectedIndex == 1)
            {
                txtDapAn.Text = "B";
            }
            else if (cbxDapAn.SelectedIndex == 2)
            {
                txtDapAn.Text = "C";
            }
            else
            {
                txtDapAn.Text = "D";
            }
        }

        private void loadCbxDapAn()
        {
            if (txtDapAn.Text == "A")
            {
                cbxDapAn.SelectedIndex = 0;
            }
            else if (txtDapAn.Text == "B")
            {
                cbxDapAn.SelectedIndex = 1;
            }
            else if (txtDapAn.Text == "C")
            {
                cbxDapAn.SelectedIndex = 2;
            }
            else
            {
                cbxDapAn.SelectedIndex = 3;
            }
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
/*if (txtTrinhDo.Text == "A")
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
}*/