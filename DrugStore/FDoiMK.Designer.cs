namespace DrugStore
{
    partial class FDoiMK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDoiMK));
            this.tb_mkcu = new System.Windows.Forms.TextBox();
            this.tb_mkmoi = new System.Windows.Forms.TextBox();
            this.tb_mkmoi2 = new System.Windows.Forms.TextBox();
            this.lb_validate = new System.Windows.Forms.Label();
            this.pb_eye = new System.Windows.Forms.PictureBox();
            this.pb_bgdoimk = new System.Windows.Forms.PictureBox();
            this.pnl_mkcu = new System.Windows.Forms.Panel();
            this.pnl_mkmoi = new System.Windows.Forms.Panel();
            this.pnl_mkmoi2 = new System.Windows.Forms.Panel();
            this.pb_luu = new System.Windows.Forms.PictureBox();
            this.pb_huy = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_bgdoimk)).BeginInit();
            this.pnl_mkcu.SuspendLayout();
            this.pnl_mkmoi.SuspendLayout();
            this.pnl_mkmoi2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_luu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_huy)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_mkcu
            // 
            this.tb_mkcu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(240)))), ((int)(((byte)(247)))));
            this.tb_mkcu.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_mkcu.Location = new System.Drawing.Point(0, 0);
            this.tb_mkcu.Name = "tb_mkcu";
            this.tb_mkcu.PlaceholderText = "Nhập mật khẩu cũ";
            this.tb_mkcu.Size = new System.Drawing.Size(230, 32);
            this.tb_mkcu.TabIndex = 0;
            this.tb_mkcu.TextChanged += new System.EventHandler(this.tb_mkcu_TextChanged);
            // 
            // tb_mkmoi
            // 
            this.tb_mkmoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(240)))), ((int)(((byte)(247)))));
            this.tb_mkmoi.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_mkmoi.Location = new System.Drawing.Point(0, 0);
            this.tb_mkmoi.Name = "tb_mkmoi";
            this.tb_mkmoi.PlaceholderText = "Nhập mật khẩu mới";
            this.tb_mkmoi.Size = new System.Drawing.Size(230, 32);
            this.tb_mkmoi.TabIndex = 1;
            this.tb_mkmoi.TextChanged += new System.EventHandler(this.tb_mkcu_TextChanged);
            // 
            // tb_mkmoi2
            // 
            this.tb_mkmoi2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(240)))), ((int)(((byte)(247)))));
            this.tb_mkmoi2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_mkmoi2.Location = new System.Drawing.Point(0, 0);
            this.tb_mkmoi2.Name = "tb_mkmoi2";
            this.tb_mkmoi2.PlaceholderText = "Nhập lại mật khẩu mới";
            this.tb_mkmoi2.Size = new System.Drawing.Size(230, 32);
            this.tb_mkmoi2.TabIndex = 2;
            this.tb_mkmoi2.TextChanged += new System.EventHandler(this.tb_mkcu_TextChanged);
            // 
            // lb_validate
            // 
            this.lb_validate.AutoSize = true;
            this.lb_validate.BackColor = System.Drawing.SystemColors.Control;
            this.lb_validate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_validate.ForeColor = System.Drawing.Color.Red;
            this.lb_validate.Location = new System.Drawing.Point(197, 224);
            this.lb_validate.Name = "lb_validate";
            this.lb_validate.Size = new System.Drawing.Size(196, 21);
            this.lb_validate.TabIndex = 5;
            this.lb_validate.Text = "Xin nhập đầy đủ mật khẩu!";
            // 
            // pb_eye
            // 
            this.pb_eye.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(195)))), ((int)(((byte)(201)))));
            this.pb_eye.Image = global::DrugStore.Properties.Resources.eye;
            this.pb_eye.Location = new System.Drawing.Point(149, 106);
            this.pb_eye.Name = "pb_eye";
            this.pb_eye.Size = new System.Drawing.Size(34, 34);
            this.pb_eye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_eye.TabIndex = 6;
            this.pb_eye.TabStop = false;
            this.pb_eye.Click += new System.EventHandler(this.pb_eye_Click);
            // 
            // pb_bgdoimk
            // 
            this.pb_bgdoimk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_bgdoimk.Image = ((System.Drawing.Image)(resources.GetObject("pb_bgdoimk.Image")));
            this.pb_bgdoimk.Location = new System.Drawing.Point(0, 0);
            this.pb_bgdoimk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb_bgdoimk.Name = "pb_bgdoimk";
            this.pb_bgdoimk.Size = new System.Drawing.Size(597, 340);
            this.pb_bgdoimk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_bgdoimk.TabIndex = 7;
            this.pb_bgdoimk.TabStop = false;
            // 
            // pnl_mkcu
            // 
            this.pnl_mkcu.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnl_mkcu.Controls.Add(this.tb_mkcu);
            this.pnl_mkcu.Location = new System.Drawing.Point(197, 106);
            this.pnl_mkcu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_mkcu.Name = "pnl_mkcu";
            this.pnl_mkcu.Size = new System.Drawing.Size(229, 34);
            this.pnl_mkcu.TabIndex = 8;
            // 
            // pnl_mkmoi
            // 
            this.pnl_mkmoi.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnl_mkmoi.Controls.Add(this.tb_mkmoi);
            this.pnl_mkmoi.Location = new System.Drawing.Point(197, 149);
            this.pnl_mkmoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_mkmoi.Name = "pnl_mkmoi";
            this.pnl_mkmoi.Size = new System.Drawing.Size(229, 34);
            this.pnl_mkmoi.TabIndex = 9;
            // 
            // pnl_mkmoi2
            // 
            this.pnl_mkmoi2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnl_mkmoi2.Controls.Add(this.tb_mkmoi2);
            this.pnl_mkmoi2.Location = new System.Drawing.Point(197, 191);
            this.pnl_mkmoi2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_mkmoi2.Name = "pnl_mkmoi2";
            this.pnl_mkmoi2.Size = new System.Drawing.Size(229, 34);
            this.pnl_mkmoi2.TabIndex = 10;
            // 
            // pb_luu
            // 
            this.pb_luu.BackColor = System.Drawing.Color.Transparent;
            this.pb_luu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_luu.Image = ((System.Drawing.Image)(resources.GetObject("pb_luu.Image")));
            this.pb_luu.Location = new System.Drawing.Point(306, 288);
            this.pb_luu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb_luu.Name = "pb_luu";
            this.pb_luu.Size = new System.Drawing.Size(134, 38);
            this.pb_luu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_luu.TabIndex = 11;
            this.pb_luu.TabStop = false;
            this.pb_luu.Click += new System.EventHandler(this.pb_luu_Click);
            // 
            // pb_huy
            // 
            this.pb_huy.BackColor = System.Drawing.Color.Transparent;
            this.pb_huy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_huy.Image = ((System.Drawing.Image)(resources.GetObject("pb_huy.Image")));
            this.pb_huy.Location = new System.Drawing.Point(452, 288);
            this.pb_huy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb_huy.Name = "pb_huy";
            this.pb_huy.Size = new System.Drawing.Size(134, 38);
            this.pb_huy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_huy.TabIndex = 12;
            this.pb_huy.TabStop = false;
            this.pb_huy.Click += new System.EventHandler(this.pb_huy_Click);
            // 
            // FDoiMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 340);
            this.Controls.Add(this.pb_huy);
            this.Controls.Add(this.pb_luu);
            this.Controls.Add(this.pnl_mkmoi2);
            this.Controls.Add(this.pnl_mkmoi);
            this.Controls.Add(this.pnl_mkcu);
            this.Controls.Add(this.pb_eye);
            this.Controls.Add(this.lb_validate);
            this.Controls.Add(this.pb_bgdoimk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FDoiMK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.FDoiMK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_eye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_bgdoimk)).EndInit();
            this.pnl_mkcu.ResumeLayout(false);
            this.pnl_mkcu.PerformLayout();
            this.pnl_mkmoi.ResumeLayout(false);
            this.pnl_mkmoi.PerformLayout();
            this.pnl_mkmoi2.ResumeLayout(false);
            this.pnl_mkmoi2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_luu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_huy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tb_mkcu;
        private TextBox tb_mkmoi;
        private TextBox tb_mkmoi2;
        private Label lb_validate;
        private PictureBox pb_eye;
        private PictureBox pb_bgdoimk;
        private Panel pnl_mkcu;
        private Panel pnl_mkmoi;
        private Panel pnl_mkmoi2;
        private PictureBox pb_luu;
        private PictureBox pb_huy;
    }
}