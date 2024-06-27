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
    public partial class frmReportXemDSKDK : DevExpress.XtraEditors.XtraForm
    {
        public frmReportXemDSKDK()
        {
            InitializeComponent();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string from = txtFrom.Text.ToString();
            string to = txtTo.Text.ToString();

          
            if (from != "" && to != "")
            {
                rXemDSDK rpt = new rXemDSDK(from, to);
                rpt.lbFrom.Text = from;
                rpt.lbTo.Text = to;
                ReportPrintTool rptool = new ReportPrintTool(rpt);
                rptool.ShowPreviewDialog();
            }
        }
    }
}