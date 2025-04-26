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
    public partial class frmKhuyenMai : Form
    {
        BUS_KhuyenMai bus_km = new BUS_KhuyenMai();
        string data_olds = string.Empty;
        string data_news = string.Empty;
        public frmKhuyenMai()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            // Others
            txtTenKhuyenMai.Focus();
            
            txtTenKhuyenMai.Text = string.Empty;
            txtGiaTri.Text = "";
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            data_olds = string.Empty;
            data_news = string.Empty;

            // dgvKM
            dgvKhuyenMai.DataSource = bus_km.GetListKM();
            dgvKhuyenMai.Columns["id"].Visible = false;
            dgvKhuyenMai.Columns["id"].HeaderText = "Id";
            dgvKhuyenMai.Columns["MaKhuyenMai"].Visible = true;
            dgvKhuyenMai.Columns["MaKhuyenMai"].HeaderText = "Mã khuyến mãi";
            dgvKhuyenMai.Columns["TenKhuyenMai"].HeaderText = "Tên khuyến mãi";
            dgvKhuyenMai.Columns["GiaTri"].HeaderText = "Giá trị";
            dgvKhuyenMai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhuyenMai.ColumnHeadersHeight = 40; // hoặc cao hơn

            // Thiết lập lại style để dữ liệu hiện rõ
            dgvKhuyenMai.DefaultCellStyle.BackColor = Color.White;
            dgvKhuyenMai.DefaultCellStyle.ForeColor = Color.Black;
            dgvKhuyenMai.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvKhuyenMai.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvKhuyenMai.EnableHeadersVisualStyles = false;
            dgvKhuyenMai.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvKhuyenMai.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }

        private void frmKhuyenMai_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            try
            {
                string tenKm = txtTenKhuyenMai.Text.Trim();
                string giaTriText = txtGiaTri.Text.Trim();

                if (string.IsNullOrWhiteSpace(tenKm) || string.IsNullOrWhiteSpace(giaTriText))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin khuyến mãi.", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!float.TryParse(giaTriText, out float giaTri))
                {
                    MessageBox.Show("Giá trị khuyến mãi phải là số hợp lệ.", "Lỗi định dạng",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (giaTri <= 0)
                {
                    MessageBox.Show("Giá trị khuyến mãi phải lớn hơn 0.", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo DTO
                DTO_KhuyenMai km = new DTO_KhuyenMai
                {
                    TenKhuyenMai = txtTenKhuyenMai.Text,
                    GiaTri = float.Parse(txtGiaTri.Text)
                };

                // Gọi BUS
                bus_km.AdddKhuyenMai(km);

                MessageBox.Show("Thêm khuyến mãi thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (FormatException)
            {
                MessageBox.Show("Giá trị khuyến mãi phải là số hợp lệ.", "Lỗi định dạng",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvKhuyenMai.CurrentRow != null)
                {
                    int id = Convert.ToInt32(dgvKhuyenMai.CurrentRow.Cells["id"].Value);
                    string tenKm = txtTenKhuyenMai.Text.Trim();
                    string giaTriText = txtGiaTri.Text.Trim();

                    if (string.IsNullOrWhiteSpace(tenKm) || string.IsNullOrWhiteSpace(giaTriText))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin khuyến mãi.", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!float.TryParse(giaTriText, out float giaTri))
                    {
                        MessageBox.Show("Giá trị khuyến mãi phải là số hợp lệ.", "Lỗi định dạng",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (giaTri <= 0)
                    {
                        MessageBox.Show("Giá trị khuyến mãi phải lớn hơn 0.", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DTO_KhuyenMai km = new DTO_KhuyenMai
                    {
                        Id = id,
                        TenKhuyenMai = tenKm,
                        GiaTri = giaTri
                    };

                    bus_km.UpdateKhuyenMai(km);

                    MessageBox.Show("Cập nhật khuyến mãi thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvKhuyenMai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                var row = dgvKhuyenMai.Rows[index];

                txtTenKhuyenMai.Text = row.Cells["TenKhuyenMai"].Value.ToString();
                txtGiaTri.Text = row.Cells["GiaTri"].Value.ToString();

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (dgvKhuyenMai.CurrentRow != null)
                {
                    int id = Convert.ToInt32(dgvKhuyenMai.CurrentRow.Cells["id"].Value);
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa khuyến mãi này không?", "Xác nhận",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bus_km.DeleteTaiKhoan(id);
                        MessageBox.Show("Xóa khuyến mãi thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenKhuyenMai.Clear();
            txtGiaTri.Clear();

            // Đặt lại trạng thái nút
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void frmKhuyenMai_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}


