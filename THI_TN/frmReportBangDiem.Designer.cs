namespace THI_TN
{
    partial class frmReportBangDiem
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxMonHoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxLop = new System.Windows.Forms.ComboBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.txtLan = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1141, 125);
            this.panelControl1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(496, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bang diem mon hoc ";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtLan);
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Controls.Add(this.btnIn);
            this.panelControl2.Controls.Add(this.label3);
            this.panelControl2.Controls.Add(this.cbxLop);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Controls.Add(this.cbxMonHoc);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 125);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1141, 589);
            this.panelControl2.TabIndex = 4;
            this.panelControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mon hoc";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbxMonHoc
            // 
            this.cbxMonHoc.FormattingEnabled = true;
            this.cbxMonHoc.Location = new System.Drawing.Point(470, 104);
            this.cbxMonHoc.Name = "cbxMonHoc";
            this.cbxMonHoc.Size = new System.Drawing.Size(359, 24);
            this.cbxMonHoc.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lop";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbxLop
            // 
            this.cbxLop.FormattingEnabled = true;
            this.cbxLop.Location = new System.Drawing.Point(470, 58);
            this.cbxLop.Name = "cbxLop";
            this.cbxLop.Size = new System.Drawing.Size(359, 24);
            this.cbxLop.TabIndex = 4;
            this.cbxLop.SelectedIndexChanged += new System.EventHandler(this.cbxLop_SelectedIndexChanged);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(373, 216);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(456, 23);
            this.btnIn.TabIndex = 6;
            this.btnIn.Text = "In Bao Cao";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // txtLan
            // 
            this.txtLan.Location = new System.Drawing.Point(470, 157);
            this.txtLan.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtLan.Name = "txtLan";
            this.txtLan.Size = new System.Drawing.Size(359, 22);
            this.txtLan.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Lan";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmReportBangDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 714);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmReportBangDiem";
            this.Text = "frmReportBangDiem";
            this.Load += new System.EventHandler(this.frmReportBangDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLan.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxLop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxMonHoc;
        private System.Windows.Forms.Button btnIn;
        private DevExpress.XtraEditors.TextEdit txtLan;
        private System.Windows.Forms.Label label4;
    }
}