using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace THI_TN
{
    public partial class rXemDSDK : DevExpress.XtraReports.UI.XtraReport
    {
        public rXemDSDK()
        {
            InitializeComponent();
        }
        public rXemDSDK(String from, String to)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = from;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = to;
            this.sqlDataSource1.Fill();
        }
    }
}
