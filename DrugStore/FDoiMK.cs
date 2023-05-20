using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrugStore
{
    public partial class FDoiMK : Form
    {
        private string tendn;
        public FDoiMK(string tendn)
        {
            InitializeComponent();
            this.tendn = tendn;
        }
        private static bool isClick = true;
        private void pb_eye_Click(object sender, EventArgs e)
        {
            isClick = !isClick;
            tb_mkcu.UseSystemPasswordChar = isClick;
            tb_mkmoi.UseSystemPasswordChar = isClick;
            tb_mkmoi2.UseSystemPasswordChar = isClick;
        }

        private void FDoiMK_Load(object sender, EventArgs e)
        {
            pb_luu.Parent = pb_bgdoimk;
            pb_huy.Parent = pb_bgdoimk;
            pb_luu.BackColor = Color.Transparent;
            pb_huy.BackColor = Color.Transparent;
            lb_validate.Text = "";
            tb_mkcu.UseSystemPasswordChar = isClick;
            tb_mkmoi.UseSystemPasswordChar = isClick;
            tb_mkmoi2.UseSystemPasswordChar = isClick;
        }

        private void tb_mkcu_TextChanged(object sender, EventArgs e)
        {
            lb_validate.Text = "";
        }

        private void pb_luu_Click(object sender, EventArgs e)
        {
            string mkcu = tb_mkcu.Text.ToString();
            string mkmoi = tb_mkmoi.Text.ToString();
            string mkmoi2 = tb_mkmoi2.Text.ToString();
            if (mkcu == "" || mkmoi == "" || mkmoi2 == "")
            {
                lb_validate.Text = "Xin nhập đầy đủ mật khẩu!";
            }
            else if (mkmoi != mkmoi2)
            {
                lb_validate.Text = "Mật khẩu mới không trùng khớp";
            }
            else if (mkcu == mkmoi)
            {
                lb_validate.Text = "Mật khẩu mới trùng mật khẩu cũ";
            }
            else
            {
                TaiKhoan nv = null;
                nv = TaiKhoanBUS.Instance.checkAccount(this.tendn, mkcu);
                if (nv != null)
                {
                    bool check = TaiKhoanBUS.Instance.doiMatKhau(mkcu, mkmoi);
                    if (check)
                    {
                        this.Close();
                        MessageBox.Show("Đổi mật khẩu thành công");
                    }
                    else
                    {
                        MessageBox.Show("Đổi mật khẩu KHÔNG thành công");
                    }
                }
                else
                {
                    lb_validate.Text = "Mật khẩu cũ sai!";
                }
            }
        }

        private void pb_huy_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
