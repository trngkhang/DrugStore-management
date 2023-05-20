namespace DrugStore
{
    partial class FDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDangNhap));
            this.tb_password = new System.Windows.Forms.TextBox();
            this.pb_eye = new System.Windows.Forms.PictureBox();
            this.lb_validate = new System.Windows.Forms.Label();
            this.pb_bgdangnhap = new System.Windows.Forms.PictureBox();
            this.pnl_matkhau = new System.Windows.Forms.Panel();
            this.pb_dangnhap = new System.Windows.Forms.PictureBox();
            this.lb_nhapmk = new System.Windows.Forms.Label();
            this.pnl_nhaptk = new System.Windows.Forms.Panel();
            this.tb_taikhoan = new System.Windows.Forms.TextBox();
            this.lb_taikhoan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_bgdangnhap)).BeginInit();
            this.pnl_matkhau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_dangnhap)).BeginInit();
            this.pnl_nhaptk.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_password
            // 
            this.tb_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(240)))), ((int)(((byte)(247)))));
            this.tb_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_password.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_password.Location = new System.Drawing.Point(0, 0);
            this.tb_password.Name = "tb_password";
            this.tb_password.PlaceholderText = "Nhập mật khẩu";
            this.tb_password.Size = new System.Drawing.Size(233, 34);
            this.tb_password.TabIndex = 0;
            this.tb_password.TextChanged += new System.EventHandler(this.tb_password_TextChanged);
            // 
            // pb_eye
            // 
            this.pb_eye.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(195)))), ((int)(((byte)(201)))));
            this.pb_eye.Image = global::DrugStore.Properties.Resources.eye;
            this.pb_eye.Location = new System.Drawing.Point(425, 155);
            this.pb_eye.Name = "pb_eye";
            this.pb_eye.Size = new System.Drawing.Size(34, 34);
            this.pb_eye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_eye.TabIndex = 2;
            this.pb_eye.TabStop = false;
            this.pb_eye.Click += new System.EventHandler(this.pb_eye_Click);
            // 
            // lb_validate
            // 
            this.lb_validate.AutoSize = true;
            this.lb_validate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_validate.ForeColor = System.Drawing.Color.Red;
            this.lb_validate.Location = new System.Drawing.Point(249, 203);
            this.lb_validate.Name = "lb_validate";
            this.lb_validate.Size = new System.Drawing.Size(210, 21);
            this.lb_validate.TabIndex = 4;
            this.lb_validate.Text = "Sai tài khoản hoặc mật khẩu!";
            // 
            // pb_bgdangnhap
            // 
            this.pb_bgdangnhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_bgdangnhap.Image = ((System.Drawing.Image)(resources.GetObject("pb_bgdangnhap.Image")));
            this.pb_bgdangnhap.Location = new System.Drawing.Point(0, 0);
            this.pb_bgdangnhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb_bgdangnhap.Name = "pb_bgdangnhap";
            this.pb_bgdangnhap.Size = new System.Drawing.Size(509, 302);
            this.pb_bgdangnhap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_bgdangnhap.TabIndex = 5;
            this.pb_bgdangnhap.TabStop = false;
            // 
            // pnl_matkhau
            // 
            this.pnl_matkhau.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnl_matkhau.Controls.Add(this.tb_password);
            this.pnl_matkhau.Location = new System.Drawing.Point(187, 154);
            this.pnl_matkhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_matkhau.Name = "pnl_matkhau";
            this.pnl_matkhau.Size = new System.Drawing.Size(233, 35);
            this.pnl_matkhau.TabIndex = 1;
            // 
            // pb_dangnhap
            // 
            this.pb_dangnhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_dangnhap.Image = ((System.Drawing.Image)(resources.GetObject("pb_dangnhap.Image")));
            this.pb_dangnhap.Location = new System.Drawing.Point(365, 255);
            this.pb_dangnhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb_dangnhap.Name = "pb_dangnhap";
            this.pb_dangnhap.Size = new System.Drawing.Size(134, 38);
            this.pb_dangnhap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_dangnhap.TabIndex = 7;
            this.pb_dangnhap.TabStop = false;
            this.pb_dangnhap.Click += new System.EventHandler(this.pb_dangnhap_Click);
            // 
            // lb_nhapmk
            // 
            this.lb_nhapmk.AutoSize = true;
            this.lb_nhapmk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(195)))), ((int)(((byte)(201)))));
            this.lb_nhapmk.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_nhapmk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(255)))), ((int)(((byte)(114)))));
            this.lb_nhapmk.Location = new System.Drawing.Point(60, 158);
            this.lb_nhapmk.Name = "lb_nhapmk";
            this.lb_nhapmk.Size = new System.Drawing.Size(107, 28);
            this.lb_nhapmk.TabIndex = 3;
            this.lb_nhapmk.Text = "Mật khẩu:";
            // 
            // pnl_nhaptk
            // 
            this.pnl_nhaptk.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnl_nhaptk.Controls.Add(this.tb_taikhoan);
            this.pnl_nhaptk.Location = new System.Drawing.Point(187, 97);
            this.pnl_nhaptk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_nhaptk.Name = "pnl_nhaptk";
            this.pnl_nhaptk.Size = new System.Drawing.Size(233, 35);
            this.pnl_nhaptk.TabIndex = 0;
            // 
            // tb_taikhoan
            // 
            this.tb_taikhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(240)))), ((int)(((byte)(247)))));
            this.tb_taikhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_taikhoan.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_taikhoan.Location = new System.Drawing.Point(0, 0);
            this.tb_taikhoan.Name = "tb_taikhoan";
            this.tb_taikhoan.PlaceholderText = "Nhập tài khoản";
            this.tb_taikhoan.Size = new System.Drawing.Size(233, 34);
            this.tb_taikhoan.TabIndex = 0;
            this.tb_taikhoan.TextChanged += new System.EventHandler(this.tb_taikhoan_TextChanged);
            // 
            // lb_taikhoan
            // 
            this.lb_taikhoan.AutoSize = true;
            this.lb_taikhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(195)))), ((int)(((byte)(201)))));
            this.lb_taikhoan.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_taikhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(255)))), ((int)(((byte)(114)))));
            this.lb_taikhoan.Location = new System.Drawing.Point(60, 101);
            this.lb_taikhoan.Name = "lb_taikhoan";
            this.lb_taikhoan.Size = new System.Drawing.Size(108, 28);
            this.lb_taikhoan.TabIndex = 2;
            this.lb_taikhoan.Text = "Tài khoản:";
            // 
            // FDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 302);
            this.Controls.Add(this.lb_taikhoan);
            this.Controls.Add(this.pnl_nhaptk);
            this.Controls.Add(this.lb_nhapmk);
            this.Controls.Add(this.pb_dangnhap);
            this.Controls.Add(this.pnl_matkhau);
            this.Controls.Add(this.lb_validate);
            this.Controls.Add(this.pb_eye);
            this.Controls.Add(this.pb_bgdangnhap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FDangNhap_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_eye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_bgdangnhap)).EndInit();
            this.pnl_matkhau.ResumeLayout(false);
            this.pnl_matkhau.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_dangnhap)).EndInit();
            this.pnl_nhaptk.ResumeLayout(false);
            this.pnl_nhaptk.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox tb_password;
        private PictureBox pb_eye;
        private Label lb_validate;
        private PictureBox pb_bgdangnhap;
        private Panel pnl_matkhau;
        private PictureBox pb_dangnhap;
        private Label lb_nhapmk;
        private Panel pnl_nhaptk;
        private TextBox tb_taikhoan;
        private Label lb_taikhoan;
    }
}