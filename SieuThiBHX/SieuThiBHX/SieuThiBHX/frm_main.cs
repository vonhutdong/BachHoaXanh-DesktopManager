using DTO;
using SieuThiBHX.NhutDong;
using SieuThiBHX.Trong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SieuThiBHX.NhutDong;
using SieuThiBHX.Trong;
using System.Data.SqlClient;
using DTO;
using DAL;

namespace SieuThiBHX
{
    public partial class frm_main : Form
    {
        public static DTO_NhanVien nhanVien = null;
        public frm_main()
        {
            InitializeComponent();

            //this.IsMdiContainer = true;
        }
        private string tk = string.Empty;
        private int q = 0;
        private Form frmOld = null;
        //public static DTO_NhanVien nhanVien = null;

        //public DTO_NhanVien NhanVien { get => nhanVien; set => nhanVien = value; }

        public frm_main(string taiKhoan, int quyen, DTO_NhanVien nhanVien)
        {
            this.tk = taiKhoan;
            //this.NhanVien = nhanVien;
            this.q = quyen;
            InitializeComponent();
        }

        //public static DTO_NhanVien getNhanVien()
        //{
        //    return nhanVien;
        //}

        private void TestSQLConnection()
        {
            string connectionString = "Server=DESKTOP-UBB0F3U\\SQLEXPRESS;Database=SieuThiBHX;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Kết nối SQL Server thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kết nối SQL Server thất bại:\n" + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public void ActForm(string name)
        {
            foreach (Form item in MdiChildren)
            {
                if (item.Name == name)
                {
                    item.Activate();
                    break;
                }
            }
        }
        public bool CheckFormExit(string name)
        {

            foreach (Form item in MdiChildren)
            {
                if (item.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        private void frm_main_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            TestSQLConnection();
        }
        private void OpenHoaDonForm()
        {
            // Đóng các MDI child cũ nếu có
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            frm_HoaDon hoaDonForm = new frm_HoaDon();
            hoaDonForm.MdiParent = this;
            hoaDonForm.FormBorderStyle = FormBorderStyle.None; // Không viền
            hoaDonForm.Dock = DockStyle.Fill;                  // Fill toàn bộ cha
            hoaDonForm.Show();
            //MessageBox.Show(NhanVien.TenNV);
            // Check taikhoan da dc gui qua frmMain chua?
            if (tk != string.Empty)
            {
                this.Text = $"Màn hình chính - Xin chào {tk}!";
            }
            else
            {
                this.Text = $"Màn hình chính";
            }

            // Others

            nhânViênToolStripMenuItem.Enabled = false;
            nhânViênToolStripMenuItem.Visible = false;
            //hóaĐơnToolStripMenuItem.Enabled = false;
            //hóaĐơnToolStripMenuItem.Visible = false;

            // Role
            if (q == 0)
            {
                quảnLýToolStripMenuItem.Visible = true;
                quảnLýToolStripMenuItem.Enabled = true;
            }
            else
            {
                quảnLýToolStripMenuItem.Visible = false;
                quảnLýToolStripMenuItem.Enabled = false;
            }
        }
        private void hóaĐơnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!CheckFormExit("frm_HoaDon"))
            {
                OpenHoaDonForm();
               
            }
            else
            {
                ActForm("frm_HoaDon");
            }
        }
        private void OpenCTHoaDonForm()
        {
            // Đóng các MDI child cũ nếu có
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            frm_ChiTietHoaDon hoaDonForm = new frm_ChiTietHoaDon();
            hoaDonForm.MdiParent = this;
            hoaDonForm.FormBorderStyle = FormBorderStyle.None; // Không viền
            hoaDonForm.Dock = DockStyle.Fill;                  // Fill toàn bộ cha
            hoaDonForm.Show();
        }
        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frm_ChiTietHoaDon"))
            {
                OpenCTHoaDonForm();
                frm_ChiTietHoaDon f = new frm_ChiTietHoaDon();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frm_ChiTietHoaDon");
            }
        }
        private void OpenKhoHangForm()
        {
            // Đóng các MDI child cũ nếu có
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            frm_KhoHang khoHangForm = new frm_KhoHang();
            khoHangForm.MdiParent = this;
            khoHangForm.FormBorderStyle = FormBorderStyle.None; // Không viền
            khoHangForm.Dock = DockStyle.Fill;                  // Fill toàn bộ cha
            khoHangForm.Show();
        }
        private void khoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frm_KhoHang"))
            {
                OpenKhoHangForm();
                
            }
            else
            {
                ActForm("frm_KhoHang");
            }
        }
        private void OpenLoaiHangForm()
        {
            // Đóng các MDI child cũ nếu có
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            frm_LoaiHang loaiHangForm = new frm_LoaiHang();
            loaiHangForm.MdiParent = this;
            loaiHangForm.FormBorderStyle = FormBorderStyle.None; // Không viền
            loaiHangForm.Dock = DockStyle.Fill;                  // Fill toàn bộ cha
            loaiHangForm.Show();
        }

        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!CheckFormExit("frm_LoaiHang"))
            {
                OpenLoaiHangForm();
                
            }
            else
            {
                ActForm("frm_LoaiHang");
            }
        }
        private void OpenKhachHangForm()
        {
            // Đóng các MDI child cũ nếu có
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            frm_KhachHang khachHangForm = new frm_KhachHang();
            khachHangForm.MdiParent = this;
            khachHangForm.FormBorderStyle = FormBorderStyle.None; // Không viền
            khachHangForm.Dock = DockStyle.Fill;                  // Fill toàn bộ cha
            khachHangForm.Show();
        }
        private void KhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frm_KhachHang"))
            {
                OpenKhachHangForm();
                frm_KhachHang f = new frm_KhachHang();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frm_KhachHang");
            }
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frmSanPham"))
            {
                frmSanPham f = new frmSanPham();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frm_SanPham");
            }
        }

        private void chiNhánhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frmChiNhanh"))
            {
                frmChiNhanh f = new frmChiNhanh();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frmChiNhanh");
            }
        }

        private void chiTiếtPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frmChiTietPhieuNhap"))
            {
                frmChiTietPhieuNhap f = new frmChiTietPhieuNhap();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frmChiTietPhieuNhap");
            }
        }

        private void khuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frmKhuyenMai"))
            {
                frmKhuyenMai f = new frmKhuyenMai();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frmKhuyenMai");
            }
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frmNhaCungCap"))
            {
                frmNhaCungCap f = new frmNhaCungCap();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frmNhaCungCap");
            }
        }

        private void phiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frmPhieuNhap"))
            {
                frmPhieuNhap f = new frmPhieuNhap();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frmPhieuNhap");
            }
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frmTaiKhoan"))
            {
                frmTaiKhoan f = new frmTaiKhoan();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frmTaiKhoan");
            }
        }

        private void bảngLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frmBangLuong"))
            {
                frmBangLuong f = new frmBangLuong();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frmBangLuong");
            }
        }

        private void caLàmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frmCaLam"))
            {
                frmCaLam f = new frmCaLam();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frmCaLam");
            }
        }

        private void lịchLàmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frmLichLam"))
            {
                frmLichLam f = new frmLichLam();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frmLichLam");
            }
        }

        private void loạiNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frmLoaiNhanVien"))
            {
                frmLoaiNhanVien f = new frmLoaiNhanVien();
               // f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frmLoaiNhanVien");
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frmNhanVien"))
            {
                frmNhanVien f = new frmNhanVien();
               // f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frmNhanVien");
            }
        }

        private void traCứuNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frmTraCuuNV"))
            {
                frmTraCuuNV f = new frmTraCuuNV();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frmTraCuuNV");
            }
        }
        private void OpenBanHangForm()
        {
            // Đóng các MDI child cũ nếu có
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            frm_BanHang khoHangForm = new frm_BanHang();
            khoHangForm.MdiParent = this;
            khoHangForm.FormBorderStyle = FormBorderStyle.None; // Không viền
            khoHangForm.Dock = DockStyle.Fill;                  // Fill toàn bộ cha
            khoHangForm.Show();
        }
        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenBanHangForm();
        }

        private void thốngKêPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frm_ThongKeTheoMaPhieuNhap"))
            {
                frm_ThongKeTheoMaPhieuNhap f = new frm_ThongKeTheoMaPhieuNhap();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frm_ThongKeTheoMaPhieuNhap");
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
