namespace THI_TN
{
    partial class frmBeginThiThu
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
            this.btnThi = new System.Windows.Forms.Button();
            this.txtNgaythi = new DevExpress.XtraEditors.DateEdit();
            this.cbxMonHoc = new System.Windows.Forms.ComboBox();
            this.txtMalop = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cbxLop = new System.Windows.Forms.ComboBox();
            this.DS = new THI_TN.DS();
            this.bdsLop = new System.Windows.Forms.BindingSource(this.components);
            this.LOPTableAdapter = new THI_TN.DSTableAdapters.LOPTableAdapter();
            this.tableAdapterManager = new THI_TN.DSTableAdapters.TableAdapterManager();
            this.cbxCoSo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLan = new DevExpress.XtraEditors.TextEdit();
            this.groupThi = new DevExpress.XtraEditors.GroupControl();
            this.lbTrinhDo = new DevExpress.XtraEditors.LabelControl();
            this.lbThoiGian = new DevExpress.XtraEditors.LabelControl();
            this.lbSoCauThi = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgaythi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgaythi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMalop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupThi)).BeginInit();
            this.groupThi.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThi
            // 
            this.btnThi.Location = new System.Drawing.Point(481, 612);
            this.btnThi.Name = "btnThi";
            this.btnThi.Size = new System.Drawing.Size(299, 23);
            this.btnThi.TabIndex = 26;
            this.btnThi.Text = "Thi";
            this.btnThi.UseVisualStyleBackColor = true;
            this.btnThi.Click += new System.EventHandler(this.btnThi_Click);
            // 
            // txtNgaythi
            // 
            this.txtNgaythi.EditValue = null;
            this.txtNgaythi.Location = new System.Drawing.Point(497, 371);
            this.txtNgaythi.Name = "txtNgaythi";
            this.txtNgaythi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNgaythi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNgaythi.Size = new System.Drawing.Size(315, 22);
            this.txtNgaythi.TabIndex = 24;
            // 
            // cbxMonHoc
            // 
            this.cbxMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMonHoc.FormattingEnabled = true;
            this.cbxMonHoc.Location = new System.Drawing.Point(497, 332);
            this.cbxMonHoc.Name = "cbxMonHoc";
            this.cbxMonHoc.Size = new System.Drawing.Size(315, 24);
            this.cbxMonHoc.TabIndex = 23;
            this.cbxMonHoc.SelectedIndexChanged += new System.EventHandler(this.cbxMonHoc_SelectedIndexChanged);
            // 
            // txtMalop
            // 
            this.txtMalop.Enabled = false;
            this.txtMalop.Location = new System.Drawing.Point(497, 274);
            this.txtMalop.Name = "txtMalop";
            this.txtMalop.Size = new System.Drawing.Size(315, 22);
            this.txtMalop.TabIndex = 21;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(383, 415);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(43, 16);
            this.labelControl7.TabIndex = 19;
            this.labelControl7.Text = "Lần thi:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(383, 377);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(51, 16);
            this.labelControl6.TabIndex = 18;
            this.labelControl6.Text = "Ngày thi:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(376, 332);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(53, 16);
            this.labelControl5.TabIndex = 17;
            this.labelControl5.Text = "Môn học:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(381, 227);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 16);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Tên lớp:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(383, 277);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 16);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Mã lớp:";
            // 
            // cbxLop
            // 
            this.cbxLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLop.FormattingEnabled = true;
            this.cbxLop.Location = new System.Drawing.Point(497, 227);
            this.cbxLop.Name = "cbxLop";
            this.cbxLop.Size = new System.Drawing.Size(315, 24);
            this.cbxLop.TabIndex = 27;
            this.cbxLop.SelectedIndexChanged += new System.EventHandler(this.cbxLop_SelectedIndexChanged);
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsLop
            // 
            this.bdsLop.DataMember = "LOP";
            this.bdsLop.DataSource = this.DS;
            // 
            // LOPTableAdapter
            // 
            this.LOPTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANGDIEMTableAdapter = null;
            this.tableAdapterManager.BODETableAdapter = null;
            this.tableAdapterManager.COSOTableAdapter = null;
            this.tableAdapterManager.CT_BAITHITableAdapter = null;
            this.tableAdapterManager.GIAOVIEN_DANGKYTableAdapter = null;
            this.tableAdapterManager.GIAOVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = this.LOPTableAdapter;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = THI_TN.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // cbxCoSo
            // 
            this.cbxCoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCoSo.FormattingEnabled = true;
            this.cbxCoSo.Location = new System.Drawing.Point(497, 168);
            this.cbxCoSo.Name = "cbxCoSo";
            this.cbxCoSo.Size = new System.Drawing.Size(315, 24);
            this.cbxCoSo.TabIndex = 32;
            this.cbxCoSo.SelectedIndexChanged += new System.EventHandler(this.cbxCoSo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(391, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "Cơ sở";
            // 
            // txtLan
            // 
            this.txtLan.Location = new System.Drawing.Point(497, 409);
            this.txtLan.Name = "txtLan";
            this.txtLan.Size = new System.Drawing.Size(315, 22);
            this.txtLan.TabIndex = 33;
            // 
            // groupThi
            // 
            this.groupThi.Controls.Add(this.lbTrinhDo);
            this.groupThi.Controls.Add(this.lbThoiGian);
            this.groupThi.Controls.Add(this.lbSoCauThi);
            this.groupThi.Location = new System.Drawing.Point(345, 459);
            this.groupThi.Name = "groupThi";
            this.groupThi.Size = new System.Drawing.Size(510, 119);
            this.groupThi.TabIndex = 34;
            this.groupThi.Visible = false;
            // 
            // lbTrinhDo
            // 
            this.lbTrinhDo.Location = new System.Drawing.Point(344, 44);
            this.lbTrinhDo.Name = "lbTrinhDo";
            this.lbTrinhDo.Size = new System.Drawing.Size(53, 16);
            this.lbTrinhDo.TabIndex = 2;
            this.lbTrinhDo.Text = "Trình độ:";
            // 
            // lbThoiGian
            // 
            this.lbThoiGian.Location = new System.Drawing.Point(56, 76);
            this.lbThoiGian.Name = "lbThoiGian";
            this.lbThoiGian.Size = new System.Drawing.Size(76, 16);
            this.lbThoiGian.TabIndex = 1;
            this.lbThoiGian.Text = "Thời gian thi:";
            // 
            // lbSoCauThi
            // 
            this.lbSoCauThi.Location = new System.Drawing.Point(56, 44);
            this.lbSoCauThi.Name = "lbSoCauThi";
            this.lbSoCauThi.Size = new System.Drawing.Size(66, 16);
            this.lbSoCauThi.TabIndex = 0;
            this.lbSoCauThi.Text = "Số câu thi: ";
            // 
            // frmBeginThiThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 752);
            this.Controls.Add(this.groupThi);
            this.Controls.Add(this.txtLan);
            this.Controls.Add(this.cbxCoSo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxLop);
            this.Controls.Add(this.btnThi);
            this.Controls.Add(this.txtNgaythi);
            this.Controls.Add(this.cbxMonHoc);
            this.Controls.Add(this.txtMalop);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmBeginThiThu";
            this.Text = "frmBeginThiThu";
            this.Load += new System.EventHandler(this.frmBeginThiThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNgaythi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgaythi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMalop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupThi)).EndInit();
            this.groupThi.ResumeLayout(false);
            this.groupThi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThi;
        private DevExpress.XtraEditors.DateEdit txtNgaythi;
        private System.Windows.Forms.ComboBox cbxMonHoc;
        private DevExpress.XtraEditors.TextEdit txtMalop;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ComboBox cbxLop;
        private DS DS;
        private System.Windows.Forms.BindingSource bdsLop;
        private DSTableAdapters.LOPTableAdapter LOPTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox cbxCoSo;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtLan;
        private DevExpress.XtraEditors.GroupControl groupThi;
        private DevExpress.XtraEditors.LabelControl lbTrinhDo;
        private DevExpress.XtraEditors.LabelControl lbThoiGian;
        private DevExpress.XtraEditors.LabelControl lbSoCauThi;
    }
}