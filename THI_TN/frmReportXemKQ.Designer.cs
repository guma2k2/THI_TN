namespace THI_TN
{
    partial class frmReportXemKQ
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
            this.cbxMonHoc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLan = new DevExpress.XtraEditors.TextEdit();
            this.btnIn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMasv = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMasv.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxMonHoc
            // 
            this.cbxMonHoc.FormattingEnabled = true;
            this.cbxMonHoc.Location = new System.Drawing.Point(458, 199);
            this.cbxMonHoc.Name = "cbxMonHoc";
            this.cbxMonHoc.Size = new System.Drawing.Size(359, 24);
            this.cbxMonHoc.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(358, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mon hoc";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1116, 125);
            this.panelControl1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(581, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Xem Ket Qua ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(358, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Lan";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtLan
            // 
            this.txtLan.Location = new System.Drawing.Point(458, 255);
            this.txtLan.Margin = new System.Windows.Forms.Padding(5);
            this.txtLan.Name = "txtLan";
            this.txtLan.Size = new System.Drawing.Size(359, 22);
            this.txtLan.TabIndex = 4;
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(392, 398);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(425, 23);
            this.btnIn.TabIndex = 5;
            this.btnIn.Text = "In Bao Cao";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sinh vien";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtMasv
            // 
            this.txtMasv.Location = new System.Drawing.Point(458, 147);
            this.txtMasv.Margin = new System.Windows.Forms.Padding(5);
            this.txtMasv.Name = "txtMasv";
            this.txtMasv.Size = new System.Drawing.Size(359, 22);
            this.txtMasv.TabIndex = 7;
            // 
            // frmReportXemKQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 708);
            this.Controls.Add(this.txtMasv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.txtLan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxMonHoc);
            this.Name = "frmReportXemKQ";
            this.Text = "frmReportXemKQ";
            this.Load += new System.EventHandler(this.frmReportXemKQ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMasv.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxMonHoc;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtLan;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtMasv;
    }
}