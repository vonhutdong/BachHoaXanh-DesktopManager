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

namespace SieuThiBHX
{
    public partial class frmCaLam : Form
    {
        BUS_CaLam bus_cl = new BUS_CaLam();
        DTO_CaLam caLam = new DTO_CaLam();
        int currentID = -1;
        public frmCaLam()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dgvCaLam.DataSource = bus_cl.LayDSCaLam();

            // Đổi tên cột
            dgvCaLam.Columns["MaCaLam"].HeaderText = "Mã ca làm";
            dgvCaLam.Columns["TenCaLam"].HeaderText = "Tên ca làm";
            dgvCaLam.Columns["GioBatDau"].HeaderText = "Giờ bắt đầu";
            dgvCaLam.Columns["GioKetThuc"].HeaderText = "Giờ kết thúc";
            dgvCaLam.Columns["id"].Visible = false;

            dgvCaLam.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCaLam.ColumnHeadersHeight = 30; // hoặc cao hơn

            // Thiết lập lại style để dữ liệu hiện rõ
            dgvCaLam.DefaultCellStyle.BackColor = Color.White;  
            dgvCaLam.DefaultCellStyle.ForeColor = Color.Black;
            dgvCaLam.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvCaLam.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvCaLam.EnableHeadersVisualStyles = false;
            dgvCaLam.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvCaLam.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

        }
        private void Reset()
        {
            txtTenCaLam.Text = string.Empty;
            txtGioBatDau.Text = string.Empty;
            txtGioKetThuc.Text = string.Empty;
        }
        private void frmCaLam_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Reset();
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtTenCaLam.Text != "Ca sáng" && txtTenCaLam.Text != "Ca tối" && txtTenCaLam.Text != "Ca chiều")
                {
                    if (txtTenCaLam.Text.Length > 0 && txtGioBatDau.Text.Length > 0 && txtGioKetThuc.Text.Length > 0)
                    {
                        //thong báo thêm ca làm thành công
                        MessageBox.Show($"Thêm ca làm vào danh sách thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //thêm ca làm
                        bus_cl.ThemCaLam(new DTO_CaLam(txtTenCaLam.Text, txtGioBatDau.Text, txtGioKetThuc.Text));
                        //làm mới
                        LoadData();
                    }
                    else
                    {
                        //thông báo khi chưa đầy đủ dữ liệu
                        MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    //thông báo khi tên ca làm đã tồn tại
                    MessageBox.Show("Tên ca làm đã tồn tại!!", "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //thông báo khi có lỗi xảy ra
                MessageBox.Show(ex.Message, "Thoát", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCaLam_Click(object sender, EventArgs e)
        {
            // Initialize Variable
            int n = dgvCaLam.CurrentCell.RowIndex;

            if (n >= 0)
            {

                // txtTenCaLam
                txtTenCaLam.Text = dgvCaLam.Rows[n].Cells["TenCaLam"].Value.ToString();

                // txtGioBatDau
                txtGioBatDau.Text = dgvCaLam.Rows[n].Cells["GioBatDau"].Value.ToString();

                //txtGioKetThuc
                txtGioKetThuc.Text = dgvCaLam.Rows[n].Cells["GioKetThuc"].Value.ToString();

                //ID
                currentID = int.Parse(dgvCaLam.Rows[n].Cells["id"].Value.ToString());

            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 dòng để xóa hoặc sửa thông tin!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2GroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtTenCaLam.Text.Length > 0 && txtTenCaLam.Text.Length <= 100)
            {
                if (dgvCaLam.CurrentRow == null || dgvCaLam.CurrentRow.Cells[0].Value == null)
                {
                    MessageBox.Show("Vui lòng chọn một ca làm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int currentId = int.Parse(dgvCaLam.CurrentRow.Cells[0].Value.ToString());
                DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa: [{txtTenCaLam.Text}] không?",
                        "Thông báo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {

                    
                    bool result = bus_cl.XoaCaLam(currentId);

                    if (result)
                    {
                        MessageBox.Show("Xóa ca làm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa ca làm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ca làm muốn thao tác!", "Thông báo",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
            }
        
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenCaLam.Text.Length > 0 && txtGioBatDau.Text.Length > 0 && txtGioKetThuc.Text.Length > 0)
                {
                    DialogResult dr = MessageBox.Show($"Bạn có chắc muốn sửa: [{txtTenCaLam.Text}] không?",
                       "Thông báo",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        bool result = bus_cl.suaCaLam(new DTO_CaLam(currentID, txtTenCaLam.Text, txtGioBatDau.Text, txtGioKetThuc.Text));
                        if (result)
                        {
                            MessageBox.Show("Sửa ca làm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else{ 
                        MessageBox.Show("Sửa ca làm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }

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
    }
}
