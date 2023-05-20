using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using static System.Net.WebRequestMethods;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;
using System.Globalization;

namespace DrugStore
{
    public partial class FHomePage : Form
    {
        private string tendn;
        public FHomePage(string tendn)
        {
            InitializeComponent();
            this.tendn = tendn;
            this.MinimumSize = new System.Drawing.Size(900, 600);
        }

        
        BindingSource thuocList = new BindingSource();
        BindingSource khoThuocList = new BindingSource();
        BindingSource nccList = new BindingSource();
        BindingSource khachhangList = new BindingSource();
        BindingSource phieuNhapList = new BindingSource();
        BindingSource thuocPNHList = new BindingSource();
        BindingSource hoadonList = new BindingSource();
        BindingSource ThuocBanHangList = new BindingSource();
        BindingSource baoCaoHoaDonList = new BindingSource();
        DataTable dataTable_pnh, dataTable_banhang;
        HashSet<string> dsthuoc_pnh, dsthuoc_banhang;

        // Ẩn các panel
        void disable()
        {
            
            pnl_qlkh.Visible = false;
            pnl_qlncc.Visible = false;
            pnl_dspn.Visible = false;
            pnl_lapphieunhap.Visible = false;
            pnl_laphoadon.Visible = false;
            pnl_dmthuoc.Visible = false;
            pnl_khothuoc.Visible = false;
            pnl_bcdoanhthu.Visible = false;
            
            pnl_onqlnh.Visible = false;
            pnl_onqlbh.Visible = false;
            pnl_onqlkh.Visible = false;
            pnl_onqlncc.Visible = false;
            pnl_onbcthuoc.Visible = false;
            pnl_ondmthuoc.Visible = false;
            pnl_onkhothuoc.Visible = false;
            pnl_onbcdoanhthu.Visible = false;
            pnl_dshd.Visible= false;
        }
        // Đăng xuất
        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            
            FDangNhap f = new FDangNhap();
            f.Show();
            this.Hide();
        }

        private void FHomePage_Load(object sender, EventArgs e)
        {
            
            WindowState = FormWindowState.Maximized;
            pnl_onbcdoanhthu.Hide();
            pnl_onbcthuoc.Hide();
            pnl_onqlbh.Hide();
            pnl_onqlnh.Hide();
            

            
            dgv_dsthuoc.DataSource = thuocList;
            dgv_dsthuockt.DataSource = khoThuocList;
            dgv_ncc.DataSource = nccList;
            dgv_qlkh.DataSource = khachhangList;
            dgv_dspn.DataSource = phieuNhapList;
            dgv_dsthuoc_pnh.DataSource = thuocPNHList;
            dgv_dshd.DataSource = hoadonList;
            dgv_bh_danhMucThuoc.DataSource = ThuocBanHangList;
            dgv_doanhthu.DataSource = baoCaoHoaDonList;
            txt_tongTien.Text = string.Format("{0:C5}", txt_tongTien.Text);
            txtb_tienKhachDua.Text = string.Format("{0:C5}", txtb_tienKhachDua.Text);
            txtb_tienTraLai.Text = string.Format("{0:C5}", txtb_tienTraLai.Text);
            tb_tongdt.Text = string.Format("{0:C5}", txtb_tienTraLai.Text);
            //loadNhanVien();
            //loadThuoc();
            //loadKhoThuoc();
            //loadNCC();
            //loadKhachHang();
            //loadPhieuNhapHang();
            //loadHoaDon();
            //loadThuocBanHang();
        }

