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
    public partial class frm_ChiTietHoaDon : Form
    {
        public frm_ChiTietHoaDon()
        {
            InitializeComponent();
            
        }
        BUS_ChiTietHoaDon bus_cthd = new BUS_ChiTietHoaDon();
        BUS_HoaDon bus_hd = new BUS_HoaDon();
        BUS_SanPham bus_sp = new BUS_SanPham();
        BUS_KhoHang bus_kh = new BUS_KhoHang();
        BUS_KhachHang bus_khachhang = new BUS_KhachHang();
        BUS_KhuyenMai bus_km = new BUS_KhuyenMai();
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        int soLuongInput = 0;
        int tongTien = 0;

        public void LoadFirst()
        {
            // Active
            btnThem.Enabled = true;
            btnLuuCTHD.Enabled = true;
            cboMaHD.Enabled = true;
            cboMaKH.Enabled = true;
            cboMaNV.Enabled = true;

            // cboMaKH
            cboMaKH.DataSource = bus_khachhang.LayDSKH();
            cboMaKH.DisplayMember = "TenKH";
            cboMaKH.ValueMember = "id";
            cboMaKH.SelectedIndex = 0;

            // cboMaKM
            cboMaKM.DataSource = bus_km.GetListKM();
            cboMaKM.DisplayMember = "TenKhuyenMai";
            cboMaKM.ValueMember = "id";
            cboMaKM.SelectedIndex = 0;

            // cboMaNV
            cboMaNV.DataSource = bus_nv.LayDSNhanVien();
            cboMaNV.DisplayMember = "TenNhanVien";
            cboMaNV.ValueMember = "id";
            cboMaNV.SelectedIndex = 0;

            // DeactiveControlsCTHD
            //DeactiveControlsCTHD();

            // Dgvs
            dgvCTHD.Enabled = false;
            dgvSP.Enabled = false;

            // Other
            btnTimHd.Visible = false;
        }
        public void DeactiveControlsCTHD()
        {
            // Buttons
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTimHd.Enabled = false;
            btnTimSp.Enabled = false;
            btnTinhTongTien.Enabled = false;
            btnLuuCTHD.Enabled = false;
            //btnLamMoiCTHD.Enabled = false;
            btnIn.Enabled = false;

            // Cbos
            cboMaHD.Enabled = false;
            cboMaSP.Enabled = false;
            cboTimKiemSp.Enabled = false;

            // Txts
            txtSoLuong.Enabled = false;
            txtSoLuong.Text = "0";
            txtTongTien.Enabled = false;
            txtTongTien.Text = "0";
            txtTimKiemMaHd.Enabled = false;
            txtTimKiemMaHd.Text = "";
            txtTimKiemMaHd.Enabled = false;
            txtTimKiemSp.Text = "";
            txtTimKiemSp.Enabled = false;
            txtTimKiemMaHd.Visible = false;
            guna2HtmlLabel6.Visible = false;

            // Dgvs
            dgvSP.Enabled = false;
            dgvCTHD.Enabled = false;
            dgvSP.DataSource = false;
            dgvCTHD.DataSource = false;
        }
        public void ResetFirst()
        {
            LoadFirst();
        }
        public void DeactiveControlsHD()
        {
            // Btns
            //btnThemHD.Enabled = false;
            btnLamMoi.Enabled = false;

            // Cbos
            cboMaKH.Enabled = false;
            cboMaKM.Enabled = false;
            cboMaNV.Enabled = false;
        }
        public void LoadData()
        {
            // Others
            txtSoLuong.Focus();
            txtSoLuong.Enabled = true;
            txtSoLuong.Text = "0";
            txtTongTien.Enabled = false;
            txtTongTien.Text = "0";
            soLuongInput = 0;

            tongTien = 0;
            txtTimKiemMaHd.Enabled = true;
            txtTimKiemMaHd.Text = "";
            txtTimKiemSp.Enabled = true;
            txtTimKiemSp.Text = "";

            // Btns
            btnTimHd.Enabled = true;
            btnTimSp.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTinhTongTien.Enabled = true;
            btnLuuCTHD.Enabled = true;
            //btnLamMoiCTHD.Enabled = true;
            btnLamMoi.Enabled = true;
            btnCTHD.Enabled = false;
            btnIn.Enabled = true;

            // Cbos
            cboMaHD.Enabled = true;
            cboMaSP.Enabled = true;
            cboTimKiemSp.Enabled = true;

            // Dgvs
            dgvSP.Enabled = true;
            dgvCTHD.Enabled = true;

            // cboMaHD
            cboMaHD.DataSource = bus_hd.GetListHD();
            cboMaHD.DisplayMember = "MaHoaDon";
            cboMaHD.ValueMember = "id";
            cboMaHD.SelectedIndex = 0;

            // cboMaSP
            cboMaSP.DataSource = bus_sp.GetListSP();
            cboMaSP.DisplayMember = "TenSanPham";
            cboMaSP.ValueMember = "id";
            cboMaSP.SelectedIndex = 0;

            // cboSanPham
            cboTimKiemSp.SelectedIndex = 0;

            // dgvSP
            dgvSP.DataSource = bus_sp.GetListSP();
            dgvSP.Columns[0].HeaderText = "Id";
            dgvSP.Columns[1].HeaderText = "Mã sản phẩm";
            dgvSP.Columns[2].HeaderText = "Tên sản phẩm";
            dgvSP.Columns[3].HeaderText = "Đơn vị tính";
            dgvSP.Columns[4].HeaderText = "Đơn giá";
            dgvSP.Columns[5].HeaderText = "Số lượng";
            dgvSP.Columns[0].Visible = false;
            dgvSP.Columns[1].Visible = false;
            //dgvSP.Columns[4].DefaultCellStyle.Format = "#,###";

        }

        public void LoadDataByMaHd(int idMaHd)
        {
            // Others
            txtSoLuong.Focus();
            txtSoLuong.Enabled = true;
            txtSoLuong.Text = "0";
            txtTongTien.Enabled = false;
            txtTongTien.Text = "0";
            soLuongInput = 0;
            tongTien = 0;
            txtTimKiemMaHd.Enabled = true;
            txtTimKiemMaHd.Text = "";
            txtTimKiemMaHd.Enabled = true;
            txtTimKiemSp.Text = "";
            btnTimSp.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTinhTongTien.Enabled = true;
            btnLuuCTHD.Enabled = true;
            cboMaHD.Enabled = true;
            cboMaSP.Enabled = true;
            dgvSP.Enabled = true;
            dgvCTHD.Enabled = true;

            // cboMaHD
            cboMaHD.DataSource = bus_hd.GetListHD();
            cboMaHD.DisplayMember = "MaHoaDon";
            cboMaHD.ValueMember = "id";
            cboMaHD.SelectedIndex = idMaHd;

            // cboMaSP
            cboMaSP.DataSource = bus_sp.GetListSP();
            cboMaSP.DisplayMember = "TenSanPham";
            cboMaSP.ValueMember = "id";
            cboMaSP.SelectedIndex = 0;

            // cboSanPham
            cboTimKiemSp.SelectedIndex = 0;

            // dgvSP
            dgvSP.DataSource = bus_sp.GetListSP();
            dgvSP.Columns[0].HeaderText = "Id";
            dgvSP.Columns[1].HeaderText = "Mã sản phẩm";
            dgvSP.Columns[2].HeaderText = "Tên sản phẩm";
            dgvSP.Columns[3].HeaderText = "Đơn vị tính";
            dgvSP.Columns[4].HeaderText = "Đơn giá";
            dgvSP.Columns[5].HeaderText = "Số lượng";
            dgvSP.Columns[0].Visible = false;
            dgvSP.Columns[1].Visible = false;
            //dgvSP.Columns[4].DefaultCellStyle.Format = "#,###";

        }
        public void Reset()
        {
            LoadData();
        }

        public bool CheckData(int idSanPham, string soLuong)
        {
            int count = 0;

            // Lấy số lượng tồn kho
            int soLuongSpTrongKho = bus_sp.GetSoLuongSpTrongKho(idSanPham);

            // Tự kiểm tra hợp lệ
            if (int.TryParse(soLuong, out int soLuongInt))
            {
                if (soLuongInt >= 1 && soLuongInt <= soLuongSpTrongKho)
                {
                    count++;
                }
                else
                {
                    MessageBox.Show($"Giá trị phải từ 1 đến {soLuongSpTrongKho}!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số nguyên hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return count == 1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void frm_ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LoadFirst();
        }

        private void btnCTHD_Click(object sender, EventArgs e)
        {
            DeactiveControlsHD();
        }

        private void cboMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Initialize Variables
            int cboMaHD_SelectedValue = cboMaHD.SelectedIndex + 1;

            // dgvCTHD
            dgvCTHD.DataSource = bus_cthd.GetListCTHDTheoMaHD(cboMaHD_SelectedValue);
            dgvCTHD.Columns[0].HeaderText = "Id CTHD";
            dgvCTHD.Columns[1].HeaderText = "Mã hóa đơn";
            dgvCTHD.Columns[2].HeaderText = "Tên sản phẩm";
            dgvCTHD.Columns[3].HeaderText = "Số lượng";
            dgvCTHD.Columns[4].HeaderText = "Đơn giá";
            dgvCTHD.Columns[5].HeaderText = "Thành tiền";
            dgvCTHD.Columns[6].HeaderText = "Id hóa đơn";
            dgvCTHD.Columns[7].HeaderText = "Id sản phẩm";
            dgvCTHD.Columns[0].Visible = false;
            dgvCTHD.Columns[6].Visible = false;
            dgvCTHD.Columns[7].Visible = false;

            // Others
            txtTongTien.Text = "0";
            tongTien = 0;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetFirst();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvSP_Click(object sender, System.EventArgs e)
        {
            if (dgvSP.CurrentCell != null)
            {
                // Get row index selected
                int n = dgvSP.CurrentCell.RowIndex;

                // cboMaSP
                cboMaSP.SelectedIndex = int.Parse(dgvSP.Rows[n].Cells[0].Value.ToString()) - 1;

                // Others
                txtTimKiemMaHd.Text = string.Empty;
                txtTimKiemSp.Text = string.Empty;
            }
            else
            {
                // Messaged
                MessageBox.Show("Vui lòng chọn 1 dòng để xóa hoặc sửa thông tin!", "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
        }
        private void dgvCTHD_Click(object sender, System.EventArgs e)
        {
            if (dgvCTHD.CurrentCell != null)
            {
                // Get row index selected
                int n = dgvCTHD.CurrentCell.RowIndex;

                // cboMaHD
                cboMaHD.SelectedIndex = int.Parse(dgvCTHD.Rows[n].Cells[6].Value.ToString()) - 1;
                cboMaSP.SelectedIndex = int.Parse(dgvCTHD.Rows[n].Cells[7].Value.ToString()) - 1;
                txtSoLuong.Text = dgvCTHD.Rows[n].Cells[3].Value.ToString();

                // Others
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                cboMaHD.Enabled = false;
                cboMaSP.Enabled = false;
                dgvSP.Enabled = false;
                txtTimKiemMaHd.Text = string.Empty;
                txtTimKiemSp.Text = string.Empty;
            }
            else
            {
                // Messaged
                MessageBox.Show("Vui lòng chọn 1 dòng để xóa hoặc sửa thông tin!", "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
        }
    }
}
