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
    public partial class frmNhapDe : DevExpress.XtraEditors.XtraForm
    {
        private int vitri = 0;
        private string flagOptionNhapDe;
        public frmNhapDe()
        {
            InitializeComponent();
        }

      
        private void frmNhapDe_Load(object sender, EventArgs e)
        {

            DS.EnforceConstraints = false;
            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.MONHOCTableAdapter.Fill(this.DS.MONHOC);

            this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
            this.BODETableAdapter.Fill(this.DS.BODE);

            cbxMonHoc.DataSource = bdsMonHoc;
            cbxMonHoc.DisplayMember = "TENMH";
            cbxMonHoc.ValueMember = "MAMH";
            cbxTrinhDo.SelectedIndex = 0;
            txtMAGV.Text = Program.username;
           /* loadBoDe();*/
        }

        private void loadBoDe()
        {
            String maGV = Program.username;
            String sql = "EXEC [dbo].[SP_GET_BODE_BY_GV] '" + maGV + "'";
            DataTable tableBoDe = Program.ExecSqlQuery(sql);
            this.bdsBoDe.DataSource = tableBoDe;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValicateBoDe() == true)
            {
                try
                {
                    bdsBoDe.EndEdit();
                    bdsBoDe.ResetCurrentItem();
                    this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
                    this.BODETableAdapter.Update(this.DS.BODE);
                    /* sINHVIENGridControl.Enabled = true;*/
                    /* btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                     btnGhi.Enabled = btnPhucHoi.Enabled = false;*/
                }
                catch (SqlException ex)
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

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsBoDe.Position;
            flagOptionNhapDe = "ADD";
            cbxMonHoc.Focus();
            bdsBoDe.AddNew();
            txtMAMH.Text = cbxMonHoc.ValueMember ;
            txtMAGV.Text = Program.username;
/*
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;*/
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsBoDe.Position;
            flagOptionNhapDe = "UPDATE";


           /* btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = false;
            btnGhi.Enabled = true;*/
        }

       

        private bool ValicateBoDe()
        {

            if (txtNoiDung.Text.Trim() == "")
            {
                MessageBox.Show("Ma sinh vien khong dc bo trong", "", MessageBoxButtons.OK);
                txtNoiDung.Focus();
                return false;
            }


            if (txtTrinhDo.Text.Trim() == "")
            {
                MessageBox.Show("Ten lop khong dc bo trong", "", MessageBoxButtons.OK);
                txtTrinhDo.Focus();
                return false;
            }


            if (txtA.Text.Trim() == "")
            {
                MessageBox.Show("Mat khau khong dc bo trong", "", MessageBoxButtons.OK);
                txtA.Focus();
                return false;
            }

            if (txtB.Text.Trim() == "")
            {
                MessageBox.Show("Ten lop khong dc bo trong", "", MessageBoxButtons.OK);
                txtB.Focus();
                return false;
            }

            if (txtC.Text.Trim() == "")
            {
                MessageBox.Show("Ten lop khong dc bo trong", "", MessageBoxButtons.OK);
                txtC.Focus();
                return false;
            }

            if (txtD.Text.Trim() == "")
            {
                MessageBox.Show("Ten lop khong dc bo trong", "", MessageBoxButtons.OK);
                txtD.Focus();
                return false;
            }

            if (txtDapAn.Text.Trim() == "" && (txtDapAn.Text.Trim() != "A" && txtDapAn.Text.Trim() != "B" && txtDapAn.Text.Trim() != "C" && txtDapAn.Text.Trim() != "D"))
            {
                MessageBox.Show("Dap an khong duoc bo trong va khac A B C D", "", MessageBoxButtons.OK);
                txtD.Focus();
                return false;
            }
            return true;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.MONHOCTableAdapter.Fill(this.DS.MONHOC);
                bdsMonHoc.DataSource = Program.connstr;
                cbxMonHoc.DataSource = bdsMonHoc;
                cbxMonHoc.DisplayMember = "TENMH";
                cbxMonHoc.ValueMember = "MAMH";
                txtMAGV.Text = Program.username;
                loadBoDe();
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

        private void cbxTrinhDo_SelectedIndexChanged(object sender, EventArgs e)
        {

            Console.WriteLine(cbxMonHoc.SelectedIndex);
            if (cbxTrinhDo.SelectedIndex == 0)
            {
                txtTrinhDo.Text = "A";
            } else if (cbxTrinhDo.SelectedIndex == 1)
            {
                txtTrinhDo.Text = "B";
            } else
            {
                txtTrinhDo.Text = "C";
            }
            
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsBoDe.CancelEdit();
            if (btnAdd.Enabled == false) bdsBoDe.Position = vitri;
            panelControl2.Enabled = true;
            btnAdd.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            frmNhapDe_Load(sender, e);
            if (vitri > 0)
            {
                bdsBoDe.Position = vitri;
            }
        }
    }
}