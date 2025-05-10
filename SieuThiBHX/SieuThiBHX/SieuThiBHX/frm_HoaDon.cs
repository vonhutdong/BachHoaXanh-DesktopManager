using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace SieuThiBHX
{
    public partial class frm_HoaDon : Form
    {
        public frm_HoaDon()
        {
            InitializeComponent();
        }
        BUS_HoaDon bus_hd = new BUS_HoaDon();
        BUS_KhachHang bus_kh = new BUS_KhachHang();
        BUS_KhuyenMai bus_km = new BUS_KhuyenMai();
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        private void Reset()
        {
            cboMaKH.SelectedIndex = -1;
            cboMaKM.SelectedIndex = -1;
            cboMaNV.SelectedIndex = -1;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }


        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void menuToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        public void LoadData()
        {
            // Test số lượng cột
            dgvHD.DataSource = bus_hd.GetListHD();

            // Đặt tiêu đề các cột
            dgvHD.Columns[0].HeaderText = "Id";
            dgvHD.Columns[1].HeaderText = "Mã hóa đơn";
            dgvHD.Columns[2].HeaderText = "Ngày lập hóa đơn";
            dgvHD.Columns[3].HeaderText = "Giờ lập hóa đơn";
            dgvHD.Columns[4].HeaderText = "Tổng tiền";
            dgvHD.Columns[5].HeaderText = "Thành tiền";
            dgvHD.Columns[6].HeaderText = "Mã khuyến mãi";      
            dgvHD.Columns[7].HeaderText = "Mã khách hàng";
            dgvHD.Columns[8].HeaderText = "Mã nhân viên";
            dgvHD.Columns[9].HeaderText = "Tên khách hàng";
            dgvHD.Columns[10].HeaderText = "Tên khuyến mãi";
            dgvHD.Columns[11].HeaderText = "Tên nhân viên";

            // Format ngày & giờ
            dgvHD.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvHD.Columns[3].DefaultCellStyle.Format = "HH:mm:ss";

            // Ẩn/hiện cột
            dgvHD.Columns[0].Visible = false;  // id
            dgvHD.Columns[1].Visible = true;   // mã HD
            dgvHD.Columns[2].Visible = true;   // ngày
            dgvHD.Columns[3].Visible = true;   // giờ
            dgvHD.Columns[4].Visible = true;   // tổng tiền
            dgvHD.Columns[5].Visible = true;   // thành tiền
            dgvHD.Columns[6].Visible = false;  // mã KM
            dgvHD.Columns[7].Visible = false;  // mã KH
            dgvHD.Columns[8].Visible = false;  // mã NV
            dgvHD.Columns[9].Visible = true;   // tên KH
            dgvHD.Columns[10].Visible = true; // tên KM
            dgvHD.Columns[11].Visible = true;  // tên NV

            // Cbo khách hàng
            cboMaKH.DataSource = bus_kh.LayDSKH();
            cboMaKH.DisplayMember = "TenKH";
            cboMaKH.ValueMember = "id";
            cboMaKH.SelectedIndex = 0;

            // Cbo nhân viên
            cboMaNV.DataSource = bus_nv.LayDSNhanVien();
            cboMaNV.DisplayMember = "TenNhanVien";
            cboMaNV.ValueMember = "id";
            cboMaNV.SelectedIndex = 0;

            // Cbo khuyến mãi
            cboMaKM.DataSource = bus_km.GetListKM();
            cboMaKM.DisplayMember = "TenKhuyenMai";
            cboMaKM.ValueMember = "id";
            cboMaKM.SelectedIndex = 0;

            // Button trạng thái
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
        }


        private void frm_HoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHD.CurrentRow != null)
            {
                int id = int.Parse(dgvHD.CurrentRow.Cells["id"].Value.ToString());

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa hóa đơn này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    if (bus_hd.DelHD(id))
                    {
                        MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Reload danh sách hóa đơn
                    }
                    else
                    {
                        MessageBox.Show("Xóa hóa đơn thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHD.CurrentRow != null)
            {
                int id = int.Parse(dgvHD.CurrentRow.Cells["id"].Value.ToString());

                // Lấy id từ các combobox
                int idKH = Convert.ToInt32(cboMaKH.SelectedValue);
                int idKM = Convert.ToInt32(cboMaKM.SelectedValue);
                int idNV = Convert.ToInt32(cboMaNV.SelectedValue);

                // Tạo DTO_HoaDon
                DTO_HoaDon hd = new DTO_HoaDon(id, idKH, idKM, idNV);

                // Gọi BUS cập nhật
                if (bus_hd.updateHD(hd))
                {
                    MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật hóa đơn thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 dòng để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvHD_Click(object sender, EventArgs e)
        {
            if (dgvHD.CurrentCell != null)
            {
                // Get row index selected
                int n = dgvHD.CurrentCell.RowIndex;

                // Other
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                // cboMaKH
                cboMaKH.DataSource = bus_kh.LayDSKH();
                cboMaKH.DisplayMember = "TenKH";
                cboMaKH.ValueMember = "id";
                cboMaKH.SelectedIndex = int.Parse(dgvHD.Rows[n].Cells[6].Value.ToString()) - 1;

                // cboMaKM
                cboMaKM.DataSource = bus_km.GetListKM();
                cboMaKM.DisplayMember = "TenKhuyenMai";
                cboMaKM.ValueMember = "id";
                cboMaKM.SelectedIndex = int.Parse(dgvHD.Rows[n].Cells[7].Value.ToString()) - 1;

                // cboMaNV
                cboMaNV.DataSource = bus_nv.LayDSNhanVien();
                cboMaNV.DisplayMember = "TenNhanVien";
                cboMaNV.ValueMember = "id";
                cboMaNV.SelectedIndex = int.Parse(dgvHD.Rows[n].Cells[8].Value.ToString()) - 1;
            }
            else
            {
                // Messaged
                MessageBox.Show("Vui lòng chọn 1 dòng để xóa hoặc sửa thông tin!", "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Reset();
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string RemoveDiacritics(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            var normalized = input.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        private void btnTimHD_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimHD.Text.Trim();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                dgvHD.DataSource = bus_hd.TimKiemHD(tuKhoa);
            }
            else
            {
                LoadData(); // nếu không nhập gì thì load lại toàn bộ
            }
        }
    }
}
