using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Utils.HashCodeHelper;

namespace THI_TN
{
    public partial class frmReportXemKQ : DevExpress.XtraEditors.XtraForm
    {
        public frmReportXemKQ()
        {
            InitializeComponent();
        }
        string tenLop;
        string ngayThi;


        private void frmReportXemKQ_Load(object sender, EventArgs e)
        {
            this.DS.EnforceConstraints = false;


            this.LOPTableAdapter.Fill(this.DS.LOP);
            this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);


            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;

            cbxCoSo.DataSource = Program.bds_dspm;
            cbxCoSo.DisplayMember = "TENCOSO";
            cbxCoSo.ValueMember = "TENSERVER";
            Console.WriteLine(Program.mChiNhanh);
            cbxCoSo.SelectedIndex = Program.mChiNhanh;




            cbxLop.DataSource = bdsLop;
            cbxLop.DisplayMember = "TENLOP";
            cbxLop.ValueMember = "MALOP";


            if (Program.mGroup == "CoSo" || Program.mGroup == "Truong")
            {
                cbxCoSo.Enabled = false;
                if (cbxSinhVien.SelectedValue != null)
                {
                    txtMasv.Text = cbxSinhVien.SelectedValue.ToString();
                }
                loadComboboxSinhVien();
            } else if (Program.mGroup == "Truong")
            {
                cbxCoSo.Enabled = true;
                if (cbxSinhVien.SelectedValue != null)
                {
                    txtMasv.Text = cbxSinhVien.SelectedValue.ToString();
                }
               
                loadComboboxSinhVien();
            } else if (Program.mGroup == "Sinhvien")
            {
                txtMasv.Text = Program.username;
                cbxSinhVien.Text = Program.mHoten;
                cbxCoSo.Enabled = false;
                cbxLop.Enabled= false;
                cbxSinhVien.Enabled = false;
                loadInfoClass();
                loadComboboxSinhVien();
            }
            

        }
        private void loadComboboxSinhVien()
        {
            if (cbxLop.SelectedValue != null) {
                string malop = cbxLop.SelectedValue.ToString();
                DataTable dt = new DataTable();
                string cmd = "EXEC [dbo].[SP_REPORT_XEM_KQ_GET_SV] '" + malop + "'";
                dt = Program.ExecSqlQuery(cmd);

                BindingSource bdsSinhVien = new BindingSource();
                bdsSinhVien.DataSource = dt;
                cbxSinhVien.DataSource = bdsSinhVien;
                cbxSinhVien.ValueMember = "MASV";
                cbxSinhVien.DisplayMember = "HOTEN";
                loadComboboxMonHoc();
            }
            
        }

        private void loadComboboxMonHoc()
        {
            if (cbxSinhVien.SelectedValue != null)
            {
                string masv = txtMasv.Text.Trim();
                DataTable dt = new DataTable();
                string cmd = "EXEC [dbo].[SP_REPORT_XEM_KQ_GET_MONHOC] '" + masv + "'";
                dt = Program.ExecSqlQuery(cmd);

                BindingSource bdsMonHoc = new BindingSource();
                bdsMonHoc.DataSource = dt;
                cbxMonHoc.DataSource = bdsMonHoc;
                cbxMonHoc.DisplayMember = "TENMH";
                cbxMonHoc.ValueMember = "MAMH";

                loadComboboxLanThi();
            }
        }

        private void loadComboboxLanThi()
        {
            if (cbxMonHoc.SelectedValue != null && cbxSinhVien.SelectedValue != null)
            {
                string mamh = cbxMonHoc.SelectedValue.ToString();
                string masv = cbxSinhVien.SelectedValue.ToString();

                DataTable dt = new DataTable();
                string cmd = "EXEC [dbo].[SP_REPORT_XEM_KQ_GET_LAN] '" + masv + "', '" + mamh  + "'";
                dt = Program.ExecSqlQuery(cmd);

                BindingSource bdsLan = new BindingSource();
                bdsLan.DataSource = dt;
                cbxLan.DataSource = bdsLan;
                cbxLan.DisplayMember = "LAN";
                cbxLan.ValueMember = "LAN";
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string masv = txtMasv.Text.Trim();
            string mamh = cbxMonHoc.SelectedValue.ToString();

            int lan = 0;
           if (cbxLan.SelectedValue != null)
            {
                lan = int.Parse(cbxLan.SelectedValue.ToString());
            }

            loadInfoBangDiem(mamh, lan);
            if (ngayThi != "" && tenLop != "")
            {
                rXemKQ rpt = new rXemKQ(masv, mamh, lan);
                rpt.lbHoTen.Text = Program.mHoten;
                rpt.lbLan.Text = lan.ToString();
                rpt.lbLop.Text = tenLop;
                rpt.lbMonHoc.Text = cbxMonHoc.Text;
                rpt.lbNgayThi.Text = ngayThi;
                ReportPrintTool rptool = new ReportPrintTool(rpt);
                rptool.ShowPreviewDialog();
            }
        }
        private void loadInfoBangDiem(string mamh, int lan)
        {

            string masv = txtMasv.Text.Trim();
            string sql = "EXEC dbo.SP_REPORT_XEM_KQ_GET_INFO_BANGDIEM '" + masv + "', '" + mamh + "', '" + lan + "' ";
            Program.myReader = Program.ExecSqlDataReader(sql);
            if (Program.myReader == null)
            {
                throw new Exception("Class not found");
            }
            Program.myReader.Read();
            if (!Program.myReader.HasRows)
            {
                ngayThi = "";
                tenLop = "";
            }
            ngayThi = Program.myReader.GetDateTime(0).ToString();
            tenLop = Program.myReader.GetString(1);

            Program.myReader.Close();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLop.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void cbxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMonHoc.SelectedValue.ToString() != "")
            {
                loadComboboxLanThi();
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
                frmReportXemKQ_Load(sender, e);
            }
        }

        private void cbxSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSinhVien.SelectedValue != null)
            {
                txtMasv.Text = cbxSinhVien.SelectedValue.ToString();
                loadComboboxMonHoc();
            }
        }

        private void cbxLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLop.SelectedValue != null)
            {
                loadComboboxSinhVien();
            }
        }

        private void loadInfoClass()
        {
            if (Program.KetNoi() == 0) return ;
            string masv = Program.username;
            string sql = "EXEC dbo.SP_THI_GET_LOPHOC_BY_SV '" + masv + "'";
            Program.myReader = Program.ExecSqlDataReader(sql);
            if (Program.myReader == null)
            {
                throw new Exception("Class not found");
            }
            Program.myReader.Read();
            /*string malop = Program.myReader.GetString(0);*/
            string tenLop = Program.myReader.GetString(1);
            Console.WriteLine(tenLop);
            cbxLop.Text = tenLop;
            Program.myReader.Close();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}