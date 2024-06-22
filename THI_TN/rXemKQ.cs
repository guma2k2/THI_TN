using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace THI_TN
{
    public partial class rXemKQ : DevExpress.XtraReports.UI.XtraReport
    {
        public rXemKQ()
        {
            InitializeComponent();
        }

        public rXemKQ(string masv, string mamh, int lan)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = masv;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = mamh;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = lan;
            this.sqlDataSource1.Fill();
        }

        private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            string cacluachon = (string)GetCurrentColumnValue("CACLUACHON");
            string newText = cacluachon.Replace("\n", Environment.NewLine);
            label.Text = newText;
        }

        private void tableCell9_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        private void tableCell8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
