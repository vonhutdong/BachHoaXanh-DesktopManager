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

namespace SieuThiBHX.NhutDong
{
    public partial class frmLoaiNhanVien : Form
    {
        BUS_LoaiNhanVien bus_lnv = new BUS_LoaiNhanVien();
        DataValidation dv = new DataValidation();
        string data_olds = string.Empty;
        string data_news = string.Empty;
        public frmLoaiNhanVien()
        {
            InitializeComponent();
        }
        void loadDATA()
        {
            // Others
            txtTenLoaiNhanVien.Focus();
            txtTenLoaiNhanVien.Text = string.Empty;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            // dgvLNV
            dgvLoaiNV.DataSource = bus_lnv.GetListLNV();
            dgvLoaiNV.Columns["id"].Visible = false;
            dgvLoaiNV.Columns["MaLoaiNhanVien"].Visible = true;
            dgvLoaiNV.Columns["Id"].HeaderText = "Id";
            dgvLoaiNV.Columns["MaLoaiNhanVien"].HeaderText = "Mã loại nhân viên";
            dgvLoaiNV.Columns["TenLoaiNhanVien"].HeaderText = "Tên loại nhân viên";


            dgvLoaiNV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoaiNV.ColumnHeadersHeight = 30; // hoặc cao hơn

            // Thiết lập lại style để dữ liệu hiện rõ
            dgvLoaiNV.DefaultCellStyle.BackColor = Color.White;
            dgvLoaiNV.DefaultCellStyle.ForeColor = Color.Black;
            dgvLoaiNV.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvLoaiNV.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvLoaiNV.EnableHeadersVisualStyles = false;
            dgvLoaiNV.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvLoaiNV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }
        public bool CheckData(string tenLNV)
        {
            // Initialize Variables
            int count = 0;

            // Checked tenLNV
            if (dv.CheckString(tenLNV, 100))
            {
                count += 1;
            }
            else
            {
                MessageBox.Show($"Tên loại nhân viên: [{tenLNV}] không quá 100 kí tự!",
                   "Thông báo",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
            }

            if (count == 1)
            {
                return true;
            }
            return false;
        }
        private void frmLoaiNhanVien_Load(object sender, EventArgs e)
        {
            loadDATA();
        }

        private void dgvLoaiNV_Click(object sender, EventArgs e)
        {
            if (dgvLoaiNV.CurrentCell != null)
            {
                // Get row index selected
                int n = dgvLoaiNV.CurrentCell.RowIndex;

                // Other
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                txtTenLoaiNhanVien.Text = dgvLoaiNV.Rows[n].Cells[2].Value.ToString();
            }
            else
            {
                // Messaged
                MessageBox.Show("Vui lòng chọn 1 dòng để xóa hoặc sửa thông tin!", "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckData(txtTenLoaiNhanVien.Text))
                {
                    // Thêm loại nhân viên
                    bus_lnv.AddLNV2(new DTO_LoaiNhanVien(txtTenLoaiNhanVien.Text));

                    // Lấy mã loại nhân viên mới
                    int model_id = bus_lnv.GetMaxIdLNV();

                    // Thông báo thành công
                    MessageBox.Show($"Thêm loại nhân viên thành công!\n" +
                                    $"Mã loại nhân viên: {model_id}\n" +
                                    $"Tên loại nhân viên: {txtTenLoaiNhanVien.Text}",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    // Load lại DataGridView
                    loadDATA();

                    // Xoá ô nhập (nếu muốn)
                    txtTenLoaiNhanVien.Clear();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ!", "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Initialize Variables
                int currentId = int.Parse(dgvLoaiNV.CurrentRow.Cells[0].Value.ToString());


                if (CheckData(txtTenLoaiNhanVien.Text))
                {
                    DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa: [{txtTenLoaiNhanVien.Text}] không?",
                        "Thông báo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (dr == DialogResult.Yes)
                    {
                        bool query = bus_lnv.DelLNV(currentId);
                        if (query)
                        {
                            MessageBox.Show($"Xóa loại nhân viên thành công!\n" +
                                $"Mã loại nhân viên: {currentId}\n" +
                                $"Tên loại nhân viên: {txtTenLoaiNhanVien.Text}",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Xóa loại nhân viên không thành công!\n" +
                                $"Mã loại nhân viên: {currentId}\n" +
                                $"Tên loại nhân viên: {txtTenLoaiNhanVien.Text}",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        loadDATA();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ!", "Thông báo",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLoaiNV.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một loại nhân viên để sửa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int currentId = int.Parse(dgvLoaiNV.CurrentRow.Cells[0].Value.ToString());
                string currentName = dgvLoaiNV.CurrentRow.Cells[1].Value?.ToString() ?? "";
                string newTenLoai = txtTenLoaiNhanVien.Text.Trim();

                data_olds = $"TenLoaiNhanVien: {currentName}";
                data_news = $"TenLoaiNhanVien: {newTenLoai}";

                if (CheckData(newTenLoai))
                {
                    DialogResult dr = MessageBox.Show($"Bạn có chắc muốn sửa thông tin: [{newTenLoai}] không?",
                       "Thông báo",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Warning);

                    if (dr == DialogResult.Yes)
                    {
                        var dto = new DTO_LoaiNhanVien(currentId, newTenLoai);
                        bool query = bus_lnv.UpdateLNV2(dto);
                        if (query)
                        {
                            MessageBox.Show($"Sửa loại nhân viên thành công!\n" +
                                $"Mã loại nhân viên: {currentId}\n" +
                                $"Tên loại nhân viên: {newTenLoai}",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            loadDATA();
                        }
                        else
                        {
                            MessageBox.Show($"Sửa loại nhân viên không thành công!\n" +
                                $"Mã loại nhân viên: {currentId}\n" +
                                $"Tên loại nhân viên: {newTenLoai}",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ!", "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadDATA();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLoaiNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (DialogResult == DialogResult.No)
            {
                e.Cancel = true; // Hủy bỏ việc đóng form
            }
            else
            {
                e.Cancel = false; // Cho phép đóng form
            }
        }
    }
}
