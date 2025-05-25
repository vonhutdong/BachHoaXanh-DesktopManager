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

namespace SieuThiBHX.Trong
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }
        BUS_NhanVien bus_NhanVien = new BUS_NhanVien();
        BUS_TaiKhoan bus_TaiKhoan = new BUS_TaiKhoan();
        BUS_TaiKhoan bus_tk = new BUS_TaiKhoan();
        DTO_NhanVien nvLogin;
        private void frm_Login_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Initialize Variables
            string taiKhoan = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            // Verify Account
            if (bus_tk.CheckTaiKhoan(taiKhoan, matKhau))
            {
                try
                {
                    int quyen = bus_tk.GetRole(taiKhoan, matKhau);
                    int Idtk = bus_TaiKhoan.GetIdTaiKhoan(taiKhoan, matKhau);
                    nvLogin = bus_NhanVien.getNhanVien(Idtk);

                    this.Hide(); // Ẩn form đăng nhập

                    frm_main f = new frm_main(taiKhoan, quyen, nvLogin);
                   
                    f.ShowDialog();

                    this.Show(); // Hiện lại nếu cần quay lại đăng nhập
                }
                finally
                {
                    //this.FormClosing += FrmDangNhap_FormClosing;
                }
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
