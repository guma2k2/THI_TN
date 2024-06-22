namespace THI_TN
{
    partial class frmThiDoing
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lb_index = new DevExpress.XtraEditors.LabelControl();
            this.lb_question = new DevExpress.XtraEditors.LabelControl();
            this.radioGroup = new DevExpress.XtraEditors.RadioGroup();
            this.rb_a = new System.Windows.Forms.RadioButton();
            this.rb_b = new System.Windows.Forms.RadioButton();
            this.rb_c = new System.Windows.Forms.RadioButton();
            this.rb_d = new System.Windows.Forms.RadioButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnNopBai = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_timer = new System.Windows.Forms.Label();
            this.timerThi = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(113, 96);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Cau";
            // 
            // lb_index
            // 
            this.lb_index.Location = new System.Drawing.Point(141, 96);
            this.lb_index.Name = "lb_index";
            this.lb_index.Size = new System.Drawing.Size(7, 16);
            this.lb_index.TabIndex = 1;
            this.lb_index.Text = "1";
            this.lb_index.Click += new System.EventHandler(this.lb_index_Click);
            // 
            // lb_question
            // 
            this.lb_question.Location = new System.Drawing.Point(175, 96);
            this.lb_question.Name = "lb_question";
            this.lb_question.Size = new System.Drawing.Size(404, 16);
            this.lb_question.TabIndex = 2;
            this.lb_question.Text = "mạng máy tính(compute netword) so với hệ thống tập trung multi-user";
            // 
            // radioGroup
            // 
            this.radioGroup.Location = new System.Drawing.Point(113, 163);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Size = new System.Drawing.Size(817, 220);
            this.radioGroup.TabIndex = 3;
            this.radioGroup.SelectedIndexChanged += new System.EventHandler(this.radioGroup_SelectedIndexChanged);
            // 
            // rb_a
            // 
            this.rb_a.AutoSize = true;
            this.rb_a.Location = new System.Drawing.Point(200, 189);
            this.rb_a.Name = "rb_a";
            this.rb_a.Size = new System.Drawing.Size(155, 20);
            this.rb_a.TabIndex = 4;
            this.rb_a.TabStop = true;
            this.rb_a.Text = "dễ phát triển hệ thống";
            this.rb_a.UseVisualStyleBackColor = true;
            this.rb_a.CheckedChanged += new System.EventHandler(this.rb_a_CheckedChanged);
            // 
            // rb_b
            // 
            this.rb_b.AutoSize = true;
            this.rb_b.Location = new System.Drawing.Point(200, 235);
            this.rb_b.Name = "rb_b";
            this.rb_b.Size = new System.Drawing.Size(112, 20);
            this.rb_b.TabIndex = 5;
            this.rb_b.TabStop = true;
            this.rb_b.Text = "tăng độ tin cậy";
            this.rb_b.UseVisualStyleBackColor = true;
            this.rb_b.CheckedChanged += new System.EventHandler(this.rb_b_CheckedChanged);
            // 
            // rb_c
            // 
            this.rb_c.AutoSize = true;
            this.rb_c.Location = new System.Drawing.Point(200, 285);
            this.rb_c.Name = "rb_c";
            this.rb_c.Size = new System.Drawing.Size(112, 20);
            this.rb_c.TabIndex = 6;
            this.rb_c.TabStop = true;
            this.rb_c.Text = "tăng độ tin cậy";
            this.rb_c.UseVisualStyleBackColor = true;
            this.rb_c.CheckedChanged += new System.EventHandler(this.rb_c_CheckedChanged);
            // 
            // rb_d
            // 
            this.rb_d.AutoSize = true;
            this.rb_d.Location = new System.Drawing.Point(200, 334);
            this.rb_d.Name = "rb_d";
            this.rb_d.Size = new System.Drawing.Size(112, 20);
            this.rb_d.TabIndex = 7;
            this.rb_d.TabStop = true;
            this.rb_d.Text = "tăng độ tin cậy";
            this.rb_d.UseVisualStyleBackColor = true;
            this.rb_d.CheckedChanged += new System.EventHandler(this.rb_d_CheckedChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(141, 191);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(8, 16);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "A";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(141, 334);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(8, 16);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "D";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(141, 289);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(8, 16);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "C";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(141, 235);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(7, 16);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "B";
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(305, 464);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(181, 73);
            this.btnPrev.TabIndex = 12;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(614, 464);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(163, 73);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnNopBai
            // 
            this.btnNopBai.Location = new System.Drawing.Point(937, 604);
            this.btnNopBai.Name = "btnNopBai";
            this.btnNopBai.Size = new System.Drawing.Size(166, 77);
            this.btnNopBai.TabIndex = 14;
            this.btnNopBai.Text = "Nop bai";
            this.btnNopBai.UseVisualStyleBackColor = true;
            this.btnNopBai.Click += new System.EventHandler(this.btnNopBai_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(832, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Thoi gian";
            // 
            // lb_timer
            // 
            this.lb_timer.AutoSize = true;
            this.lb_timer.Location = new System.Drawing.Point(934, 32);
            this.lb_timer.Name = "lb_timer";
            this.lb_timer.Size = new System.Drawing.Size(40, 16);
            this.lb_timer.TabIndex = 16;
            this.lb_timer.Text = "00:00";
            // 
            // timerThi
            // 
            this.timerThi.Interval = 1000;
            // 
            // frmThiDoing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 693);
            this.Controls.Add(this.lb_timer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNopBai);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.rb_d);
            this.Controls.Add(this.rb_c);
            this.Controls.Add(this.rb_b);
            this.Controls.Add(this.rb_a);
            this.Controls.Add(this.radioGroup);
            this.Controls.Add(this.lb_question);
            this.Controls.Add(this.lb_index);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmThiDoing";
            this.Text = "frmTracNghiem";
            this.Load += new System.EventHandler(this.frmTracNghiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lb_index;
        private DevExpress.XtraEditors.LabelControl lb_question;
        private DevExpress.XtraEditors.RadioGroup radioGroup;
        private System.Windows.Forms.RadioButton rb_a;
        private System.Windows.Forms.RadioButton rb_b;
        private System.Windows.Forms.RadioButton rb_c;
        private System.Windows.Forms.RadioButton rb_d;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnNopBai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_timer;
        private System.Windows.Forms.Timer timerThi;
    }
}