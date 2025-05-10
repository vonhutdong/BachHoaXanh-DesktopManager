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

namespace SieuThiBHX
{
    public partial class frmChiTietPhieuNhap : Form
    {
        public frmChiTietPhieuNhap()
        {
            InitializeComponent();
        }
        BUS_ChiTietPhieuNhap bus_ctpn = new BUS_ChiTietPhieuNhap();
        BUS_PhieuNhapAll bus_pn = new BUS_PhieuNhapAll();
        int currentID = -1;
        string data_olds = string.Empty;
        string data_news = string.Empty;

        private void LoadData()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            dgvChiTietPhieuNhap.DataSource = bus_ctpn.LayDSCTPN();

            //đổi tên cột
            dgvChiTietPhieuNhap.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvChiTietPhieuNhap.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvChiTietPhieuNhap.Columns["idPhieuNhap"].HeaderText = "mã phiếu nhập";
            dgvChiTietPhieuNhap.Columns["idSanPham"].HeaderText = "Tên sản phẩm";
            dgvChiTietPhieuNhap.Columns["id"].Visible = false;
            dgvChiTietPhieuNhap.Columns["idpn"].Visible = false;
            dgvChiTietPhieuNhap.Columns["idsp"].Visible = false;
            dgvChiTietPhieuNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietPhieuNhap.ColumnHeadersHeight = 40; // hoặc cao hơn
            // Thiết lập lại style để dữ liệu hiện rõ
            dgvChiTietPhieuNhap.DefaultCellStyle.BackColor = Color.White;
            dgvChiTietPhieuNhap.DefaultCellStyle.ForeColor = Color.Black;
            dgvChiTietPhieuNhap.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvChiTietPhieuNhap.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvChiTietPhieuNhap.EnableHeadersVisualStyles = false;
            dgvChiTietPhieuNhap.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvChiTietPhieuNhap.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            cbMaPhieuNhap.DataSource = bus_pn.LayDSPhieuNhap();
            cbMaPhieuNhap.DisplayMember = "MaPhieuNhap";
            cbMaPhieuNhap.ValueMember = "ID";
            cbMaPhieuNhap.SelectedIndex = 0;

            //cbMaPhieuNhap.DataSource = bus_pn.LayDSPhieuNhap();
            //cbMaPhieuNhap.DisplayMember = "idSanPham";
            //cbMaPhieuNhap.ValueMember = "idSanPham";

            cbTenSanPham.DataSource = bus_ctpn.LayDSSP();
            cbTenSanPham.DisplayMember = "TenSanPham";
            cbTenSanPham.ValueMember = "id";
            cbTenSanPham.SelectedIndex = 0;
        }

        private void frmChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvChiTietPhieuNhap_Click(object sender, EventArgs e)
        {
            int n = dgvChiTietPhieuNhap.CurrentCell.RowIndex;

            if (n >= 0)
            {

                txtSoLuong.Text = dgvChiTietPhieuNhap.Rows[n].Cells["SoLuong"].Value.ToString();

                txtDonGia.Text = dgvChiTietPhieuNhap.Rows[n].Cells["DonGia"].Value.ToString();

                cbMaPhieuNhap.SelectedValue = int.Parse(dgvChiTietPhieuNhap.Rows[n].Cells["idpn"].Value.ToString());
                cbTenSanPham.SelectedValue = int.Parse(dgvChiTietPhieuNhap.Rows[n].Cells["idsp"].Value.ToString());


                //ID
                currentID = int.Parse(dgvChiTietPhieuNhap.Rows[n].Cells["id"].Value.ToString());

            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 dòng để xóa hoặc sửa thông tin!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || string.IsNullOrWhiteSpace(txtDonGia.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin số lượng và đơn giá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên dương.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!float.TryParse(txtDonGia.Text, out float donGia) || donGia < 0)
                {
                    MessageBox.Show("Đơn giá phải là số hợp lệ và không âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra giá trị chọn trong combobox
                if (cbMaPhieuNhap.SelectedValue == null || cbTenSanPham.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn mã phiếu nhập và tên sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DTO_ChiTietPhieuNhap ct = new DTO_ChiTietPhieuNhap
                {
                    IdPhieuNhap = Convert.ToInt32(cbMaPhieuNhap.SelectedValue),
                    IdSanPham = Convert.ToInt32(cbTenSanPham.SelectedValue),
                    SoLuong = soLuong,
                    DonGia = donGia
                };

                if (bus_ctpn.ThemChiTiet(ct))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không thể thêm chi tiết phiếu nhập.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình thêm chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            

            if (currentID > 0)
            {
                //Hỏi
                //Hỏi
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa: [{cbMaPhieuNhap.Text}] không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int idPhieuNhap = Convert.ToInt32(cbMaPhieuNhap.SelectedValue); // <== THÊM DÒNG NÀY

                    //gọi hàm xóa chi tiết
                    bus_ctpn.XoaChiTiet(currentID, idPhieuNhap);

                    //Thông báo
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //làm mới
                    LoadData();
                    currentID = -1;
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào trước
                if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || string.IsNullOrWhiteSpace(txtDonGia.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ số lượng và đơn giá!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên dương!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!float.TryParse(txtDonGia.Text, out float donGia) || donGia < 0)
                {
                    MessageBox.Show("Đơn giá phải là số hợp lệ!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DTO_ChiTietPhieuNhap ct = new DTO_ChiTietPhieuNhap
                {
                    Id = currentID,
                    IdPhieuNhap = Convert.ToInt32(cbMaPhieuNhap.SelectedValue),
                    IdSanPham = Convert.ToInt32(cbTenSanPham.SelectedValue),
                    SoLuong = soLuong,
                    DonGia = donGia
                };

                if (bus_ctpn.SuaChiTiet(ct))
                {
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không thể sửa chi tiết phiếu nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtSoLuong.Text = string.Empty;
            txtDonGia.Text = string.Empty;
            cbMaPhieuNhap.SelectedIndex = 0;
            cbTenSanPham.SelectedIndex = 0;
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChiTietPhieuNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

     
    }
}