        // Load DataGridView
        public void loadThuoc()
        {
            thuocList.DataSource = ThuocBUS.Instance.getAllDrugs();
        }
        public void loadKhoThuoc()
        {
            khoThuocList.DataSource = KhoThuocBUS.Instance.getAllKhoThuoc();
            DateTime start = DateTime.Now;
            foreach (DataGridViewRow row in dgv_dsthuockt.Rows)
            {

                DateTime end = Convert.ToDateTime(row.Cells["HSD_KT"].Value);

                TimeSpan diff = end.Subtract(start);
                double days = diff.TotalDays;

                if (days <= 30)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    dgv_dsthuockt.Update();
                    this.dgv_dsthuockt.Refresh();
                }
                else if (days <= 90)
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                    dgv_dsthuockt.Update();
                    this.dgv_dsthuockt.Refresh();
                }
            }
            this.BindingContext[this.dgv_dsthuockt.DataSource].EndCurrentEdit();
            this.dgv_dsthuockt.Refresh(); // Make sure this comes first
        }
        public void loadNCC()
        {
            nccList.DataSource = NhaCungCapBUS.Instance.getAllNCC();
        }
        public void loadKhachHang()
        {
            khachhangList.DataSource = KhachHangBUS.Instance.getAllCustomer();
        }
        public void loadPhieuNhapHang()
        {
            phieuNhapList.DataSource = PhieuNhapHangBUS.Instance.getAllPhieuNhapHang();
        }
        public void loadThuocPNH(string mancc)
        {
            thuocPNHList.DataSource = ThuocBUS.Instance.getAllDrugsPNH(mancc);
        }
        public void loadHoaDon()
        {
            hoadonList.DataSource = HoaDonBUS.Instance.getAllHoaDon();
        }
        public void loadThuocBanHang()
        {
            ThuocBanHangList.DataSource = KhoThuocBUS.Instance.getAllThuocBanHang();
        }
        public void loadBaoCaoHD(String date1, String date2)
        {
            baoCaoHoaDonList.DataSource = HoaDonBUS.Instance.getAllHoaDonTheoNgay(date1, date2);
        }

        // Hiện quản lý nhà cung cấp
        private void btn_qlncc_Click(object sender, EventArgs e)
        {
            pnl_onqlncc.Height = btn_qlncc.Height;
            pnl_onqlncc.Top = btn_qlncc.Top;
            disable();
            loadNCC();
            pnl_qlncc.Visible = true;
            pnl_onqlncc.Visible = true;
        }
        // Thêm nhà cung cấp
        private void btn_themncc_Click(object sender, EventArgs e)
        {
            FAddNCC f = new FAddNCC(this);
            f.Show();
        }
        // Sửa nhà cung cấp
        private void btn_suancc_Click(object sender, EventArgs e)
        {
            if (dgv_ncc.RowCount > 0)
            {

                String mancc = dgv_ncc.CurrentRow.Cells["MANCC"].Value.ToString();
                String tenncc = dgv_ncc.CurrentRow.Cells["TENNCC1"].Value.ToString();
                String sdt = dgv_ncc.CurrentRow.Cells["SDTNCC"].Value.ToString();
                String diachi = dgv_ncc.CurrentRow.Cells["DIACHINCC"].Value.ToString();
                FAddNCC f = new FAddNCC(this, true, mancc, tenncc, sdt, diachi);
                f.Show();
            }
        }
        // Xóa nhà cung cấp
        private void btn_xoancc_Click(object sender, EventArgs e)
        {
            if (dgv_ncc.RowCount > 0)
            {

                string mancc = dgv_ncc.CurrentRow.Cells["MANCC"].Value.ToString();
                string tenncc = dgv_ncc.CurrentRow.Cells["TENNCC1"].Value.ToString();
                DialogResult res = MessageBox.Show("Xóa nhà cung cấp này thì mọi thuốc, chi tiết phiếu nhập hàng, chi tiết hóa đơn có liên quan sẽ bị xóa. Hành động này không thể hoàn tác", "Bạn có chắc là muốn xóa nhà cung cấp: " + tenncc, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    bool check = NhaCungCapBUS.Instance.deleteNCC(mancc);
                    if (check)
                    {
                        loadNCC();
                        loadThuoc();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhà cung cấp không thành công");
                    }
                }
                if (res == DialogResult.Cancel)
                {

                }
            }
        }

        // Hiện Quản lý nhập hàng
        private void btn_qlnh_Click(object sender, EventArgs e)
        {
            pnl_onqlnh.Height = btn_qlnh.Height;
            pnl_onqlnh.Top = btn_qlnh.Top;
            disable();
            loadPhieuNhapHang();
            pnl_dspn.Visible = true;
            pnl_onqlnh.Visible = true;
        }

        // Hiện Quản lý bán hàng
        private void btn_qlbh_Click(object sender, EventArgs e)
        {
            pnl_onqlbh.Height = btn_qlbh.Height;
            pnl_onqlbh.Top = btn_qlbh.Top;
            disable();
            loadHoaDon();
            pnl_dshd.Visible = true;
            pnl_onqlbh.Visible = true;
        }

        // Hiện quản lý khách hàng
        private void btn_qlkh_Click(object sender, EventArgs e)
        {
            pnl_onqlkh.Height = btn_qlkh.Height;
            pnl_onqlkh.Top = btn_qlkh.Top;
            disable();
            loadKhachHang();
            pnl_qlkh.Visible = true;
            pnl_onqlkh.Visible = true;
        }

        // Quản lý khách hàng
        private void btn_themkh_Click(object sender, EventArgs e)
        {
            FAddKhachHang fa = new FAddKhachHang(false, this);
            fa.Show();
        }

        private void btn_suakh_Click(object sender, EventArgs e)
        {
            if (dgv_qlkh.RowCount != 0)
            {

                string sdt = dgv_qlkh.CurrentRow.Cells["SDT_KH"].Value.ToString();
                string name = dgv_qlkh.CurrentRow.Cells["TENKH"].Value.ToString();
                FAddKhachHang fa = new FAddKhachHang(true, this, sdt, name);
                fa.Show();
            }
        }

        private void btn_xoakh_Click(object sender, EventArgs e)
        {
            if (dgv_qlkh.RowCount != 0)
            {
                string sdt = dgv_qlkh.CurrentRow.Cells["SDT_KH"].Value.ToString();
                DialogResult res = MessageBox.Show("Xóa khách hàng này không thể hoàn tác", "Bạn có chắc là muốn xóa khách hàng: "+sdt, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    bool check = KhachHangBUS.Instance.deleteCustomer(sdt);
                    if (check)
                    {
                        MessageBox.Show("Xóa khách hàng thành công");
                        loadKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Xóa khách hàng không thành công");
                    }
                }
            }
        }

        // Danh mục thuốc
        private void btn_dmthuoc_Click(object sender, EventArgs e)
        {
            pnl_onbcthuoc.Height = btn_bcthuoc.Height;
            pnl_onbcthuoc.Top = btn_bcthuoc.Top;
            pnl_ondmthuoc.Height = btn_dmthuoc.Height;
            pnl_ondmthuoc.Top = btn_dmthuoc.Top;
            disable();
            loadThuoc();
            pnl_dmthuoc.Visible = true;
            pnl_onbcthuoc.Visible = true;
            pnl_ondmthuoc.Visible = true;
        }

        private void exportExcel(DataGridView dgv)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel |*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                ToExcel(dgv, sfd.FileName);
            }
        }
        private void btn_export_dmt_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel |*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                ToExcel(dgv_dsthuoc, sfd.FileName);
            }
        }

        private void btn_themthuoc_Click_1(object sender, EventArgs e)
        {
            FAddThuoc fa = new FAddThuoc(this);
            fa.Show();
        }

        private void btn_suathuoc_Click(object sender, EventArgs e)
        {
            if (dgv_dsthuoc.RowCount > 0)
            {

                string sdk = dgv_dsthuoc.CurrentRow.Cells["SODK"].Value.ToString();
                string tenthuoc = dgv_dsthuoc.CurrentRow.Cells["TENTHUOC"].Value.ToString();
                string hoatchat = dgv_dsthuoc.CurrentRow.Cells["HOATCHAT"].Value.ToString();
                string donvitinh = dgv_dsthuoc.CurrentRow.Cells["DONVITINH"].Value.ToString();
                string qcdg = dgv_dsthuoc.CurrentRow.Cells["QUYCACHDONGGOI"].Value.ToString();
                string ncc = dgv_dsthuoc.CurrentRow.Cells["TENNCC"].Value.ToString();
                float gianhap = (float)Convert.ToDouble(dgv_dsthuoc.CurrentRow.Cells["GIANHAP"].Value);
                float giaban = (float)Convert.ToDouble(dgv_dsthuoc.CurrentRow.Cells["GIABAN"].Value);
                FAddThuoc f = new FAddThuoc(this, true, sdk, ncc, tenthuoc, hoatchat, donvitinh, qcdg, gianhap, giaban);
                f.Show();
            }
        }

        private void btn_xoathuoc_Click_1(object sender, EventArgs e)
        {
            if (dgv_dsthuoc.RowCount > 0)
            {

                string sodk = dgv_dsthuoc.CurrentRow.Cells["SODK"].Value.ToString();
                string tenthuoc = dgv_dsthuoc.CurrentRow.Cells["TENTHUOC"].Value.ToString();
                DialogResult res = MessageBox.Show("Xóa thuốc này thì mọi chi tiết hóa đơn liên quan đến thuốc này cũng sẽ bị xóa. Hành động này không thể hoàn tác.", "Bạn có chắc là muốn xóa: " + tenthuoc, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    bool check = ThuocBUS.Instance.deleteThuoc(sodk);
                    if (check)
                    {
                        MessageBox.Show("Xóa thuốc thành công");
                        loadThuoc();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thuốc không thành công");
                    }
                }
                if (res == DialogResult.Cancel)
                {

                }
            }
        }

        private void tb_timkiem_TextChanged(object sender, EventArgs e)
        {
            if (tb_timkiem.Text != "")
            {
                string text_search = tb_timkiem.Text.ToString();
                DataTable dt = ThuocBUS.Instance.timThuoc(text_search);
                dgv_dsthuoc.DataSource = dt;
            }
            else
            {
                dgv_dsthuoc.DataSource = thuocList;
            }
        }

        //Kho thuốc
        private void btn_khothuoc_Click(object sender, EventArgs e)
        {
            pnl_onbcthuoc.Height = btn_bcthuoc.Height;
            pnl_onbcthuoc.Top = btn_bcthuoc.Top;
            pnl_onkhothuoc.Height = btn_khothuoc.Height;
            pnl_onkhothuoc.Top = btn_khothuoc.Top;
            disable();
            loadKhoThuoc();
            pnl_khothuoc.Visible = true;
            pnl_onbcthuoc.Visible = true;
            pnl_onkhothuoc.Visible = true;
        }

        // Hiện báo cáo doanh thu
        private void btn_bcdoanhthu_Click(object sender, EventArgs e)
        {
            pnl_onbcdoanhthu.Height = btn_bcdoanhthu.Height;
            pnl_onbcdoanhthu.Top = btn_bcdoanhthu.Top;

            disable();
            pnl_bcdoanhthu.Visible = true;
            pnl_onbcdoanhthu.Visible = true;
        }

        // Quản lý nhập hàng
        private void btn_lapPhieuNhap_Click(object sender, EventArgs e)
        {
            dsthuoc_pnh = new HashSet<string>();
            tb_tongtiennh.Text = "";
            pnl_onqlnh.Height = btn_qlnh.Height;
            pnl_onqlnh.Top = btn_qlnh.Top;
            disable();
            tb_maphieu.Text = PhieuNhapHangBUS.Instance.getMaphieu();
            loadNCC();
            cbb_nccNH.DataSource = nccList;
            cbb_nccNH.DisplayMember = "TENNCC";
            cbb_nccNH.ValueMember = "MANCC";
            string mancc = cbb_nccNH.SelectedValue.ToString();
            loadThuocPNH(mancc);
            pnl_lapphieunhap.Visible = true;
            pnl_onqlnh.Visible = true;
            dataTable_pnh = new DataTable();
            dataTable_pnh.Columns.Add("SODK");
            dataTable_pnh.Columns.Add("TENTHUOC");
            dataTable_pnh.Columns.Add("GIANHAP");
            dataTable_pnh.Columns.Add("SOLUONGNHAP");
            dataTable_pnh.Columns.Add("HSD");
            dgv_phieunh.DataSource = dataTable_pnh;
        }
        private void tb_timkiemNH_TextChanged(object sender, EventArgs e)
        {
            if (tb_timkiemNH.Text.ToString() != "")
            {
                if (cbb_nccNH.SelectedValue != null)
                    dgv_dsthuoc_pnh.DataSource = BUS.ThuocBUS.Instance.timthuocNH(tb_timkiemNH.Text.ToString(), cbb_nccNH.SelectedValue.ToString());
            }
            else
            {
                dgv_dsthuoc_pnh.DataSource = thuocPNHList;

            }
        }
        private void btn_themthuoc_lappnh_Click(object sender, EventArgs e)
        {
            cbb_nccNH.ValueMember = "MANCC";
            string ncc = cbb_nccNH.SelectedValue.ToString();

            FAddThuoc f = new FAddThuoc(this, false, "", ncc, "", "", "", "", 0, 0);
            f.Show();
        }
        private void dgv_dspn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_dspn.Rows.Count != 0)
            {
                string maphieu = dgv_dspn.CurrentRow.Cells["MAPHIEU"].Value.ToString();
                dgv_ctpn.DataSource = ChiTietNhapHangBUS.Instance.getChiTietNhapHang(maphieu);
            }
        }
        private void btn_huylapphieu_Click(object sender, EventArgs e)
        {
            pnl_onqlnh.Height = btn_qlnh.Height;
            pnl_onqlnh.Top = btn_qlnh.Top;
            disable();
            pnl_dspn.Visible = true;
            pnl_onqlnh.Visible = true;
        }
        // Combobox ncc
        private void cbb_nccNH_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_nccNH.ValueMember = "MANCC";
            
            string mancc = cbb_nccNH.SelectedValue.ToString();
            if (((DataTable)dgv_phieunh.DataSource) != null)
            {
                ((DataTable)dgv_phieunh.DataSource).Clear();
            }    
            
            dgv_phieunh.Refresh();
            loadThuocPNH(mancc);
        }
        private void tinhTongGiaNhap()
        {
            double tonggianhap = 0;
            foreach (DataGridViewRow row in dgv_phieunh.Rows)
            {
                if (row.Cells["SOLUONGNHAP"].Value.ToString() != "")
                {
                    double gianhappnh = Convert.ToDouble(row.Cells["GIANHAPPNH1"].Value);
                    int soluong = Convert.ToInt32(row.Cells["SOLUONGNHAP"].Value);
                    tonggianhap = tonggianhap + soluong * gianhappnh;
                }
                else
                {
                    MessageBox.Show("Số lượng không được để trống");
                }
            }
            tb_tongtiennh.Text = tonggianhap.ToString();
        }
        // dgv bên trái
        private void dgv_dsthuoc_pnh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_dsthuoc_pnh.RowCount != 0)
            {

                string sodk = dgv_dsthuoc_pnh.CurrentRow.Cells["SODKPNH"].Value.ToString();
                string tenThuoc = dgv_dsthuoc_pnh.CurrentRow.Cells["TENTHUOCPNH"].Value.ToString();
                double gianhap = Convert.ToDouble(dgv_dsthuoc_pnh.CurrentRow.Cells["GIANHAPPNH"].Value);
                int soluongnhap = 1;
                DateTime hsd = DateTime.Now;

                if (!dsthuoc_pnh.Contains(sodk))
                {
                    dsthuoc_pnh.Add(sodk);
                    dataTable_pnh.Rows.Add(sodk, tenThuoc, gianhap, soluongnhap, hsd);
                    dgv_phieunh.DataSource = dataTable_pnh;
                    tinhTongGiaNhap();
                    dgv_dsthuoc_pnh.CurrentRow.DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }
        //DataGridView bên phải
        private void dgv_phieunh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_phieunh.RowCount != 0)
            {

                string sodk = dgv_phieunh.CurrentRow.Cells["SODKPNH1"].Value.ToString();
                dsthuoc_pnh.Remove(sodk);
                dgv_phieunh.Rows.Remove(dgv_phieunh.CurrentRow);
                ((DataTable)dgv_phieunh.DataSource).AcceptChanges();
                tinhTongGiaNhap();
                foreach (DataGridViewRow row in dgv_dsthuoc_pnh.Rows)
                {
                    if (row.Cells["SODKPNH"].Value.ToString() == sodk)
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }

        private void dgv_phieunh_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            tinhTongGiaNhap();
        }
        private void btn_lappnh_Click(object sender, EventArgs e) //
        {
            if (tb_tongtiennh.Text.ToString() != "" && cbb_nccNH.SelectedValue.ToString() != "")
            {
                string maphieu = tb_maphieu.Text;
                string mancc = cbb_nccNH.SelectedValue.ToString();
                DateTime nl = Convert.ToDateTime(dtp_ngaynh.Value);
                string ngaylap = nl.ToString("yyyy-MM-dd");
                double tonggianhap = Convert.ToDouble(tb_tongtiennh.Text);
                foreach (DataGridViewRow row in dgv_phieunh.Rows)
                {
                    if (row.Cells["SOLUONGNHAP"].Value.ToString() == "" || row.Cells["HSD"].Value.ToString() == "")
                    {
                        return;
                    }
                }
                bool check = PhieuNhapHangBUS.Instance.insertPhieuNhapHang(maphieu, mancc, ngaylap, tonggianhap);
                
                if (check)
                {
                    insertKhoThuoc();
                    disable();
                    loadPhieuNhapHang();
                    pnl_dspn.Visible = true;
                    
                }
            }
        }
        private void insertKhoThuoc()
        {
            string maphieu = tb_maphieu.Text;
            foreach (DataGridViewRow row in dgv_phieunh.Rows)
            {
                string sodk = Convert.ToString(row.Cells["SODKPNH1"].Value);
                int soluong = Convert.ToInt32(row.Cells["SOLUONGNHAP"].Value);
                DateTime hsddt = Convert.ToDateTime(row.Cells["HSD"].Value);
                string hsd = hsddt.ToString("yyyy-MM-dd");
                bool check = KhoThuocBUS.Instance.insertKhoThuoc(sodk, maphieu, hsd, soluong);
                bool check2 = ChiTietNhapHangBUS.Instance.insertChiTietNhapHang(maphieu, sodk, soluong);
            }
        }
        // dgv datetime picker
        private DateTimePicker dateTimePicker;
        private void dgv_phieunh_CellClick(object sender, DataGridViewCellEventArgs e) //
        {
            if (e.ColumnIndex == 4)
            {
                dateTimePicker = new DateTimePicker();
                dgv_phieunh.Controls.Add(dateTimePicker);
                dateTimePicker.Format = DateTimePickerFormat.Short;
                Rectangle rectangle = dgv_phieunh.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dateTimePicker.Size = new Size(rectangle.Width, rectangle.Height);
                dateTimePicker.Location = new Point(rectangle.X, rectangle.Y);
                dateTimePicker.CloseUp += new EventHandler(datetimepicker_closeup);
                dateTimePicker.TextChanged += new EventHandler(datetimepicker_textchanged);
                dateTimePicker.Visible = true;
            }
        }

        private void datetimepicker_textchanged(object? sender, EventArgs e)
        {
            dgv_phieunh.CurrentCell.Value = dateTimePicker.Value.ToString();
        }

        private void datetimepicker_closeup(object? sender, EventArgs e)
        {
            dateTimePicker.Visible = false;
        }
        // Validated
        private void dgv_phieunh_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)  //
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Soluong_KeyPress);
            if (dgv_phieunh.CurrentCell.ColumnIndex == 3)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Soluong_KeyPress);
                }
            }
        }
        private void Soluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Quản lý bán hàng
        private void btn_export_cthd_Click(object sender, EventArgs e)
        {
            exportExcel(dgv_cthd);
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            pnl_onqlbh.Height = btn_qlbh.Height;
            pnl_onqlbh.Top = btn_qlbh.Top;
            disable();
            pnl_dshd.Visible = true;
            pnl_onqlbh.Visible = true;
        }

        private void btn_laphd_qlbh_Click(object sender, EventArgs e)
        {
            dsthuoc_banhang = new HashSet<string>();
            txt_tongTien.Text = "";
            txtb_tienKhachDua.Text = "";
            txtb_tienTraLai.Text = "";
            pnl_onqlbh.Height = btn_qlbh.Height;
            pnl_onqlbh.Top = btn_qlbh.Top;
            disable();
            loadThuocBanHang();
            pnl_laphoadon.Visible = true;
            pnl_onqlbh.Visible = true;
            tb_maHoaDon.Text = BUS.HoaDonBUS.Instance.getMaHoaDon();
            dataTable_banhang = new DataTable();
            dataTable_banhang.Columns.Add("SODK");
            dataTable_banhang.Columns.Add("TENTHUOC");
            dataTable_banhang.Columns.Add("MAPHIEU");
            dataTable_banhang.Columns.Add("GIABAN");
            dataTable_banhang.Columns.Add("SOLUONG");
            dgv_bh_hoaDon.DataSource = dataTable_banhang;
        }

        private void txtb_tienKhachDua_TextChanged(object sender, EventArgs e)
        {
            if (txt_tongTien.Text != "" && txtb_tienKhachDua.Text != "")
                txtb_tienTraLai.Text = (Convert.ToDouble(txtb_tienKhachDua.Text) - Convert.ToDouble(txt_tongTien.Text)).ToString();
        }

        private void txt_tongTien_TextChanged(object sender, EventArgs e)
        {
            if (txt_tongTien.Text != "" && txtb_tienKhachDua.Text != "")
                txtb_tienTraLai.Text = (Convert.ToDouble(txtb_tienKhachDua.Text) - Convert.ToDouble(txt_tongTien.Text)).ToString();
        }

        private void tb_timKiemThuoc_TextChanged(object sender, EventArgs e)
        {
            String text = tb_timKiemThuoc.Text.ToString();
            if (!String.IsNullOrEmpty(text))
                dgv_bh_danhMucThuoc.DataSource = ThuocBUS.Instance.timThuocBH(text);
            else
                dgv_bh_danhMucThuoc.DataSource = ThuocBanHangList;

        }

        private void btn_luuhd_Click(object sender, EventArgs e)
        {
            if (txt_tongTien.Text.ToString() != "" && txtb_tienKhachDua.Text.ToString() != "" &&
                tb_sdt_qlbh.Text.ToString() != "")
            {
                string mahd = tb_maHoaDon.Text;
                string sdtkh = tb_sdt_qlbh.Text;
                string tenkh = tb_tenkh.Text;
                DateTime nx = Convert.ToDateTime(dtp_hoadon.Value);
                string ngayxuat = nx.ToString("yyyy-MM-dd");
                double tongtien = Convert.ToDouble(txt_tongTien.Text);
                foreach (DataGridViewRow row in dgv_bh_hoaDon.Rows)
                {
                    string sodk = row.Cells["SODK_HD"].Value.ToString();
                    string maphieu = row.Cells["MAPHIEU_HD"].Value.ToString();

                    if (row.Cells["SOLUONG_HD"].Value.ToString() == "")
                    {
                        MessageBox.Show("Chưa nhập số lượng");
                        return;
                    }
                    else if (Convert.ToInt32(row.Cells["SOLUONG_HD"].Value) > KhoThuocBUS.Instance.getSLKhoThuoc(sodk, maphieu))
                    {
                        MessageBox.Show("Số lượng trong hóa đơn nhiều hơn trong kho");
                        return;
                    }
                }

                List<string> listKH = new List<string>();
                DataTable dtkh = KhachHangBUS.Instance.getAllCustomer();
                foreach (DataRow dr in dtkh.Rows)
                {
                    listKH.Add(dr["SDT"].ToString());
                }
                if (!listKH.Contains(sdtkh))
                {
                    bool checkKH = KhachHangBUS.Instance.insertKhachHang(sdtkh, tenkh);
                }
                bool check = HoaDonBUS.Instance.insertHoaDon(mahd, sdtkh, ngayxuat, tongtien);
                
                if (check)
                {
                    loadHoaDon();
                    double diem = tongtien / 10000;
                    bool chechCongDiem = KhachHangBUS.Instance.updateDiem(sdtkh, diem);
                    
                    insertChiTietHoaDon();
                    
                    disable();
                    pnl_dshd.Visible = true;
                    tb_sdt_qlbh.Text = "";
                    tb_tenkh.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Còn thông tin chưa được nhập");
            }
        }
        private void insertChiTietHoaDon()
        {
            string mahd = tb_maHoaDon.Text;
            foreach (DataGridViewRow row in dgv_bh_hoaDon.Rows)
            {
                string sodk = Convert.ToString(row.Cells["SODK_HD"].Value);
                string maphieu = Convert.ToString(row.Cells["MAPHIEU_HD"].Value);
                int soluong = Convert.ToInt32(row.Cells["SOLUONG_HD"].Value);
                bool check = ChiTietHoaDonBUS.Instance.insertChiTietHoaDon(mahd, sodk, soluong);
                if (check)
                {
                    bool checkUpdateSL = KhoThuocBUS.Instance.updateSoLuong(sodk, maphieu, soluong);
                }
            }
        }

        private void dgv_bh_hoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_bh_hoaDon.RowCount > 0)
            {

                string sodk = dgv_bh_hoaDon.CurrentRow.Cells["SODK_HD"].Value.ToString();
                string maphieu = dgv_bh_hoaDon.CurrentRow.Cells["MAPHIEU_HD"].Value.ToString();
                dsthuoc_banhang.Remove(sodk);
                dgv_bh_hoaDon.Rows.Remove(dgv_bh_hoaDon.CurrentRow);
                ((DataTable)dgv_bh_hoaDon.DataSource).AcceptChanges();
                tinhTienBanHang();
                foreach (DataGridViewRow row in dgv_bh_danhMucThuoc.Rows)
                {
                    if (row.Cells["SODK_BH"].Value.ToString() == sodk &&
                        row.Cells["MAPHIEU_BH"].Value.ToString() == maphieu)
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }

        private void dgv_bh_hoaDon_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Soluong_KeyPress);
            if (dgv_bh_hoaDon.CurrentCell.ColumnIndex == 3)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Soluong_KeyPress);
                }
            }
        }

        private void txtb_tienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dgv_bh_hoaDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            tinhTienBanHang();
        }

        private void tinhTienBanHang()
        {
            double tongTien = 0;
            foreach (DataGridViewRow row in dgv_bh_hoaDon.Rows)
            {
                if (row.Cells["SOLUONG_HD"].Value.ToString() != "")
                {
                    double giaBan = Convert.ToDouble(row.Cells["GIABAN_HD"].Value);
                    int soluong = Convert.ToInt32(row.Cells["SOLUONG_HD"].Value);
                    tongTien += soluong * giaBan;
                }
                else
                {
                    MessageBox.Show("Số lượng không được để trống");
                }
            }
            txt_tongTien.Text = tongTien.ToString();
        }

        private void tb_sdt_qlbh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dgv_dshd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_dshd.Rows.Count != 0)
            {

                string mahd = dgv_dshd.CurrentRow.Cells["MAHD"].Value.ToString();
                dgv_cthd.DataSource = ChiTietHoaDonBUS.Instance.getChiTietHoaDon(mahd);
            }
        }

        private void btn_bcdoanhthu_importExcel_Click(object sender, EventArgs e)
        {
            exportExcel(dgv_doanhthu);
        }

        private void btn_thuocbanchay_Click(object sender, EventArgs e)
        {
            FThuocBanChay f = new FThuocBanChay();
            f.Show();
        }

        private void dgv_bh_danhMucThuoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_bh_danhMucThuoc.RowCount > 0)
            {

                string sodk = dgv_bh_danhMucThuoc.CurrentRow.Cells["SODK_BH"].Value.ToString();
                string tenThuoc = dgv_bh_danhMucThuoc.CurrentRow.Cells["TENTHUOC_BH"].Value.ToString();
                string maphieu = dgv_bh_danhMucThuoc.CurrentRow.Cells["MAPHIEU_BH"].Value.ToString();
                double giaban = Convert.ToDouble(dgv_bh_danhMucThuoc.CurrentRow.Cells["GIABAN_BH"].Value);
                int soluongnhap = 1;

                if (!dsthuoc_banhang.Contains(sodk))
                {
                    dsthuoc_banhang.Add(sodk);
                    dataTable_banhang.Rows.Add(sodk, tenThuoc, maphieu, giaban, soluongnhap);
                    dgv_bh_hoaDon.DataSource = dataTable_banhang;
                    tinhTienBanHang();
                    dgv_bh_danhMucThuoc.CurrentRow.DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }



        private void ToExcel(DataGridView dataGridView1, string fileName)
        {
            //khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            try
            {
                //Tạo đối tượng COM.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //tạo mới một Workbooks bằng phương thức add()
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                //đặt tên cho sheet
                worksheet.Name = "Quản lý học sinh";
                // export header trong DataGridView
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                // export nội dung trong DataGridView
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                worksheet.Columns.AutoFit();
                // sử dụng phương thức SaveAs() để lưu workbook với filename
                workbook.SaveAs(fileName);
                //đóng workbook
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }
        
        // Quản lý danh mục thuốc
        private void btn_thuoc1t_Click(object sender, EventArgs e)
        {
            khoThuocList.DataSource = BUS.KhoThuocBUS.Instance.thongKeThuocTrongKho(0, 30);
        }

        private void btn_thuoc3t_Click(object sender, EventArgs e)
        {
            khoThuocList.DataSource = BUS.KhoThuocBUS.Instance.thongKeThuocTrongKho(0, 90);

        }
        private void btn_thuocHH_Click(object sender, EventArgs e)
        {
            khoThuocList.DataSource = BUS.ThuocBUS.Instance.thongKeThuocHHTrongKho();
        }

        private void btn_thuochet_Click(object sender, EventArgs e)
        {
            khoThuocList.DataSource = BUS.KhoThuocBUS.Instance.getThuocSapHetHan();

        }

        private void btn_khothuoc_exportExcel_Click(object sender, EventArgs e)
        {
            exportExcel(dgv_dsthuockt);
        }

        private void pb_reload_khothuoc_Click(object sender, EventArgs e)
        {
            loadKhoThuoc();

        }

        private void tb_timkiemkt_TextChanged(object sender, EventArgs e)
        {
            if (tb_timkiemkt.Text != "")
            {
                string text_search = tb_timkiemkt.Text.ToString();
                DataTable dt = ThuocBUS.Instance.timThuocTrongKho(text_search);
                dgv_dsthuockt.DataSource = dt;
            }
            else
            {
                dgv_dsthuockt.DataSource = khoThuocList;

            }
        }

        private void pb_reload_dmt_Click(object sender, EventArgs e)
        {
            dgv_dsthuoc.DataSource = thuocList;

        }

        private void btn_dspn_importExcel_Click(object sender, EventArgs e)
        {
            exportExcel(dgv_ctpn);
        }

        // Thống kê thuốc
        void loadSoLuongVaTongTien(String date1, String date2)
        {
            string soluong = BUS.HoaDonBUS.Instance.getSoLuongHoaDonTheoNgay(date1, date2).ToString();
            string tongtien = BUS.HoaDonBUS.Instance.getTongTien(date1, date2).ToString();
            tb_slhd.Text = soluong;
            tb_tongdt.Text = tongtien;
        }
        private void dtp_ngaykt_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt1 = Convert.ToDateTime(dtp_ngaybd.Value);
            string date1 = dt1.ToString("yyyy-MM-dd");
            DateTime dt2 = Convert.ToDateTime(dtp_ngaykt.Value);
            string date2 = dt2.ToString("yyyy-MM-dd");
            loadBaoCaoHD(date1, date2);
            loadSoLuongVaTongTien(date1, date2);
        }

        private void btn_baocao_Click(object sender, EventArgs e)
        {
            DateTime dt1 = Convert.ToDateTime(dtp_ngaybd.Value);
            string date1 = dt1.ToString("yyyy-MM-dd");
            DateTime dt2 = Convert.ToDateTime(dtp_ngaykt.Value);
            string date2 = dt2.ToString("yyyy-MM-dd");
            loadBaoCaoHD(date1, date2);
            loadSoLuongVaTongTien(date1, date2);
        }

        // In

        private void btn_inphieunh_Click(object sender, EventArgs e)
        {
            // Khởi tạo PrintDocument
            PrintDocument printDocument = new PrintDocument();
            printDocument.DocumentName = "Phiếu nhập hàng";

            String maphieu = tb_maphieu.Text.ToString();
            String ngaylap = dtp_ngaynh.Text.ToString();
            String ncc = cbb_nccNH.Text.ToString();
            String tonggianhap = tb_tongtiennh.Text.ToString();

            if (ngaylap == "" || ncc == "" || tonggianhap == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin trước khi in");
                return;
            }

            // Sự kiện PrintPage
            printDocument.PrintPage += (s, args) =>
            {
                // Tiêu đề
                args.Graphics.DrawString("PHIẾU NHẬP HÀNG", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(250, 50));

                // Mã hóa đơn và ngày lập
                args.Graphics.DrawString(string.Format("Mã phiếu nhập: {0}\nNgày lập: {1}\nNhà cung cấp: {2}",
                    maphieu, ngaylap, ncc),
                    new Font("Arial", 12), Brushes.Black, new Point(50, 100));

                // Danh sách mặt hàng
                int y = 180;
                args.Graphics.DrawString("Số đăng ký", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(50, y));
                args.Graphics.DrawString("Tên thuốc", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(250, y));
                args.Graphics.DrawString("Giá nhập", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(450, y));
                args.Graphics.DrawString("Số lượng", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(650, y));
                args.Graphics.DrawString("HSD", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(850, y));
                y += 20;

                foreach (DataGridViewRow row in dgv_phieunh.Rows)
                {
                    args.Graphics.DrawString(row.Cells["SODKPNH1"].Value.ToString(), new Font("Arial", 12), Brushes.Black, new Point(50, y));
                    args.Graphics.DrawString(row.Cells["TENTHUOCPNH1"].Value.ToString(), new Font("Arial", 12), Brushes.Black, new Point(250, y));
                    args.Graphics.DrawString(row.Cells["GIANHAPPNH1"].Value.ToString(), new Font("Arial", 12), Brushes.Black, new Point(450, y));
                    args.Graphics.DrawString(row.Cells["SOLUONGNHAP"].Value.ToString(), new Font("Arial", 12), Brushes.Black, new Point(650, y));
                    args.Graphics.DrawString(row.Cells["HSD"].Value.ToString(), new Font("Arial", 12), Brushes.Black, new Point(850, y));
                    y += 20;
                }

                // Tổng tiền
                args.Graphics.DrawString(string.Format("Tổng tiền: {0}", tonggianhap), new Font("Arial", 12), Brushes.Black, new Point(400, y + 20));
            };

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            // Hiển thị hộp thoại preview
            DialogResult result = printPreviewDialog.ShowDialog();

            // Nếu nhấn nút In
            if (result == DialogResult.OK)
            {
                // Khởi tạo PrintDialog
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                // Hiển thị hộp thoại in
                result = printDialog.ShowDialog();

                // Nếu nhấn nút In
                if (result == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
        }

        private void btn_inHoaDon_Click(object sender, EventArgs e)
        {
            // Khởi tạo PrintDocument
            PrintDocument printDocument = new PrintDocument();
            printDocument.DocumentName = "Hóa đơn";

            String mahd = tb_maHoaDon.Text.ToString();
            String ngaylap = dtp_hoadon.Text.ToString();
            String sdtkh = tb_sdt_qlbh.Text.ToString();
            String tongtien = txt_tongTien.Text.ToString();

            if (ngaylap == "" || sdtkh == "" || tongtien == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin trước khi in");
                return;
            }

            // Sự kiện PrintPage
            printDocument.PrintPage += (s, args) =>
            {
                // Tiêu đề
                args.Graphics.DrawString("HÓA ĐƠN", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(250, 50));

                // Mã hóa đơn và ngày lập
                args.Graphics.DrawString(string.Format("Mã hóa đơn: {0}\nNgày lập: {1}\nSDT khách hàng: {2}", 
                    mahd, ngaylap, sdtkh), 
                    new Font("Arial", 12), Brushes.Black, new Point(50, 100));

                // Danh sách mặt hàng
                int y = 180;
                args.Graphics.DrawString("Tên thuốc", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(50, y));
                args.Graphics.DrawString("Đơn giá", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(250, y));
                args.Graphics.DrawString("Số lượng", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(400, y));
                y += 20;

                foreach (DataGridViewRow row in dgv_bh_hoaDon.Rows)
                {
                    args.Graphics.DrawString(row.Cells["TENTHUOC_HD"].Value.ToString(), new Font("Arial", 12), Brushes.Black, new Point(50, y));
                    args.Graphics.DrawString(row.Cells["GIABAN_HD"].Value.ToString(), new Font("Arial", 12), Brushes.Black, new Point(250, y));
                    args.Graphics.DrawString(row.Cells["SOLUONG_HD"].Value.ToString(), new Font("Arial", 12), Brushes.Black, new Point(400, y));
                    y += 20;
                }

                // Tổng tiền
                args.Graphics.DrawString(string.Format("Tổng tiền: {0}", tongtien), new Font("Arial", 12), Brushes.Black, new Point(400, y + 20));
            };

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            // Hiển thị hộp thoại preview
            DialogResult result = printPreviewDialog.ShowDialog();

            // Nếu nhấn nút In
            if (result == DialogResult.OK)
            {
                // Khởi tạo PrintDialog
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                // Hiển thị hộp thoại in
                result = printDialog.ShowDialog();

                // Nếu nhấn nút In
                if (result == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
        }
        

        // Đóng chương trình
        private void FHomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        // Đổi mật khẩu
        private void btn_doimk_Click(object sender, EventArgs e)
        {
            FDoiMK fDoiMK = new FDoiMK(this.tendn);
            fDoiMK.Show();
        }
    }
}
