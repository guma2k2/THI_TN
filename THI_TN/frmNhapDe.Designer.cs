namespace THI_TN
{
    partial class frmNhapDe
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label cAUHOILabel;
            System.Windows.Forms.Label mAMHLabel;
            System.Windows.Forms.Label tRINHDOLabel;
            System.Windows.Forms.Label nOIDUNGLabel;
            System.Windows.Forms.Label bLabel;
            System.Windows.Forms.Label aLabel;
            System.Windows.Forms.Label cLabel;
            System.Windows.Forms.Label dLabel;
            System.Windows.Forms.Label dAP_ANLabel;
            System.Windows.Forms.Label mAGVLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapDe));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhucHoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cbxTrinhDo = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cbxMonHoc = new System.Windows.Forms.ComboBox();
            this.txtMAGV = new DevExpress.XtraEditors.TextEdit();
            this.bdsBoDe = new System.Windows.Forms.BindingSource(this.components);
            this.DS = new THI_TN.DS();
            this.txtDapAn = new DevExpress.XtraEditors.TextEdit();
            this.txtD = new DevExpress.XtraEditors.TextEdit();
            this.txtC = new DevExpress.XtraEditors.TextEdit();
            this.txtA = new DevExpress.XtraEditors.TextEdit();
            this.txtB = new DevExpress.XtraEditors.TextEdit();
            this.txtNoiDung = new DevExpress.XtraEditors.TextEdit();
            this.txtTrinhDo = new DevExpress.XtraEditors.TextEdit();
            this.txtMAMH = new DevExpress.XtraEditors.TextEdit();
            this.cAUHOISpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.BODETableAdapter = new THI_TN.DSTableAdapters.BODETableAdapter();
            this.tableAdapterManager = new THI_TN.DSTableAdapters.TableAdapterManager();
            this.MONHOCTableAdapter = new THI_TN.DSTableAdapters.MONHOCTableAdapter();
            this.bdsMonHoc = new System.Windows.Forms.BindingSource(this.components);
            cAUHOILabel = new System.Windows.Forms.Label();
            mAMHLabel = new System.Windows.Forms.Label();
            tRINHDOLabel = new System.Windows.Forms.Label();
            nOIDUNGLabel = new System.Windows.Forms.Label();
            bLabel = new System.Windows.Forms.Label();
            aLabel = new System.Windows.Forms.Label();
            cLabel = new System.Windows.Forms.Label();
            dLabel = new System.Windows.Forms.Label();
            dAP_ANLabel = new System.Windows.Forms.Label();
            mAGVLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMAGV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBoDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDapAn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrinhDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMAMH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAUHOISpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMonHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // cAUHOILabel
            // 
            cAUHOILabel.AutoSize = true;
            cAUHOILabel.Location = new System.Drawing.Point(105, 55);
            cAUHOILabel.Name = "cAUHOILabel";
            cAUHOILabel.Size = new System.Drawing.Size(57, 16);
            cAUHOILabel.TabIndex = 0;
            cAUHOILabel.Text = "CAUHOI:";
            // 
            // mAMHLabel
            // 
            mAMHLabel.AutoSize = true;
            mAMHLabel.Location = new System.Drawing.Point(123, 119);
            mAMHLabel.Name = "mAMHLabel";
            mAMHLabel.Size = new System.Drawing.Size(48, 16);
            mAMHLabel.TabIndex = 2;
            mAMHLabel.Text = "MAMH:";
            // 
            // tRINHDOLabel
            // 
            tRINHDOLabel.AutoSize = true;
            tRINHDOLabel.Location = new System.Drawing.Point(123, 161);
            tRINHDOLabel.Name = "tRINHDOLabel";
            tRINHDOLabel.Size = new System.Drawing.Size(65, 16);
            tRINHDOLabel.TabIndex = 4;
            tRINHDOLabel.Text = "TRINHDO:";
            // 
            // nOIDUNGLabel
            // 
            nOIDUNGLabel.AutoSize = true;
            nOIDUNGLabel.Location = new System.Drawing.Point(123, 209);
            nOIDUNGLabel.Name = "nOIDUNGLabel";
            nOIDUNGLabel.Size = new System.Drawing.Size(65, 16);
            nOIDUNGLabel.TabIndex = 6;
            nOIDUNGLabel.Text = "NOIDUNG:";
            // 
            // bLabel
            // 
            bLabel.AutoSize = true;
            bLabel.Location = new System.Drawing.Point(593, 65);
            bLabel.Name = "bLabel";
            bLabel.Size = new System.Drawing.Size(19, 16);
            bLabel.TabIndex = 8;
            bLabel.Text = "B:";
            // 
            // aLabel
            // 
            aLabel.AutoSize = true;
            aLabel.Location = new System.Drawing.Point(590, 25);
            aLabel.Name = "aLabel";
            aLabel.Size = new System.Drawing.Size(20, 16);
            aLabel.TabIndex = 10;
            aLabel.Text = "A:";
            // 
            // cLabel
            // 
            cLabel.AutoSize = true;
            cLabel.Location = new System.Drawing.Point(602, 110);
            cLabel.Name = "cLabel";
            cLabel.Size = new System.Drawing.Size(20, 16);
            cLabel.TabIndex = 12;
            cLabel.Text = "C:";
            // 
            // dLabel
            // 
            dLabel.AutoSize = true;
            dLabel.Location = new System.Drawing.Point(607, 141);
            dLabel.Name = "dLabel";
            dLabel.Size = new System.Drawing.Size(20, 16);
            dLabel.TabIndex = 14;
            dLabel.Text = "D:";
            // 
            // dAP_ANLabel
            // 
            dAP_ANLabel.AutoSize = true;
            dAP_ANLabel.Location = new System.Drawing.Point(567, 180);
            dAP_ANLabel.Name = "dAP_ANLabel";
            dAP_ANLabel.Size = new System.Drawing.Size(55, 16);
            dAP_ANLabel.TabIndex = 16;
            dAP_ANLabel.Text = "DAP AN:";
            // 
            // mAGVLabel
            // 
            mAGVLabel.AutoSize = true;
            mAGVLabel.Location = new System.Drawing.Point(566, 209);
            mAGVLabel.Name = "mAGVLabel";
            mAGVLabel.Size = new System.Drawing.Size(46, 16);
            mAGVLabel.TabIndex = 18;
            mAGVLabel.Text = "MAGV:";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAdd,
            this.btnSua,
            this.btnGhi,
            this.btnXoa,
            this.btnPhucHoi,
            this.btnThoat,
            this.barButtonItem5});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGhi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPhucHoi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem5, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Them";
            this.btnAdd.Id = 0;
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.LargeImage")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sua";
            this.btnSua.Hint = "Sua";
            this.btnSua.Id = 1;
            this.btnSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.ImageOptions.Image")));
            this.btnSua.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSua.ImageOptions.LargeImage")));
            this.btnSua.Name = "btnSua";
            this.btnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSua_ItemClick);
            // 
            // btnGhi
            // 
            this.btnGhi.Caption = "Ghi";
            this.btnGhi.Id = 2;
            this.btnGhi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGhi.ImageOptions.Image")));
            this.btnGhi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGhi.ImageOptions.LargeImage")));
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGhi_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xoa";
            this.btnXoa.Id = 3;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.LargeImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Caption = "Phuc hoi";
            this.btnPhucHoi.Id = 4;
            this.btnPhucHoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPhucHoi.ImageOptions.Image")));
            this.btnPhucHoi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPhucHoi.ImageOptions.LargeImage")));
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhucHoi_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoat";
            this.btnThoat.Id = 5;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.LargeImage")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Lam moi";
            this.barButtonItem5.Id = 6;
            this.barButtonItem5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.Image")));
            this.barButtonItem5.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.LargeImage")));
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1098, 51);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 720);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1098, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 669);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1098, 51);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 669);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 51);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1098, 365);
            this.panelControl1.TabIndex = 4;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1094, 361);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.cbxTrinhDo);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.cbxMonHoc);
            this.panelControl2.Controls.Add(mAGVLabel);
            this.panelControl2.Controls.Add(this.txtMAGV);
            this.panelControl2.Controls.Add(dAP_ANLabel);
            this.panelControl2.Controls.Add(this.txtDapAn);
            this.panelControl2.Controls.Add(dLabel);
            this.panelControl2.Controls.Add(this.txtD);
            this.panelControl2.Controls.Add(cLabel);
            this.panelControl2.Controls.Add(this.txtC);
            this.panelControl2.Controls.Add(aLabel);
            this.panelControl2.Controls.Add(this.txtA);
            this.panelControl2.Controls.Add(bLabel);
            this.panelControl2.Controls.Add(this.txtB);
            this.panelControl2.Controls.Add(nOIDUNGLabel);
            this.panelControl2.Controls.Add(this.txtNoiDung);
            this.panelControl2.Controls.Add(tRINHDOLabel);
            this.panelControl2.Controls.Add(this.txtTrinhDo);
            this.panelControl2.Controls.Add(mAMHLabel);
            this.panelControl2.Controls.Add(this.txtMAMH);
            this.panelControl2.Controls.Add(cAUHOILabel);
            this.panelControl2.Controls.Add(this.cAUHOISpinEdit);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 416);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1098, 304);
            this.panelControl2.TabIndex = 5;
            // 
            // cbxTrinhDo
            // 
            this.cbxTrinhDo.FormattingEnabled = true;
            this.cbxTrinhDo.Items.AddRange(new object[] {
            "Đại học chuyên ngành",
            "Đại học không chuyên ngành",
            "Cao đẳng"});
            this.cbxTrinhDo.Location = new System.Drawing.Point(194, 158);
            this.cbxTrinhDo.Name = "cbxTrinhDo";
            this.cbxTrinhDo.Size = new System.Drawing.Size(121, 24);
            this.cbxTrinhDo.TabIndex = 22;
            this.cbxTrinhDo.SelectedIndexChanged += new System.EventHandler(this.cbxTrinhDo_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(117, 86);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 16);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "MonHoc";
            // 
            // cbxMonHoc
            // 
            this.cbxMonHoc.FormattingEnabled = true;
            this.cbxMonHoc.Location = new System.Drawing.Point(194, 83);
            this.cbxMonHoc.Name = "cbxMonHoc";
            this.cbxMonHoc.Size = new System.Drawing.Size(121, 24);
            this.cbxMonHoc.TabIndex = 20;
            this.cbxMonHoc.SelectedIndexChanged += new System.EventHandler(this.cbxMonHoc_SelectedIndexChanged);
            // 
            // txtMAGV
            // 
            this.txtMAGV.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsBoDe, "MAGV", true));
            this.txtMAGV.Enabled = false;
            this.txtMAGV.Location = new System.Drawing.Point(633, 206);
            this.txtMAGV.MenuManager = this.barManager1;
            this.txtMAGV.Name = "txtMAGV";
            this.txtMAGV.Size = new System.Drawing.Size(125, 22);
            this.txtMAGV.TabIndex = 19;
            // 
            // bdsBoDe
            // 
            this.bdsBoDe.DataMember = "BODE";
            this.bdsBoDe.DataSource = this.DS;
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtDapAn
            // 
            this.txtDapAn.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsBoDe, "DAP_AN", true));
            this.txtDapAn.Location = new System.Drawing.Point(633, 174);
            this.txtDapAn.MenuManager = this.barManager1;
            this.txtDapAn.Name = "txtDapAn";
            this.txtDapAn.Size = new System.Drawing.Size(125, 22);
            this.txtDapAn.TabIndex = 17;
            // 
            // txtD
            // 
            this.txtD.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsBoDe, "D", true));
            this.txtD.Location = new System.Drawing.Point(633, 138);
            this.txtD.MenuManager = this.barManager1;
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(125, 22);
            this.txtD.TabIndex = 15;
            // 
            // txtC
            // 
            this.txtC.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsBoDe, "C", true));
            this.txtC.Location = new System.Drawing.Point(633, 107);
            this.txtC.MenuManager = this.barManager1;
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(125, 22);
            this.txtC.TabIndex = 13;
            // 
            // txtA
            // 
            this.txtA.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsBoDe, "A", true));
            this.txtA.Location = new System.Drawing.Point(633, 22);
            this.txtA.MenuManager = this.barManager1;
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(125, 22);
            this.txtA.TabIndex = 11;
            // 
            // txtB
            // 
            this.txtB.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsBoDe, "B", true));
            this.txtB.Location = new System.Drawing.Point(633, 62);
            this.txtB.MenuManager = this.barManager1;
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(125, 22);
            this.txtB.TabIndex = 9;
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsBoDe, "NOIDUNG", true));
            this.txtNoiDung.Location = new System.Drawing.Point(194, 206);
            this.txtNoiDung.MenuManager = this.barManager1;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(125, 22);
            this.txtNoiDung.TabIndex = 7;
            // 
            // txtTrinhDo
            // 
            this.txtTrinhDo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsBoDe, "TRINHDO", true));
            this.txtTrinhDo.Location = new System.Drawing.Point(335, 155);
            this.txtTrinhDo.MenuManager = this.barManager1;
            this.txtTrinhDo.Name = "txtTrinhDo";
            this.txtTrinhDo.Size = new System.Drawing.Size(125, 22);
            this.txtTrinhDo.TabIndex = 5;
            // 
            // txtMAMH
            // 
            this.txtMAMH.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsBoDe, "MAMH", true));
            this.txtMAMH.Enabled = false;
            this.txtMAMH.Location = new System.Drawing.Point(194, 113);
            this.txtMAMH.MenuManager = this.barManager1;
            this.txtMAMH.Name = "txtMAMH";
            this.txtMAMH.Size = new System.Drawing.Size(125, 22);
            this.txtMAMH.TabIndex = 3;
            // 
            // cAUHOISpinEdit
            // 
            this.cAUHOISpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsBoDe, "CAUHOI", true));
            this.cAUHOISpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cAUHOISpinEdit.Location = new System.Drawing.Point(194, 47);
            this.cAUHOISpinEdit.MenuManager = this.barManager1;
            this.cAUHOISpinEdit.Name = "cAUHOISpinEdit";
            this.cAUHOISpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cAUHOISpinEdit.Size = new System.Drawing.Size(125, 24);
            this.cAUHOISpinEdit.TabIndex = 1;
            // 
            // BODETableAdapter
            // 
            this.BODETableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANGDIEMTableAdapter = null;
            this.tableAdapterManager.BODETableAdapter = this.BODETableAdapter;
            this.tableAdapterManager.COSOTableAdapter = null;
            this.tableAdapterManager.GIAOVIEN_DANGKYTableAdapter = null;
            this.tableAdapterManager.GIAOVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = this.MONHOCTableAdapter;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = THI_TN.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // MONHOCTableAdapter
            // 
            this.MONHOCTableAdapter.ClearBeforeFill = true;
            // 
            // bdsMonHoc
            // 
            this.bdsMonHoc.DataMember = "MONHOC";
            this.bdsMonHoc.DataSource = this.DS;
            // 
            // frmNhapDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 740);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmNhapDe";
            this.Text = "frmNhapDe";
            this.Load += new System.EventHandler(this.frmNhapDe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMAGV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBoDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDapAn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrinhDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMAMH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAUHOISpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMonHoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnGhi;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnPhucHoi;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.BindingSource bdsBoDe;
        private DS DS;
        private DSTableAdapters.BODETableAdapter BODETableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraEditors.TextEdit txtMAGV;
        private DevExpress.XtraEditors.TextEdit txtDapAn;
        private DevExpress.XtraEditors.TextEdit txtD;
        private DevExpress.XtraEditors.TextEdit txtC;
        private DevExpress.XtraEditors.TextEdit txtA;
        private DevExpress.XtraEditors.TextEdit txtB;
        private DevExpress.XtraEditors.TextEdit txtNoiDung;
        private DevExpress.XtraEditors.TextEdit txtTrinhDo;
        private DevExpress.XtraEditors.TextEdit txtMAMH;
        private DevExpress.XtraEditors.SpinEdit cAUHOISpinEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ComboBox cbxMonHoc;
        private DSTableAdapters.MONHOCTableAdapter MONHOCTableAdapter;
        private System.Windows.Forms.BindingSource bdsMonHoc;
        private System.Windows.Forms.ComboBox cbxTrinhDo;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}