namespace THI_TN
{
    partial class frmLogin
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
            this.btnExist = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.cbSinhVien = new System.Windows.Forms.CheckBox();
            this.Mk = new System.Windows.Forms.Label();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbChiNhanh = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnExist
            // 
            this.btnExist.Location = new System.Drawing.Point(320, 330);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(111, 48);
            this.btnExist.TabIndex = 26;
            this.btnExist.Text = "Thoát";
            this.btnExist.UseVisualStyleBackColor = true;
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(135, 330);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(108, 48);
            this.btnLogin.TabIndex = 25;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // cbSinhVien
            // 
            this.cbSinhVien.AutoSize = true;
            this.cbSinhVien.Location = new System.Drawing.Point(235, 265);
            this.cbSinhVien.Name = "cbSinhVien";
            this.cbSinhVien.Size = new System.Drawing.Size(81, 20);
            this.cbSinhVien.TabIndex = 24;
            this.cbSinhVien.Text = "Sinh viên";
            this.cbSinhVien.UseVisualStyleBackColor = true;
            this.cbSinhVien.CheckedChanged += new System.EventHandler(this.cbSinhVien_CheckedChanged);
            // 
            // Mk
            // 
            this.Mk.AutoSize = true;
            this.Mk.Location = new System.Drawing.Point(117, 214);
            this.Mk.Name = "Mk";
            this.Mk.Size = new System.Drawing.Size(59, 16);
            this.Mk.TabIndex = 23;
            this.Mk.Text = "Mật khẩu";
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(235, 211);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(232, 23);
            this.txtMK.TabIndex = 22;
            this.txtMK.Text = "123456";
            this.txtMK.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Tên đăng nhập";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(235, 153);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(232, 23);
            this.txtLogin.TabIndex = 20;
            this.txtLogin.Text = "PVH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Cơ sở:";
            // 
            // cbChiNhanh
            // 
            this.cbChiNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChiNhanh.FormattingEnabled = true;
            this.cbChiNhanh.Location = new System.Drawing.Point(235, 103);
            this.cbChiNhanh.Name = "cbChiNhanh";
            this.cbChiNhanh.Size = new System.Drawing.Size(232, 24);
            this.cbChiNhanh.Sorted = true;
            this.cbChiNhanh.TabIndex = 18;
            this.cbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cbChiNhanh_SelectedIndexChanged);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 480);
            this.Controls.Add(this.btnExist);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.cbSinhVien);
            this.Controls.Add(this.Mk);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbChiNhanh);
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExist;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox cbSinhVien;
        private System.Windows.Forms.Label Mk;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbChiNhanh;
    }
}