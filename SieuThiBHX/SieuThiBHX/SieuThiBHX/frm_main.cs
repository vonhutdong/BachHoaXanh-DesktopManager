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

namespace SieuThiBHX
{
    public partial class frm_main : Form
    {
        public frm_main()
        {
            InitializeComponent();
            //this.IsMdiContainer = true;
        }
        private string tk = string.Empty;
        private int q = 0;
        private Form frmOld = null;
        public static DTO_NhanVien nhanVien = null;

        public DTO_NhanVien NhanVien { get => nhanVien; set => nhanVien = value; }

        public frm_main(string taiKhoan, int quyen, DTO_NhanVien nhanVien)
        {
            this.tk = taiKhoan;
            this.NhanVien = nhanVien;
            this.q = quyen;
            InitializeComponent();
        }

        public static DTO_NhanVien getNhanVien()
        {
            return nhanVien;
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
            chiTiếtHóaĐơnToolStripMenuItem.Enabled = false;
            chiTiếtHóaĐơnToolStripMenuItem.Visible = false;

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
                frm_HoaDon f = new frm_HoaDon();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frm_HoaDon");
            }
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frm_ChiTietHoaDon"))
            {
                frm_ChiTietHoaDon f = new frm_ChiTietHoaDon();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frm_ChiTietHoaDon");
            }
        }

        private void khoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frm_KhoHang"))
            {
                frm_KhoHang f = new frm_KhoHang();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frm_KhoHang");
            }
        }

        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frm_LoaiHang"))
            {
                frm_LoaiHang f = new frm_LoaiHang();
                //f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActForm("frm_LoaiHang");
            }
        }

        private void KhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormExit("frm_KhachHang"))
            {
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
