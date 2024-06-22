using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace THI_TN
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Ma.Text = this.Ma.Text + ": " +  Program.username;
            this.NHOM.Text = this.NHOM.Text + ": " + Program.mGroup;
            this.HOTEN.Text = this.HOTEN.Text + ": " + Program.mHoten;

            if (Program.mGroup == "Sinhvien")
            {
                barButtonItem1.Enabled = false;
                btnKhoaLop.Enabled = false;
                btnSinhVien.Enabled = false;
                btnGiaoVien.Enabled = false;
                btnDeThi.Enabled = false;
                btnThi.Enabled = true;
                btnDkiThi.Enabled = false;
            }else if (Program.mGroup == "GV")
            {

            }else if (Program.mGroup == "Truong")
            {

            } 
        }
        private Form CheckExistForm(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }
            return null;
        }
        // btn sinh vien 
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExistForm(typeof(frmSinhVien));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmSinhVien f = new frmSinhVien();
                f.MdiParent = this;
                f.Show();
            }
        }
        // btn giao vien

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExistForm(typeof(frmGiaoVien));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmGiaoVien f = new frmGiaoVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        // btn Mon hoc
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExistForm(typeof(frmMonHoc));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmMonHoc f = new frmMonHoc();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnKhoaLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExistForm(typeof(frmKhoaLop));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmKhoaLop f = new frmKhoaLop();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDeThi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExistForm(typeof(frmBoDe));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmBoDe f = new frmBoDe();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDkiThi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExistForm(typeof(frmChuanBiThi));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmChuanBiThi f = new frmChuanBiThi();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnThi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExistForm(typeof(frmThiBegin));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmThiBegin f = new frmThiBegin();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnXemKQ_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExistForm(typeof(frmReportXemKQ));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmReportXemKQ f = new frmReportXemKQ();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnBangDiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExistForm(typeof(frmReportBangDiem));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmReportBangDiem f = new frmReportBangDiem();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTaoTk_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExistForm(typeof(frmTaiKhoanTao));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmTaiKhoanTao f = new frmTaiKhoanTao();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnXoaTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExistForm(typeof(frmTaiKhoanXoa2));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmTaiKhoanXoa2 f = new frmTaiKhoanXoa2();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnThiThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExistForm(typeof(frmBeginThiThu));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmBeginThiThu f = new frmBeginThiThu();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}
