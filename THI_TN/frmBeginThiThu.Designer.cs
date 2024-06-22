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
            this.txtTenlop = new DevExpress.XtraEditors.TextEdit();
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cbxLan = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgaythi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgaythi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenlop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThi
            // 
            this.btnThi.Location = new System.Drawing.Point(480, 528);
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
            this.txtNgaythi.Location = new System.Drawing.Point(497, 428);
            this.txtNgaythi.Name = "txtNgaythi";
            this.txtNgaythi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNgaythi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNgaythi.Size = new System.Drawing.Size(282, 22);
            this.txtNgaythi.TabIndex = 24;
            // 
            // cbxMonHoc
            // 
            this.cbxMonHoc.FormattingEnabled = true;
            this.cbxMonHoc.Location = new System.Drawing.Point(497, 332);
            this.cbxMonHoc.Name = "cbxMonHoc";
            this.cbxMonHoc.Size = new System.Drawing.Size(282, 24);
            this.cbxMonHoc.TabIndex = 23;
            // 
            // txtTenlop
            // 
            this.txtTenlop.Location = new System.Drawing.Point(497, 274);
            this.txtTenlop.Name = "txtTenlop";
            this.txtTenlop.Size = new System.Drawing.Size(282, 22);
            this.txtTenlop.TabIndex = 21;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(383, 386);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(38, 16);
            this.labelControl7.TabIndex = 19;
            this.labelControl7.Text = "Lan thi";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(383, 434);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(46, 16);
            this.labelControl6.TabIndex = 18;
            this.labelControl6.Text = "Ngay thi";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(376, 332);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 16);
            this.labelControl5.TabIndex = 17;
            this.labelControl5.Text = "Mon hoc";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(380, 277);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 16);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "TEN LOP";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(380, 227);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 16);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "MA LOP";
            // 
            // cbxLop
            // 
            this.cbxLop.FormattingEnabled = true;
            this.cbxLop.Location = new System.Drawing.Point(497, 227);
            this.cbxLop.Name = "cbxLop";
            this.cbxLop.Size = new System.Drawing.Size(282, 24);
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
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(383, 180);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 16);
            this.labelControl3.TabIndex = 28;
            this.labelControl3.Text = "MA Co so";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(497, 180);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(282, 24);
            this.comboBox1.TabIndex = 29;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cbxLan
            // 
            this.cbxLan.FormattingEnabled = true;
            this.cbxLan.Location = new System.Drawing.Point(497, 383);
            this.cbxLan.Name = "cbxLan";
            this.cbxLan.Size = new System.Drawing.Size(282, 24);
            this.cbxLan.TabIndex = 30;
            // 
            // frmBeginThiThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 752);
            this.Controls.Add(this.cbxLan);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cbxLop);
            this.Controls.Add(this.btnThi);
            this.Controls.Add(this.txtNgaythi);
            this.Controls.Add(this.cbxMonHoc);
            this.Controls.Add(this.txtTenlop);
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
            ((System.ComponentModel.ISupportInitialize)(this.txtTenlop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThi;
        private DevExpress.XtraEditors.DateEdit txtNgaythi;
        private System.Windows.Forms.ComboBox cbxMonHoc;
        private DevExpress.XtraEditors.TextEdit txtTenlop;
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
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cbxLan;
    }
}