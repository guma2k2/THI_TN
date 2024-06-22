namespace THI_TN
{
    partial class frmThiBegin
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtMalop = new DevExpress.XtraEditors.TextEdit();
            this.txtTenlop = new DevExpress.XtraEditors.TextEdit();
            this.txtHoten = new DevExpress.XtraEditors.TextEdit();
            this.cbxMonhoc = new System.Windows.Forms.ComboBox();
            this.txtNgaythi = new DevExpress.XtraEditors.DateEdit();
            this.txtLan = new DevExpress.XtraEditors.TextEdit();
            this.btnThi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtMalop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenlop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgaythi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgaythi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(260, 157);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "MA LOP";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(260, 207);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "TEN LOP";
            this.labelControl2.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(202, 261);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(107, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "HO TEN SINH VIEN";
            this.labelControl3.Click += new System.EventHandler(this.labelControl3_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(256, 300);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 16);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Mon hoc";
            this.labelControl5.Click += new System.EventHandler(this.labelControl5_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(263, 333);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(46, 16);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Ngay thi";
            this.labelControl6.Click += new System.EventHandler(this.labelControl6_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(271, 375);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(38, 16);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "Lan thi";
            this.labelControl7.Click += new System.EventHandler(this.labelControl7_Click);
            // 
            // txtMalop
            // 
            this.txtMalop.Location = new System.Drawing.Point(377, 157);
            this.txtMalop.Name = "txtMalop";
            this.txtMalop.Size = new System.Drawing.Size(282, 22);
            this.txtMalop.TabIndex = 7;
            this.txtMalop.EditValueChanged += new System.EventHandler(this.txtMalop_EditValueChanged);
            // 
            // txtTenlop
            // 
            this.txtTenlop.Location = new System.Drawing.Point(377, 204);
            this.txtTenlop.Name = "txtTenlop";
            this.txtTenlop.Size = new System.Drawing.Size(282, 22);
            this.txtTenlop.TabIndex = 8;
            this.txtTenlop.EditValueChanged += new System.EventHandler(this.txtTenlop_EditValueChanged);
            // 
            // txtHoten
            // 
            this.txtHoten.Location = new System.Drawing.Point(377, 255);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(282, 22);
            this.txtHoten.TabIndex = 9;
            this.txtHoten.EditValueChanged += new System.EventHandler(this.txtHoten_EditValueChanged);
            // 
            // cbxMonhoc
            // 
            this.cbxMonhoc.FormattingEnabled = true;
            this.cbxMonhoc.Location = new System.Drawing.Point(377, 291);
            this.cbxMonhoc.Name = "cbxMonhoc";
            this.cbxMonhoc.Size = new System.Drawing.Size(282, 24);
            this.cbxMonhoc.TabIndex = 10;
            this.cbxMonhoc.SelectedIndexChanged += new System.EventHandler(this.cbxMonhoc_SelectedIndexChanged);
            // 
            // txtNgaythi
            // 
            this.txtNgaythi.EditValue = null;
            this.txtNgaythi.Location = new System.Drawing.Point(377, 333);
            this.txtNgaythi.Name = "txtNgaythi";
            this.txtNgaythi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNgaythi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNgaythi.Size = new System.Drawing.Size(282, 22);
            this.txtNgaythi.TabIndex = 11;
            this.txtNgaythi.EditValueChanged += new System.EventHandler(this.txtNgaythi_EditValueChanged);
            // 
            // txtLan
            // 
            this.txtLan.Location = new System.Drawing.Point(377, 372);
            this.txtLan.Name = "txtLan";
            this.txtLan.Size = new System.Drawing.Size(282, 22);
            this.txtLan.TabIndex = 12;
            this.txtLan.EditValueChanged += new System.EventHandler(this.txtLan_EditValueChanged);
            // 
            // btnThi
            // 
            this.btnThi.Location = new System.Drawing.Point(360, 458);
            this.btnThi.Name = "btnThi";
            this.btnThi.Size = new System.Drawing.Size(299, 23);
            this.btnThi.TabIndex = 13;
            this.btnThi.Text = "Thi";
            this.btnThi.UseVisualStyleBackColor = true;
            this.btnThi.Click += new System.EventHandler(this.btnThi_Click);
            // 
            // frmThiBegin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 702);
            this.Controls.Add(this.btnThi);
            this.Controls.Add(this.txtLan);
            this.Controls.Add(this.txtNgaythi);
            this.Controls.Add(this.cbxMonhoc);
            this.Controls.Add(this.txtHoten);
            this.Controls.Add(this.txtTenlop);
            this.Controls.Add(this.txtMalop);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmThiBegin";
            this.Text = "frmThiBegin";
            this.Load += new System.EventHandler(this.frmThiBegin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMalop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenlop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgaythi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgaythi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtMalop;
        private DevExpress.XtraEditors.TextEdit txtTenlop;
        private DevExpress.XtraEditors.TextEdit txtHoten;
        private System.Windows.Forms.ComboBox cbxMonhoc;
        private DevExpress.XtraEditors.DateEdit txtNgaythi;
        private DevExpress.XtraEditors.TextEdit txtLan;
        private System.Windows.Forms.Button btnThi;
    }
}