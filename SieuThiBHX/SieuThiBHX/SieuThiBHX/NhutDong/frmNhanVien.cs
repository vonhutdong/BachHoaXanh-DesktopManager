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

namespace SieuThiBHX
{
    public partial class frmNhanVien : Form
    {
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        BUS_LoaiNhanVien bus_lnv = new BUS_LoaiNhanVien();
        //BUS_TaiKhoan bus_tk = new BUS_TaiKhoan();
        DataValidation dv = new DataValidation();
        public frmNhanVien()
        {
            InitializeComponent();
        }

        void loadDSNV()
        {
            dgvNV.DataSource = bus_nv.LayDSNhanVien();

            dgvNV.Columns["id"].Visible = false;
            dgvNV.Columns["idLoaiNhanVien"].Visible = false;
            dgvNV.Columns["idTaiKhoan"].Visible = false;
            dgvNV.Columns["MaNhanVien"].Visible = true;
            dgvNV.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dgvNV.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
            dgvNV.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dgvNV.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvNV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNV.ColumnHeadersHeight = 30; // hoặc cao hơn



            // Thiết lập lại style để dữ liệu hiện rõ
            dgvNV.DefaultCellStyle.BackColor = Color.White;
            dgvNV.DefaultCellStyle.ForeColor = Color.Black;
            dgvNV.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvNV.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvNV.EnableHeadersVisualStyles = false;
            dgvNV.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvNV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            loadDSNV();


        }

        private void dgvNV_Click(object sender, EventArgs e)
        {
            if (dgvNV.CurrentCell != null)
            {
                // Others
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                // Get row index selected
                int n = dgvNV.CurrentCell.RowIndex;

                txtTenNhanVien.Text = dgvNV.Rows[n].Cells[2].Value.ToString();
                txtSoDienThoai.Text = dgvNV.Rows[n].Cells[3].Value.ToString();
                txtDiaChi.Text = dgvNV.Rows[n].Cells[4].Value.ToString();

                //MessageBox.Show(dgvNV.Rows[n].Cells[5].Value.ToString());

                // cboMaLoaiNhanVien
                int idLoaiNhanVien = int.Parse(dgvNV.Rows[n].Cells[5].Value.ToString());

                // Lấy danh sách tất cả loại nhân viên (nếu cần chọn từ toàn bộ)
                cboMaLoaiNhanVien.DataSource = bus_lnv.GetListLNV(); // hoặc GetListLNV()
                cboMaLoaiNhanVien.DisplayMember = "TenLoaiNhanVien";
                cboMaLoaiNhanVien.ValueMember = "Id";

                // Gán đúng loại nhân viên đang được chọn theo ID
                cboMaLoaiNhanVien.SelectedValue = idLoaiNhanVien;


                // cboMaTaiKhoan
                int idMaTaiKhoan = int.Parse(dgvNV.Rows[n].Cells[6].Value.ToString());
                //cboMaTaiKhoan.DataSource = bus_tk.GetListOneTKByTenTK(idMaTaiKhoan);
                //cboMaTaiKhoan.DisplayMember = "TenTaiKhoan";
                //cboMaTaiKhoan.ValueMember = "Id";
                //cboMaTaiKhoan.SelectedIndex = idMaTaiKhoan - 1;
            }
            else
            {
                // Messaged
                MessageBox.Show("Vui lòng chọn 1 dòng để xóa hoặc sửa thông tin!", "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
        }

        bool checkDATA(string tenNV, string SDT, string diaChi) 
        {
            int count = 0;
            if (dv.CheckString(tenNV, 100))
            {
                count += 1;
            }
            else
            {
                MessageBox.Show($"Tên nhân viên không quá 100 kí tự!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            // Checked soDT
            if (dv.CheckNumber(SDT, 10))
            {
                count += 1;
            }
            else
            {
                MessageBox.Show($"Số điện thoại không quá 10 kí tự và phải nhập số!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            // Checked diaChi
            if (dv.CheckString(diaChi, 100))
            {
                count += 1;
            }
            else
            {
                MessageBox.Show($"Địa chỉ không quá 100 kí tự!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            if (count == 3)
            {
                return true;
            }
            return false;
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
