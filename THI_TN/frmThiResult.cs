using DevExpress.XtraEditors;
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
    public partial class frmThiResult : DevExpress.XtraEditors.XtraForm
    {
        private ResultExam result; 
        public frmThiResult(ResultExam result)
        {
            InitializeComponent();
            this.result = result;
        }

        private void frmThiResult_Load(object sender, EventArgs e)
        {
            txtHoten.Text = Program.mHoten;
            txtLan.Text = result.lan + "";
            txtNgayThi.Text = result.ngayThi.ToString();
            txtMonHoc.Text = result.tenMh;
            lb_diemthi.Text = result.diem.ToString();
        }



        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void txtMonHoc_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}