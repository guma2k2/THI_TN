using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace THI_TN
{
    public partial class rBangDiem : DevExpress.XtraReports.UI.XtraReport
    {

        public rBangDiem()
        {
            InitializeComponent();
        }

        public rBangDiem(string malop, string maMonHoc, int lan)
        {

            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = malop;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = maMonHoc;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = lan;
            this.sqlDataSource1.Fill();
        }
    }
}
