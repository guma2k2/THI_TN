namespace THI_TN
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Ma = new System.Windows.Forms.ToolStripStatusLabel();
            this.HOTEN = new System.Windows.Forms.ToolStripStatusLabel();
            this.NHOM = new System.Windows.Forms.ToolStripStatusLabel();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.btnMonHoc = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnMH = new DevExpress.XtraBars.BarButtonItem();
            this.btnKhoaLop = new DevExpress.XtraBars.BarButtonItem();
            this.btnSinhVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnGiaoVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeThi = new DevExpress.XtraBars.BarButtonItem();
            this.btnDkiThi = new DevExpress.XtraBars.BarButtonItem();
            this.btnThi = new DevExpress.XtraBars.BarButtonItem();
            this.btnThiThu = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnXemKQ = new DevExpress.XtraBars.BarButtonItem();
            this.btnBangDiem = new DevExpress.XtraBars.BarButtonItem();
            this.btnDanhSachDK = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaoTk = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoaTaiKhoan = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ma,
            this.HOTEN,
            this.NHOM});
            this.statusStrip1.Location = new System.Drawing.Point(0, 683);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(992, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Ma
            // 
            this.Ma.Name = "Ma";
            this.Ma.Size = new System.Drawing.Size(30, 20);
            this.Ma.Text = "Mã";
            // 
            // HOTEN
            // 
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.Size = new System.Drawing.Size(54, 20);
            this.HOTEN.Text = "Họ tên";
            // 
            // NHOM
            // 
            this.NHOM.Name = "NHOM";
            this.NHOM.Size = new System.Drawing.Size(50, 20);
            this.NHOM.Text = "Nhóm";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.btnMonHoc});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Quản trị";
            // 
            // btnMonHoc
            // 
            this.btnMonHoc.ItemLinks.Add(this.btnMH);
            this.btnMonHoc.ItemLinks.Add(this.btnKhoaLop);
            this.btnMonHoc.ItemLinks.Add(this.btnSinhVien);
            this.btnMonHoc.ItemLinks.Add(this.btnGiaoVien);
            this.btnMonHoc.ItemLinks.Add(this.btnDeThi);
            this.btnMonHoc.ItemLinks.Add(this.btnDkiThi);
            this.btnMonHoc.ItemLinks.Add(this.btnThi);
            this.btnMonHoc.ItemLinks.Add(this.btnThiThu);
            this.btnMonHoc.Name = "btnMonHoc";
            // 
            // btnMH
            // 
            this.btnMH.Caption = "Môn học";
            this.btnMH.Id = 1;
            this.btnMH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMH.ImageOptions.Image")));
            this.btnMH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMH.ImageOptions.LargeImage")));
            this.btnMH.Name = "btnMH";
            this.btnMH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnKhoaLop
            // 
            this.btnKhoaLop.Caption = "Khoa/Lớp";
            this.btnKhoaLop.Id = 2;
            this.btnKhoaLop.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKhoaLop.ImageOptions.Image")));
            this.btnKhoaLop.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnKhoaLop.ImageOptions.LargeImage")));
            this.btnKhoaLop.Name = "btnKhoaLop";
            this.btnKhoaLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKhoaLop_ItemClick);
            // 
            // btnSinhVien
            // 
            this.btnSinhVien.Caption = "Sinh viên";
            this.btnSinhVien.Id = 3;
            this.btnSinhVien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSinhVien.ImageOptions.Image")));
            this.btnSinhVien.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSinhVien.ImageOptions.LargeImage")));
            this.btnSinhVien.Name = "btnSinhVien";
            this.btnSinhVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // btnGiaoVien
            // 
            this.btnGiaoVien.Caption = "Giáo viên";
            this.btnGiaoVien.Id = 4;
            this.btnGiaoVien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGiaoVien.ImageOptions.Image")));
            this.btnGiaoVien.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGiaoVien.ImageOptions.LargeImage")));
            this.btnGiaoVien.Name = "btnGiaoVien";
            this.btnGiaoVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick_1);
            // 
            // btnDeThi
            // 
            this.btnDeThi.Caption = "Đề thi";
            this.btnDeThi.Id = 5;
            this.btnDeThi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeThi.ImageOptions.Image")));
            this.btnDeThi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDeThi.ImageOptions.LargeImage")));
            this.btnDeThi.Name = "btnDeThi";
            this.btnDeThi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeThi_ItemClick);
            // 
            // btnDkiThi
            // 
            this.btnDkiThi.Caption = "Đăng kí thi";
            this.btnDkiThi.Id = 6;
            this.btnDkiThi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDkiThi.ImageOptions.Image")));
            this.btnDkiThi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDkiThi.ImageOptions.LargeImage")));
            this.btnDkiThi.Name = "btnDkiThi";
            this.btnDkiThi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDkiThi_ItemClick);
            // 
            // btnThi
            // 
            this.btnThi.Caption = "Thi";
            this.btnThi.Id = 7;
            this.btnThi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThi.ImageOptions.Image")));
            this.btnThi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThi.ImageOptions.LargeImage")));
            this.btnThi.Name = "btnThi";
            this.btnThi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThi_ItemClick);
            // 
            // btnThiThu
            // 
            this.btnThiThu.Caption = "Thi thử";
            this.btnThiThu.Id = 13;
            this.btnThiThu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThiThu.ImageOptions.Image")));
            this.btnThiThu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThiThu.ImageOptions.LargeImage")));
            this.btnThiThu.Name = "btnThiThu";
            this.btnThiThu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThiThu_ItemClick);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(44, 46, 44, 46);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnMH,
            this.btnKhoaLop,
            this.btnSinhVien,
            this.btnGiaoVien,
            this.btnDeThi,
            this.btnDkiThi,
            this.btnThi,
            this.btnXemKQ,
            this.btnBangDiem,
            this.btnDanhSachDK,
            this.btnTaoTk,
            this.btnXoaTaiKhoan,
            this.btnThiThu});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(5);
            this.ribbonControl1.MaxItemId = 14;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 481;
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbonControl1.Size = new System.Drawing.Size(992, 193);
            // 
            // btnXemKQ
            // 
            this.btnXemKQ.Caption = "Xem kết quả";
            this.btnXemKQ.Id = 8;
            this.btnXemKQ.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXemKQ.ImageOptions.Image")));
            this.btnXemKQ.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXemKQ.ImageOptions.LargeImage")));
            this.btnXemKQ.Name = "btnXemKQ";
            this.btnXemKQ.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXemKQ_ItemClick);
            // 
            // btnBangDiem
            // 
            this.btnBangDiem.Caption = "Bảng điểm";
            this.btnBangDiem.Id = 9;
            this.btnBangDiem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBangDiem.ImageOptions.Image")));
            this.btnBangDiem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBangDiem.ImageOptions.LargeImage")));
            this.btnBangDiem.Name = "btnBangDiem";
            this.btnBangDiem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBangDiem_ItemClick);
            // 
            // btnDanhSachDK
            // 
            this.btnDanhSachDK.Caption = "Danh sách đăng kí";
            this.btnDanhSachDK.Id = 10;
            this.btnDanhSachDK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhSachDK.ImageOptions.Image")));
            this.btnDanhSachDK.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDanhSachDK.ImageOptions.LargeImage")));
            this.btnDanhSachDK.Name = "btnDanhSachDK";
            this.btnDanhSachDK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDanhSachDK_ItemClick);
            // 
            // btnTaoTk
            // 
            this.btnTaoTk.Caption = "Tạo tài khoản";
            this.btnTaoTk.Id = 11;
            this.btnTaoTk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoTk.ImageOptions.Image")));
            this.btnTaoTk.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTaoTk.ImageOptions.LargeImage")));
            this.btnTaoTk.Name = "btnTaoTk";
            this.btnTaoTk.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaoTk_ItemClick);
            // 
            // btnXoaTaiKhoan
            // 
            this.btnXoaTaiKhoan.Caption = "Xóa tài khoản";
            this.btnXoaTaiKhoan.Id = 12;
            this.btnXoaTaiKhoan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaTaiKhoan.ImageOptions.Image")));
            this.btnXoaTaiKhoan.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXoaTaiKhoan.ImageOptions.LargeImage")));
            this.btnXoaTaiKhoan.Name = "btnXoaTaiKhoan";
            this.btnXoaTaiKhoan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoaTaiKhoan_ItemClick);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Báo cáo";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnXemKQ);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnBangDiem);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDanhSachDK);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Tài khoản";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnTaoTk);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnXoaTaiKhoan);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 709);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Ma;
        private System.Windows.Forms.ToolStripStatusLabel HOTEN;
        private System.Windows.Forms.ToolStripStatusLabel NHOM;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup btnMonHoc;
        private DevExpress.XtraBars.BarButtonItem btnMH;
        private DevExpress.XtraBars.BarButtonItem btnKhoaLop;
        private DevExpress.XtraBars.BarButtonItem btnSinhVien;
        private DevExpress.XtraBars.BarButtonItem btnGiaoVien;
        private DevExpress.XtraBars.BarButtonItem btnDeThi;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnDkiThi;
        private DevExpress.XtraBars.BarButtonItem btnThi;
        private DevExpress.XtraBars.BarButtonItem btnXemKQ;
        private DevExpress.XtraBars.BarButtonItem btnBangDiem;
        private DevExpress.XtraBars.BarButtonItem btnDanhSachDK;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnTaoTk;
        private DevExpress.XtraBars.BarButtonItem btnXoaTaiKhoan;
        private DevExpress.XtraBars.BarButtonItem btnThiThu;
    }
}

