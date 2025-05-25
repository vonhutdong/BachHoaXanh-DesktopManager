using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace SieuThiBHX.Trong
{
    public partial class frmPhieuNhap : Form
    {
        public frmPhieuNhap()
        {
            InitializeComponent();
            txtThanhTien.Text = "0";
            txtThanhTien.Enabled = false;
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
        }


        BUS_ChiTietPhieuNhap bus_ctpn = new BUS_ChiTietPhieuNhap();
        BUS_PhieuNhapAll bus_pn = new BUS_PhieuNhapAll();
        BUS_PhieuNhapAll bus_pnALL = new BUS_PhieuNhapAll();
        int currentID = -1;
        string data_olds = string.Empty;
        string data_news = string.Empty;
        private void LoadDataPhieuNhap()
        {
            btnThemPN.Enabled = true;
            btnThemCTPN.Enabled = true;
            btnSuaPN.Enabled = false;
            btnSuaCTPN.Enabled = false;
            btnXoa.Enabled = false;
            dgvPhieuNhap.DataSource = bus_pnALL.LayDSPhieuNhap();

            //đổi tên cột
            dgvPhieuNhap.Columns["MaPhieuNhap"].HeaderText = "Mã phiếu nhập";
            dgvPhieuNhap.Columns["NgayNhap"].HeaderText = "Ngày nhập";
            dgvPhieuNhap.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgvPhieuNhap.Columns["MaNhanVien"].HeaderText = "Nhân viên";
            dgvPhieuNhap.Columns["id"].Visible = false;


            // Thiết lập lại style để dữ liệu hiện rõ
            dgvPhieuNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhieuNhap.ColumnHeadersHeight = 40; // hoặc cao hơn
            dgvPhieuNhap.DefaultCellStyle.BackColor = Color.White;
            dgvPhieuNhap.DefaultCellStyle.ForeColor = Color.Black;
            dgvPhieuNhap.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvPhieuNhap.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvPhieuNhap.EnableHeadersVisualStyles = false;
            dgvPhieuNhap.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvPhieuNhap.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            cbNhanVien.DataSource = bus_pnALL.LayDSNhanVien();
            cbNhanVien.DisplayMember = "TenNhanVien";
            cbNhanVien.ValueMember = "id";
            //cb san pham

        }
        private void LoadDataChiTietPN()
        {
            //btnThemPN.Enabled = true;
            //btnThemCTPN.Enabled = true;
            //btnSuaPN.Enabled = false;
            //btnSuaCTPN.Enabled = false;
            //btnXoa.Enabled = false;

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



        private void dgvPhieuNhap_Click(object sender, EventArgs e)
        {
            int n = dgvPhieuNhap.CurrentCell.RowIndex;

            if (n >= 0)
            {
                // dtpNgayNhap
                dtpNgayNhap.Text = dgvPhieuNhap.Rows[n].Cells["NgayNhap"].Value.ToString();

                // txtThanhTien
                txtThanhTien.Text = dgvPhieuNhap.Rows[n].Cells["ThanhTien"].Value.ToString();

                //cbNhanVien
                //cbNhanVien.Text = dgvPhieuNhap.Rows[n].Cells["MaNhanVien"].Value.ToString();
                cbNhanVien.SelectedIndex = int.Parse(dgvPhieuNhap.Rows[n].Cells["MaNhanVien"].Value.ToString()) - 1;

                //ID
                currentID = int.Parse(dgvPhieuNhap.Rows[n].Cells["id"].Value.ToString());

            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 dòng để xóa hoặc sửa thông tin!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            btnThemCTPN.Enabled = false;
            btnThemPN.Enabled = false;
            btnSuaPN.Enabled = true;
            btnXoa.Enabled = true;
            btnSuaCTPN.Enabled = false;
        }
        public bool CheckNumber(string n)
        {
            if (n == string.Empty)
            {
                return false;
            }
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] >= '0' && n[i] <= '9')
                {
                    return true;
                }
            }
            return false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbNhanVien.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idNhanVien = Convert.ToInt32(cbNhanVien.SelectedValue);

                // Gọi phương thức thêm phiếu nhập (thanh tiền mặc định = 0, sẽ cập nhật sau theo chi tiết phiếu)
                bool result = bus_pnALL.ThemPhieuNhap(new DTO_PhieuNhap(dtpNgayNhap.Value, 0, idNhanVien));

                if (result)
                {
                    MessageBox.Show("Thêm phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataPhieuNhap();
                    LoadDataChiTietPN();
                }
                else
                {
                    MessageBox.Show("Thêm phiếu nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào đang được chọn ở Chi tiết phiếu nhập trước không
                if (dgvChiTietPhieuNhap.Focused && dgvChiTietPhieuNhap.CurrentRow != null)
                {
                    // === XÓA CHI TIẾT PHIẾU NHẬP ===
                    if (currentID > 0)
                    {
                        DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa chi tiết của phiếu: [{cbMaPhieuNhap.Text}] không?",
                                                              "Xác nhận",
                                                              MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            int idPhieuNhap = Convert.ToInt32(cbMaPhieuNhap.SelectedValue);

                            bus_ctpn.XoaChiTiet(currentID, idPhieuNhap);

                            MessageBox.Show("Xóa chi tiết thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataPhieuNhap();
                            LoadDataChiTietPN();
                            currentID = -1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn chi tiết cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (dgvPhieuNhap.Focused && dgvPhieuNhap.CurrentRow != null)
                {
                    // === XÓA PHIẾU NHẬP ===
                    int currentId = int.Parse(dgvPhieuNhap.CurrentRow.Cells["id"].Value.ToString());
                    if (!string.IsNullOrWhiteSpace(txtThanhTien.Text))
                    {
                        DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa phiếu nhập không?",
                                                          "Xác nhận",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Warning);

                        if (dr == DialogResult.Yes)
                        {
                            bus_pnALL.XoaPhieuNhap(currentId);
                            MessageBox.Show("Xóa phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataPhieuNhap();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn phiếu nhập cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {

                if (CheckNumber(txtThanhTien.Text))
                {
                    //Sửa loại hàng
                    bus_pnALL.SuaPN(new DTO_PhieuNhap(currentID, dtpNgayNhap.Value, float.Parse(txtThanhTien.Text), int.Parse(cbNhanVien.SelectedIndex.ToString()) + 1));
                    MessageBox.Show("Sửa thành công!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //làm mới
                    LoadDataPhieuNhap();
                    LoadDataChiTietPN();

                }
                else
                {
                    MessageBox.Show("Thành tiền phải là số!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            catch (Exception ex)
            {
                //thông báo khi có lỗi xảy ra
                MessageBox.Show(ex.Message, "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {

            dtpNgayNhap.Value = DateTime.Now;
            txtThanhTien.Text = string.Empty;
            cbNhanVien.SelectedIndex = 0;
            txtThanhTien.Text = "0";
            txtSoLuong.Text = string.Empty;
            txtDonGia.Text = string.Empty;
            cbMaPhieuNhap.SelectedIndex = 0;
            cbTenSanPham.SelectedIndex = 0;
            LoadDataChiTietPN();
            LoadDataPhieuNhap();
        }

        private void frmPhieuNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void frmPhieuNhap_Load_1(object sender, EventArgs e)
        {
            LoadDataPhieuNhap();
            LoadDataChiTietPN();
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
            btnThemCTPN.Enabled = false;
            btnThemPN.Enabled = false;
            btnSuaPN.Enabled = false;
            btnXoa.Enabled = true;
            btnSuaCTPN.Enabled = true;
        }

        private void btnThemCTPN_Click(object sender, EventArgs e)
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

                    // Lưu lại mã phiếu nhập đã chọn
                    var selectedMaPhieuNhap = cbMaPhieuNhap.SelectedValue;

                    LoadDataPhieuNhap();     // Cập nhật lại danh sách phiếu nhập
                    LoadDataChiTietPN();     // Cập nhật danh sách chi tiết

                    // Gán lại giá trị đã chọn
                    cbMaPhieuNhap.SelectedValue = selectedMaPhieuNhap;
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

        private void btnSuaCTPN_Click(object sender, EventArgs e)
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
                    // Lưu lại mã phiếu nhập đã chọn
                    var selectedMaPhieuNhap = cbMaPhieuNhap.SelectedValue;

                    LoadDataPhieuNhap();     // Cập nhật lại danh sách phiếu nhập
                    LoadDataChiTietPN();     // Cập nhật danh sách chi tiết

                    // Gán lại giá trị đã chọn
                    cbMaPhieuNhap.SelectedValue = selectedMaPhieuNhap;
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

        private void inThongKePhieuNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frm_ThongKeTheoMaPhieuNhap f = new frm_ThongKeTheoMaPhieuNhap();
            //f.MdiParent = this;
            f.Show();

        }

        private void inDanhSachPhieuNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_InDanhSachPN f = new frm_InDanhSachPN();
            //f.MdiParent = this;
            f.Show();
        }
    }
}
