using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace SieuThiBHX.NhutDong
{
    public partial class frmSanPham : Form
    {
        //khoi tao
        int idNhaCungCap = 1;
        //bus nhà loại hàng
       BUS_LoaiHang bus_loaihang = new BUS_LoaiHang();
        //bus sản phẩm
        BUS_SanPham bus_sanpham = new BUS_SanPham();
        //di san pham hien tai
        int currentID = 0;
        //binary img data
        byte[] imageData = null;
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            try
            {
                guna2GroupBox3.Text = string.Empty;
                //mặc định combobox select dữ liệu đầu
                
                //gọi load combobox loại hàng
                LoadCBLoaiHang();
                //gọi load combobox nhà cung cấp
                LoadCBNhaCungCap();
                //gọi load danh sách sản phẩm
                LoadDSSanPham();
                cbNhaCungCap.SelectedIndex = 0;
                cbMaNhomHang.SelectedIndex = 0;
                //custom
                dtpHanSuDung.CustomFormat = "dd/MM/yyyy";
                dtpNgaySanXuat.CustomFormat = "dd/MM/yyyy";
                dtpHanSuDung.MinDate = dtpNgaySanXuat.Value;

                dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dgvSanPham.ColumnHeadersHeight = 30; // hoặc cao hơn

                // Thiết lập lại style để dữ liệu hiện rõ
                dgvSanPham.DefaultCellStyle.BackColor = Color.White;
                dgvSanPham.DefaultCellStyle.ForeColor = Color.Black;
                dgvSanPham.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dgvSanPham.DefaultCellStyle.SelectionForeColor = Color.Black;

                dgvSanPham.EnableHeadersVisualStyles = false;
                dgvSanPham.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
                dgvSanPham.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            }
            catch (Exception ex)
            {
                //show thông báo khi có lỗi
                MessageBox.Show(ex.Message, "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDSSanPham()
        {
            //goi bus load danh sahc
            dgvSanPham.DataSource = bus_sanpham.LoadDSSanPham();
            //ẩn cột
            dgvSanPham.Columns["id"].Visible = false;
            dgvSanPham.Columns["idNhaCungCap"].Visible = false;
            dgvSanPham.Columns["idLoaiHang"].Visible = false;
            dgvSanPham.Columns["AnhSanPham"].Visible = false;
            dgvSanPham.Columns["NhaCungCap"].Visible = false;
            dgvSanPham.Columns["LoaiHang"].Visible = false;
            //đôi tên header
            dgvSanPham.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgvSanPham.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dgvSanPham.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            dgvSanPham.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvSanPham.Columns["NgaySanXuat"].HeaderText = "Ngày sản xuất";
            dgvSanPham.Columns["HanSuDung"].HeaderText = "Hạn sử dụng";
            //format date
            dgvSanPham.Columns["NgaySanXuat"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvSanPham.Columns["HanSuDung"].DefaultCellStyle.Format = "dd/MM/yyyy";

        }
        private void LoadCBNhaCungCap()
        {
            cbNhaCungCap.DataSource = bus_sanpham.LoadNCC();
            cbNhaCungCap.DisplayMember = "TenNhaCungCap";
            cbNhaCungCap.ValueMember = "id";
        }
        private void LoadCBLoaiHang()
        {
            cbMaNhomHang.DataSource = bus_loaihang.LayDSLH();
            cbMaNhomHang.DisplayMember = "TenLoaiHang";
            cbMaNhomHang.ValueMember = "id";
        }
        private byte[] ConvertImageToByteArray(string filePath)
        {
            // Đọc file ảnh và chuyển thành mảng byte
            return File.ReadAllBytes(filePath);
        }
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                    ofd.Title = "Chọn tệp ảnh";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        // Hiển thị ảnh trong PictureBox
                        imgSanPham.Image = Image.FromFile(ofd.FileName);
                        imgSanPham.SizeMode = PictureBoxSizeMode.StretchImage;
                        // Chuyển đổi ảnh thành mảng byte
                        imageData = ConvertImageToByteArray(ofd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                //thông báo khi có lỗi xảy ra
                MessageBox.Show(ex.Message, "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy dòng đang click
                int dong = dgvSanPham.CurrentRow.Index;
                //điền thông tin lên textbox
                txtMaSanPham.Text = dgvSanPham.Rows[dong].Cells["MaSanPham"].Value.ToString();
                txtTenSanPham.Text = dgvSanPham.Rows[dong].Cells["TenSanPham"].Value.ToString();
                txtDonViTinh.Text = dgvSanPham.Rows[dong].Cells["DonViTinh"].Value.ToString();
                txtDonGia.Text = dgvSanPham.Rows[dong].Cells["DonGia"].Value.ToString();
                cbMaNhomHang.SelectedValue = int.Parse(dgvSanPham.Rows[dong].Cells["idLoaiHang"].Value.ToString());
                cbNhaCungCap.SelectedValue = int.Parse(dgvSanPham.Rows[dong].Cells["idNhaCungCap"].Value.ToString());
                dtpNgaySanXuat.Text = dgvSanPham.Rows[dong].Cells["NgaySanXuat"].Value.ToString();
                dtpHanSuDung.Text = dgvSanPham.Rows[dong].Cells["HanSuDung"].Value.ToString();

                //đổi binary thành ảnh
                var data = dgvSanPham.Rows[dong].Cells["AnhSanPham"].Value;
                // Kiểm tra kiểu dữ liệu của imageData
                if (data != null)
                {
                    if (data is System.Data.Linq.Binary binaryData)
                    {
                        byte[] byteArray = binaryData.ToArray(); // Chuyển đổi sang byte array
                                                                 //gán giá trị để kiểm tra
                        imageData = byteArray;
                        using (MemoryStream ms = new MemoryStream(byteArray))
                        {
                            Image image = Image.FromStream(ms);
                            imgSanPham.Image = image; // Gán hình ảnh vào PictureBox
                        }
                    }
                }
                else
                {
                    imgSanPham.Image = null;
                }

                //lấy id click
                currentID = int.Parse(dgvSanPham.Rows[dong].Cells["id"].Value.ToString());
                //MessageBox.Show(currentID.ToString());
            }
            catch (Exception ex)
            {

                //thông báo khi có lỗi xảy ra
                MessageBox.Show(ex.Message, "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static Image ConvertToImage(System.Data.Linq.Binary iBinary)
        {
            var arrayBinary = iBinary.ToArray();
            Image rImage = null;

            using (MemoryStream ms = new MemoryStream(arrayBinary))
            {
                rImage = Image.FromStream(ms);
            }
            return rImage;
        }
        private void LamMoi()
        {
            //làm sạch textbox
            txtMaSanPham.Clear();
            txtTenSanPham.Clear();
            txtDonViTinh.Clear();
            txtDonGia.Clear();
            txtMaSanPham.Focus();
            //reset image
            imgSanPham.Image = null;
            //load lại danh sách sản phẩm
            LoadDSSanPham();

        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if (currentID != 0)
                {
                    bus_sanpham.XoaSanPham(currentID);
                    LamMoi();
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                }
                else
                {
                    //thông báo khi chưa chọn dữ liệu xóa
                    MessageBox.Show("Vui lòng chọn dữ liệu cần xóa!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

            private void btnSua_Click(object sender, EventArgs e)
            {
                MessageBox.Show($"{int.Parse(cbMaNhomHang.SelectedValue.ToString())}");

                try
                {
                int idLoaiHang = Convert.ToInt32(cbMaNhomHang.SelectedValue);
                int idNhaCungCap = Convert.ToInt32(cbNhaCungCap.SelectedValue);

                if (txtMaSanPham.Text.Length > 0 &&
                  txtTenSanPham.Text.Length > 0 &&
                  txtDonViTinh.Text.Length > 0 &&
                  txtDonGia.Text.Length > 0
                  && imageData != null)
                    {
                        //thêm loại hàng
                        bus_sanpham.SuaSanPham(new DTO_SanPham(currentID, txtMaSanPham.Text,
                                                                 txtTenSanPham.Text,
                                                                    txtDonViTinh.Text,
                                                                    float.Parse(txtDonGia.Text),
                                                                    dtpNgaySanXuat.Value.Date,
                                                                    dtpHanSuDung.Value.Date,
                                                                    //idLoaiHang,
                                                                    //idNhaCungCap,
                                                                    Convert.ToInt32(cbMaNhomHang.SelectedValue.ToString()),
                                                                    Convert.ToInt32(cbNhaCungCap.SelectedValue.ToString()),
                                                                    imageData
                            ));
                        MessageBox.Show("Sửa thành công thành công!", "Thoát", MessageBoxButtons.OK);
                        //làm mới
                        LamMoi();
                    }
                    else
                    {
                        //thông báo khi chưa đầy đủ dữ liệu
                        MessageBox.Show("Nhập đầy đủ dữ liệu!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    //thông báo khi có lỗi xảy ra
                    MessageBox.Show(ex.Message, "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaSanPham.Text.Length > 0 &&
              txtTenSanPham.Text.Length > 0 &&
              txtDonViTinh.Text.Length > 0 &&
              txtDonGia.Text.Length > 0
              && imageData != null)
                {
                    //thêm loại hàng
                    bus_sanpham.ThemSanPham(new DTO_SanPham(txtMaSanPham.Text,
                                                             txtTenSanPham.Text,
                                                                txtDonViTinh.Text,
                                                                float.Parse(txtDonGia.Text),
                                                                dtpNgaySanXuat.Value.Date,
                                                                dtpHanSuDung.Value.Date,
                                                                int.Parse(cbMaNhomHang.SelectedValue.ToString()),
                                                                int.Parse(cbNhaCungCap.SelectedValue.ToString()),
                                                                imageData
                        ));

                    MessageBox.Show("Thêm thành công!", "Thoát", MessageBoxButtons.OK);
                    //làm mới
                    LamMoi();
                }
                else
                {
                    //thông báo khi chưa đầy đủ dữ liệu
                    MessageBox.Show("Nhập đầy đủ dữ liệu!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //thông báo khi có lỗi xảy ra
                MessageBox.Show(ex.Message, "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar != Keys.Back && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                txtDonGia.Focus();
            }
        }

        private void dtpNgaySanXuat_ValueChanged(object sender, EventArgs e)
        {
            dtpHanSuDung.MinDate = dtpNgaySanXuat.Value;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn chắc thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }
    }
}
