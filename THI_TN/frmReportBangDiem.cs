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
            int lan = int.Parse(txtLan.Text.ToString());
            rBangDiem rpt = new rBangDiem(malop, maMonHoc, lan);
            ReportPrintTool rptool = new ReportPrintTool(rpt);
            rptool.ShowPreviewDialog();
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmReportBangDiem_Load(object sender, EventArgs e)
        {
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
        }
    }


}