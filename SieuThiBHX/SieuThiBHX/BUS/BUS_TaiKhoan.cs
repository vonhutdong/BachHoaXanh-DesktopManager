using System;
using System.Linq;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_TaiKhoan
    {
        private DAL_TaiKhoan dal_tk = new DAL_TaiKhoan();

        // Đăng nhập
        public bool CheckTaiKhoan(string taiKhoan, string matKhau)
        {
            return dal_tk.CheckTaiKhoan(taiKhoan, matKhau);
        }

        // Lấy ID tài khoản
        public int GetIdTaiKhoan(string taiKhoan, string matKhau)
        {
            return dal_tk.GetIdTaiKhoan(taiKhoan, matKhau);
        }

        // Lấy quyền người dùng
        public int GetRole(string taiKhoan, string matKhau)
        {
            return dal_tk.GetRole(taiKhoan, matKhau);
        }

        // Lấy toàn bộ tài khoản
        public IQueryable GetListTaiKhoan()
        {
            return dal_tk.GetListTK();
        }

        // Lấy danh sách quyền
        public IQueryable GetListTaiKhoanTheoQuyen()
        {
            return dal_tk.GetListTKByQuyen();
        }

        // Lấy tất cả tài khoản theo tên
        public IQueryable GetAllTaiKhoanByTen()
        {
            return dal_tk.GetListAllTKByTenTK();
        }

        // Lấy 1 tài khoản theo ID
        public IQueryable GetOneTaiKhoanById(int id)
        {
            return dal_tk.GetListOneTKByTenTK(id);
        }

        // Thêm tài khoản
        public void AddTaiKhoan(DTO_TaiKhoan taiKhoan)
        {
            dal_tk.AddTaiKhoan(taiKhoan);
        }

        // Cập nhật tài khoản
        public void UpdateTaiKhoan(DTO_TaiKhoan taiKhoan)
        {
            dal_tk.UpdateTK(taiKhoan);
        }

        // Xóa tài khoản
        public void DeleteTaiKhoan(int id)
        {
            dal_tk.DelTK(id);
        }

        // Lấy ID lớn nhất
        public int GetMaxIdTaiKhoan()
        {
            return dal_tk.GetMaxIdTK();
        }
    }
}
