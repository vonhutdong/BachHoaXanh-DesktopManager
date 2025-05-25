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
    public partial class frmBangLuong : Form
    {
        BUS_BangLuong bus_bangluong = new BUS_BangLuong();
        BUS_ChiTietBangLuong bus_chitietbangluong = new BUS_ChiTietBangLuong();
        BUS_CaLam bus_calam = new BUS_CaLam();
        BUS_LichLam bus_lichlam = new BUS_LichLam();
        //id bang lương đang chọn
        int currentIDBangLuong = 0;
        int currentIDNhanVien = 0;
        //check them
        bool checkbtn;
        public frmBangLuong()
        {
            InitializeComponent();
        }
        
        void LoadFromdgvBangLuong()
        {
            dgvBangLuong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBangLuong.ColumnHeadersHeight = 30; // hoặc cao hơn

            // Thiết lập lại style để dữ liệu hiện rõ
            dgvBangLuong.DefaultCellStyle.BackColor = Color.White;  
            dgvBangLuong.DefaultCellStyle.ForeColor = Color.Black;
            dgvBangLuong.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvBangLuong.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvBangLuong.EnableHeadersVisualStyles = false;
            dgvBangLuong.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvBangLuong.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }

        void LoadFromdgvChiTietBangLuong()
        {
            dgvChiTietBangLuong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietBangLuong.ColumnHeadersHeight = 30; // hoặc cao hơn

            // Thiết lập lại style để dữ liệu hiện rõ
            dgvChiTietBangLuong.DefaultCellStyle.BackColor = Color.White;
            dgvChiTietBangLuong.DefaultCellStyle.ForeColor = Color.Black;
            dgvChiTietBangLuong.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvChiTietBangLuong.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvChiTietBangLuong.EnableHeadersVisualStyles = false;
            dgvChiTietBangLuong.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvChiTietBangLuong.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }
        private void frmBangLuong_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFromdgvBangLuong();
                LoadFromdgvChiTietBangLuong();
                //Tải dữ liệu bang lương
                LoadDSBangLuong();
                //tải dữ liệu chi tiết bảng lương
                LoadDSChiTietBangLuong();
                //load combobox
                LoadCbNhanVien();
                //btn luu
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                //cb lich lam
                LoadCBLichLam();
               // cbLichLam.SelectedIndex = -1;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LamMoi()
        {
            //load danh sách bảng lương k điều kiện
            LoadDSBangLuong();
            //load danh sách bảng lương k điều kiện
            LoadDSChiTietBangLuong();
            //resrt check box
            cbLoc.Checked = false;
            //btn luu
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            //btn thêm, thêm chi tiết
            btnThem.Enabled = true;
            btnThemChiTiet.Enabled = true;
            //txt
            txtGioCong.Enabled = true;
            txtLuong.Enabled = true;
            cbLichLam.Enabled = true;
            cbNhanVien.Enabled = true;
            txtMaPhieuNhap.ReadOnly = false;
            txtGioCong.Clear();
            txtLuong.Clear();
            txtMaPhieuNhap.Clear();

        }
        //lay danh sách bảng lương ko có điều kiện
        private void LoadDSBangLuong()
        {
            //lay danh sách bảng lương ko có điều kiện
            dgvBangLuong.DataSource = bus_bangluong.LayDSBangLuong();
            //dổi tên cột
            dgvBangLuong.Columns["TongGioCong"].HeaderText = "Tổng giờ công";
            dgvBangLuong.Columns["Luong"].HeaderText = "Lương";
            dgvBangLuong.Columns["ThangNam"].HeaderText = "Tháng/Năm";
            dgvBangLuong.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
            //format
            dgvBangLuong.Columns["ThangNam"].DefaultCellStyle.Format = "MM/yyyy";
            //ẩn cột
            dgvBangLuong.Columns["id"].Visible = false;
            dgvBangLuong.Columns["idNhanVien"].Visible = false;
            dgvBangLuong.Columns["MaBangLuong"].Visible = false;

        }
        private void LoadCBLichLam()
        {
            cbLichLam.DataSource = bus_chitietbangluong.LayDSLichLam();
            cbLichLam.DisplayMember = "MaLichLam";
            cbLichLam.ValueMember = "id";
        }
        private void LoadCbNhanVien()
        {
            //cb nhan vien
            cbNhanVien.DataSource = bus_bangluong.DSNhanVien();
            cbNhanVien.DisplayMember = "TenNhanVien";
            cbNhanVien.ValueMember = "id";
            //cb loc
            cbLocBangLuong.DataSource = bus_bangluong.DSNhanVien();
            cbLocBangLuong.DisplayMember = "TenNhanVien";
            cbLocBangLuong.ValueMember = "id";
        }
        //lay danh sách chi tiết bảng lương ko có điều kiện
        private void LoadDSChiTietBangLuong()
        {
            dgvChiTietBangLuong.DataSource = bus_chitietbangluong.LayDSCTBangLuong();
            //dổi tên cột
            dgvChiTietBangLuong.Columns["NgayLam"].HeaderText = "Ngày làm";
            dgvChiTietBangLuong.Columns["SoGioCongThucTe"].HeaderText = "Giờ công thực tế";
            //format
            dgvChiTietBangLuong.Columns["NgayLam"].DefaultCellStyle.Format = "dd/MM/yyyy";
            //dgvBangLuong.Columns["ThangNam"].DefaultCellStyle.Format = "MM/yyyy";
            //ẩn cột
            dgvChiTietBangLuong.Columns["id"].Visible = false;
            dgvChiTietBangLuong.Columns["idBangLuong"].Visible = false;

        }
        private void LoadDSChiTietBangLuong(int idBangLuong)
        {
            dgvChiTietBangLuong.DataSource = bus_chitietbangluong.LayDSCTBangLuong(idBangLuong);
            //dổi tên cột
            dgvChiTietBangLuong.Columns["NgayLam"].HeaderText = "Ngày làm";
            dgvChiTietBangLuong.Columns["SoGioCongThucTe"].HeaderText = "Giờ công thực tế";
            //format
            dgvChiTietBangLuong.Columns["NgayLam"].DefaultCellStyle.Format = "dd/MM/yyyy";
            //dgvBangLuong.Columns["ThangNam"].DefaultCellStyle.Format = "MM/yyyy";
            //ẩn cột
            dgvChiTietBangLuong.Columns["id"].Visible = false;
            dgvChiTietBangLuong.Columns["idBangLuong"].Visible = false;
        }
        private void dgvBangLuong_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBangLuong.CurrentCell != null)
                {
                    //lấy dòng đang click
                    int dong = dgvBangLuong.CurrentRow.Index;
                    //điền thông tin lên textbox
                    txtLuong.Text = dgvBangLuong.Rows[dong].Cells["Luong"].Value.ToString();
                    //txtTenChiNhanh.Text = dgvChiNhanh.Rows[dong].Cells["TenChiNhanh"].Value.ToString();
                    //txtDiaChi.Text = dgvChiNhanh.Rows[dong].Cells["DiaChi"].Value.ToString();
                    //txtSoDienThoai.Text = dgvChiNhanh.Rows[dong].Cells["SoDienThoai"].Value.ToString();
                    //gán id cho currnentID
                    currentIDBangLuong = int.Parse(dgvBangLuong.Rows[dong].Cells["id"].Value.ToString());
                    //load danh sách chi tiet bang lương có điều kiện
                    LoadDSChiTietBangLuong(currentIDBangLuong);
                    txtMaPhieuNhap.Text = dgvBangLuong.Rows[dong].Cells["MaBangLuong"].Value.ToString();
                    cbNhanVien.SelectedValue = int.Parse(dgvBangLuong.Rows[dong].Cells["idNhanVien"].Value.ToString());
                    currentIDNhanVien = int.Parse(dgvBangLuong.Rows[dong].Cells["idNhanVien"].Value.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            //hàm làm mới
            LamMoi();
        }

        private void cbLoc_CheckedChanged(object sender, EventArgs e)
        {
            //load danh sách bảng lương có điều kiện
            LoadDSBangLuong();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtGioCong.Enabled = false;
            txtLuong.Enabled = false;
            cbLichLam.Enabled = false;
            //cbNhanVien.Enabled = false;
            btnThemChiTiet.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            checkbtn = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                //thêm bảng lương
                if (checkbtn)
                {
                    if (cbNhanVien.SelectedIndex > 0)
                    {
                        bus_bangluong.ThemBangLuong(new DTO_BangLuong(dtNgayNhap.Value, 0, 0, int.Parse(cbNhanVien.SelectedValue.ToString())));
                        MessageBox.Show("Thêm thành công!!");
                        LamMoi();
                    }
                    else
                    {
                        //thông báo khi chưa đầy đủ dữ liệu
                        MessageBox.Show("Chưa nhập dữ liệu!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                //thêm chi tiết
                else
                {
                    if (txtGioCong.Text.Length > 0)
                    {
                        float gioCong = float.Parse(txtGioCong.Text);
                        if (gioCong > 15)
                        {
                            throw new Exception("Giờ công 1 ngày không quá 15 tiếng!");
                        }
                        bus_chitietbangluong.ThemChiTietbangLuong(new DTO_ChiTietBangLuong(float.Parse(txtGioCong.Text), currentIDBangLuong, int.Parse(cbLichLam.SelectedValue.ToString()), dtNgayNhap.Value));
                        MessageBox.Show("Thêm thành công!!");
                        LamMoi();
                    }
                    else
                    {
                        //thông báo khi chưa đầy đủ dữ liệu
                        MessageBox.Show("Chưa nhập dữ liệu!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            checkbtn = false;
            cbNhanVien.Enabled = false;
            txtMaPhieuNhap.ReadOnly = true;
        }

        private void txtGioCong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar != Keys.Back && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                txtGioCong.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn chắc thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (currentIDBangLuong != 0)
            {
                frmBaoCaoBangLuong frm = new frmBaoCaoBangLuong(currentIDBangLuong);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui chọn bảng lương!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //lay danh sách bảng lương có điều kiện
        private void LoadDSBangLuong(int idNhanVien)
        {
            //lay danh sách bảng lương ko có điều kiện
            dgvBangLuong.DataSource = bus_bangluong.LayDSBangLuong(idNhanVien);
            //dổi tên cột
            dgvBangLuong.Columns["TongGioCong"].HeaderText = "Tổng giờ công";
            dgvBangLuong.Columns["Luong"].HeaderText = "Lương";
            dgvBangLuong.Columns["ThangNam"].HeaderText = "Tháng/Năm";
            dgvBangLuong.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
            //format
            dgvBangLuong.Columns["ThangNam"].DefaultCellStyle.Format = "MM/yyyy";
            //ẩn cột
            dgvBangLuong.Columns["id"].Visible = false;
            dgvBangLuong.Columns["idNhanVien"].Visible = false;
            dgvBangLuong.Columns["MaBangLuong"].Visible = false;

        }
        private void cbLocBangLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoc.Checked)
            {
                //load danh sách bảng lương có điều kiện
                LoadDSBangLuong(int.Parse(cbLocBangLuong.SelectedValue.ToString()));
            }
        }
        
        private void LoadDSChiTietBangLuongTheoThang(int idNhanVien, int thang, int nam)
        {
            
        }
        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThemChiTiet.Enabled = true;
            btnThem.Enabled = true;
            cbLichLam.Enabled = true;
            txtGioCong.Enabled = true;
            txtLuong.Enabled = true;
            cbNhanVien.Enabled = true;
        }

        
        private void cbLichLam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLichLam.SelectedValue != null && int.TryParse(cbLichLam.SelectedValue.ToString(), out int maLichLam))
            {
                //MessageBox.Show(maLichLam.ToString());
                var lichLam = bus_lichlam.GetLichLamByMa(maLichLam);
                if (lichLam == null)
                {
                    MessageBox.Show("Không tìm thấy lịch làm!");
                    return;
                }

                var caLam = bus_calam.GetCaLamById(lichLam.idCaLam.Value);
                if (caLam == null)
                {
                    MessageBox.Show("Không tìm thấy ca làm việc!");
                    return;
                }

                // Tính giờ làm
                string soGio = bus_calam.TinhGioLam(caLam);
                txtGioCong.Text = soGio;
            }

            
        }

    
    }
}
