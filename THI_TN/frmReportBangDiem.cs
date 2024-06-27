using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
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
    public partial class frmReportBangDiem : DevExpress.XtraEditors.XtraForm
    {
        public frmReportBangDiem()
        {
            InitializeComponent();
        }

       

        private void btnIn_Click(object sender, EventArgs e)
        {
            string malop = cbxLop.SelectedValue.ToString();
            string maMonHoc = cbxMonHoc.SelectedValue.ToString();
            int lan = int.Parse(cbxLan.SelectedValue.ToString());
            rBangDiem rpt = new rBangDiem(malop, maMonHoc, lan);

            ReportPrintTool rptool = new ReportPrintTool(rpt);
            rptool.ShowPreviewDialog();
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmReportBangDiem_Load(object sender, EventArgs e)
        {

            cbxCoSo.DataSource = Program.bds_dspm;
            cbxCoSo.DisplayMember = "TENCOSO";
            cbxCoSo.ValueMember = "TENSERVER";
            Console.WriteLine(Program.mChiNhanh);
            cbxCoSo.SelectedIndex = Program.mChiNhanh;

            if (Program.mGroup == "CoSo")
            {
                cbxCoSo.Enabled = false;
            }
            else if (Program.mGroup == "Truong")
            {
                cbxCoSo.Enabled = true;
            }
            loadComboboxLop();
        }

        private void loadComboboxLop()
            
        {
            DataTable dt = new DataTable();
            string cmd = "SELECT * FROM [dbo].[GET_LOP_CO_BANGDIEM]";
            dt = Program.ExecSqlQuery(cmd);
            BindingSource bdsLop = new BindingSource();
            bdsLop.DataSource = dt;
            cbxLop.DataSource = bdsLop;
            cbxLop.DisplayMember = "TENLOP";
            cbxLop.ValueMember = "MALOP";

            if (cbxLop.SelectedValue != null)
            {
                string malop = cbxLop.SelectedValue.ToString();
                loadComboboxMonHoc(malop);
            }
        }

        private void cbxLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(cbxLop.SelectedValue.ToString());
            loadComboboxMonHoc(cbxLop.SelectedValue.ToString());
        }

        private void loadComboboxMonHoc(string malop)
        {
            DataTable dt = new DataTable();
            string cmd = "EXEC [dbo].[SP_REPORT_BANGDIEM_MH_GET_MONHOC] '" + malop + "'";
            dt = Program.ExecSqlQuery(cmd);

            BindingSource bdsMonHoc = new BindingSource();
            bdsMonHoc.DataSource = dt;
            cbxMonHoc.DataSource = bdsMonHoc;
            cbxMonHoc.DisplayMember = "TENMH";
            cbxMonHoc.ValueMember = "MAMH";

           if (cbxMonHoc.SelectedValue != null)
            {
                loadComboxboxLan();
            }
        }

        private void loadComboxboxLan()
        {
            string malop = cbxLop.SelectedValue.ToString();
            string mamh = cbxMonHoc.SelectedValue.ToString();
            DataTable dt = new DataTable();
            string cmd = "EXEC [dbo].[SP_REPORT_BANGDIEM_MH_GET_LAN] '" + malop + "', '" + mamh +  "'";
            dt = Program.ExecSqlQuery(cmd);

            BindingSource bdsLan = new BindingSource();
            bdsLan.DataSource = dt;
            cbxLan.DataSource = bdsLan;
            cbxLan.DisplayMember = "LAN";
            cbxLan.ValueMember = "LAN";
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
                loadComboboxLop();
            }
        }
    }


}