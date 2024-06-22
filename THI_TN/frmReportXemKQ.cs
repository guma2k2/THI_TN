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
            loadComboboxMonHoc();
            cbxMonHoc.SelectedIndex = 0;    

        }

        private void loadComboboxMonHoc()
        {
            DataTable dt = new DataTable();
            string cmd = "EXEC [dbo].[SP_REPORT_XEM_KQ_GET_MONHOC] '" + Program.username + "'";
            dt = Program.ExecSqlQuery(cmd);

            BindingSource bdsMonHoc = new BindingSource();
            bdsMonHoc.DataSource = dt;
            cbxMonHoc.DataSource = bdsMonHoc;
            cbxMonHoc.DisplayMember = "TENMH";
            cbxMonHoc.ValueMember = "MAMH";
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string masv = Program.username;
            string mamh = cbxMonHoc.SelectedValue.ToString();
            int lan = int.Parse(txtLan.Text.ToString());

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

            string masv = Program.username;
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
    }
}