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
using DAL;
using DTO;

namespace SieuThiBHX
{
    public partial class frm_ApDungMaKhuyenMai : Form
    {
        BUS_KhuyenMai busKM = new BUS_KhuyenMai();
        DTO_KhuyenMai khuyenMai;
        int idKhuyenMai;
        public frm_ApDungMaKhuyenMai()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            frm_BanHang.CheckMaKhuyenMai = false;
            frm_BanHang.idKhuyenMai = 1;
            this.Close();
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            frm_BanHang.CheckMaKhuyenMai = true;
            try
            {
                if (txtMaKhuyenMai.Text != "")
                {
                    idKhuyenMai = busKM.getIdKhuyenMai(txtMaKhuyenMai.Text);
                    if (idKhuyenMai == 0)
                    {
                        MessageBox.Show("Mã không tồn tại!!Vui lòng kiểm tra lại!");
                    }
                    else
                    {
                        MessageBox.Show("Áp dụng mã thành công!!", "Thoát", MessageBoxButtons.OK);
                        frm_BanHang.idKhuyenMai = idKhuyenMai;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập dữ liệu!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi!", "Thoát", MessageBoxButtons.OK);
            }



        }

        private void frm_ApDungMaKhuyenMai_Load(object sender, EventArgs e)
        {
            frm_BanHang.idKhuyenMai = 1;

        }
    }
}
