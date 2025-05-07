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
using System.Configuration;
using DAL;
using DTO;

namespace SieuThiBHX
{
    public partial class frm_LoaiHang : Form
    {
        public frm_LoaiHang()
        {
            InitializeComponent();
        }
        BUS_LoaiHang bus_lh= new BUS_LoaiHang();
        int currentID = -1;
        public void LoadDSLoaiHang()
        {
            //load danh sách
            dgvLoaiHang.DataSource = bus_lh.LayDSLH();
            //đổi tên cột
            dgvLoaiHang.Columns["MaLoaiHang"].HeaderText = "Mã Loại Hàng";
            dgvLoaiHang.Columns["TenLoaiHang"].HeaderText = "Tên Loại Hàng";
            //ẩn cột id
            dgvLoaiHang.Columns["id"].Visible = false;
        }

        private void dgvLoaiHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void frm_LoaiHang_Load(object sender, EventArgs e)
        {
            LoadDSLoaiHang();
        }

        private void dgvLoaiHang_Click(object sender, EventArgs e)
        {
            int dong = dgvLoaiHang.CurrentRow.Index;
            //điền thông tin lên textbox
            txtMaLH.Text = dgvLoaiHang.Rows[dong].Cells["MaLoaiHang"].Value.ToString();
            txtTenLH.Text = dgvLoaiHang.Rows[dong].Cells["TenLoaiHang"].Value.ToString();
            //lấy id click
            currentID = int.Parse(dgvLoaiHang.Rows[dong].Cells["id"].Value.ToString());
        }
        private void Reset()
        {
            txtMaLH.Clear();
            txtTenLH.Clear();
            txtMaLH.Focus();
            //load lại data
            LoadDSLoaiHang();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaLH.Text.Length > 0 && txtTenLH.Text.Length > 0)
                {
                    //thêm loại hàng
                    bus_lh.ThemLoaiHang(new DTO_LoaiHang(txtMaLH.Text, txtTenLH.Text));
                    MessageBox.Show("Thêm thành công!", "Thoát", MessageBoxButtons.OK);
                    //làm mới
                    Reset();
                }
                else
                {
                    //thông báo khi chưa đầy đủ dữ liệu
                    MessageBox.Show("Chưa nhập dữ liệu!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //thông báo khi có lỗi xảy ra
                MessageBox.Show(ex.Message, "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = MessageBox.Show("Bạn có chắc xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    //kiểm tra đã click vào dòng dữ liệu nào chưa
                    if (currentID > 0)
                    {
                        //xóa dữ liệu
                        bus_lh.XoaLoaiHang(currentID);
                        MessageBox.Show("Xóa thành công!", "Thoát", MessageBoxButtons.OK);
                        //làm mới
                        Reset();
                    }
                    else
                    {

                        //thông báo khi chưa chọn dữ liệu xóa
                        MessageBox.Show("Vui lòng chọn dữ liệu cần xóa!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception ex)
            {

                //thông báo khi có lỗi xảy ra
                MessageBox.Show(ex.Message, "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaLH.Text.Length > 0 && txtTenLH.Text.Length > 0)
                {
                    //Sửa loại hàng
                    bus_lh.SuaLoaHang(new DTO_LoaiHang(currentID, txtMaLH.Text, txtTenLH.Text));
                    MessageBox.Show("Sửa thành công!", "Thoát", MessageBoxButtons.OK);
                    //làm mới
                    Reset();
                }   
                else
                {
                    //thông báo khi chưa đầy đủ dữ liệu
                    MessageBox.Show("Chưa nhập dữ liệu!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //thông báo khi có lỗi xảy ra
                MessageBox.Show(ex.Message, "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn chắc thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

    }
}
