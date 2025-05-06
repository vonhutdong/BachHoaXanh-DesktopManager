using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_TaiKhoan
    {
        private DatabaseAccess da = new DatabaseAccess();
        public DatabaseAccess Da { get => da; set => da = value; }

        // Kiểm tra đăng nhập
        public bool CheckTaiKhoan(string taiKhoan, string matKhau)
        {
            return da.Db.TaiKhoans.Any(tk => tk.TenTaiKhoan == taiKhoan && tk.MatKhau == matKhau);
        }

        // Lấy ID tài khoản
        public int GetIdTaiKhoan(string taiKhoan, string matKhau)
        {
            var tk = da.Db.TaiKhoans.FirstOrDefault(t => t.TenTaiKhoan == taiKhoan && t.MatKhau == matKhau);
            return tk?.id ?? -1;
        }

        // Lấy danh sách tất cả tài khoản
        public IQueryable GetListTK()
        {
            return from tk in da.Db.TaiKhoans
                   select new
                   {
                       tk.id,
                       tk.MaTaiKhoan,
                       tk.TenTaiKhoan,
                       tk.MatKhau,
                       tk.Quyen
                   };
        }

        // Lấy danh sách quyền
        public IQueryable GetListTKByQuyen()
        {
            return da.Db.TaiKhoans
                       .GroupBy(tk => tk.Quyen)
                       .Select(q => new { Quyen = q.Key });
        }

        // Lấy tất cả tài khoản theo tên
        public IQueryable GetListAllTKByTenTK()
        {
            return da.Db.TaiKhoans
                       .Select(tk => new { tk.id, tk.TenTaiKhoan });
        }

        // Lấy 1 tài khoản theo ID
        public IQueryable GetListOneTKByTenTK(int id)
        {
            return da.Db.TaiKhoans
                       .Where(tk => tk.id == id)
                       .Select(tk => new { tk.id, tk.TenTaiKhoan });
        }
        //lay danh sach tk theo id
        public IQueryable GetAllListTKByTenTK(int id)
        {
            return da.Db.TaiKhoans
                       .Where(tk => tk.id == id)
                       .Select(tk => new { tk.id, tk.TenTaiKhoan });
        }
        // Lấy quyền theo tài khoản
        public int GetRole(string taiKhoan, string matKhau)
        {
            var result = da.Db.TaiKhoans.FirstOrDefault(tk => tk.TenTaiKhoan == taiKhoan && tk.MatKhau == matKhau);
            return result?.Quyen ?? -1;
        }

        // Thêm tài khoản có mã tự sinh (MaTaiKhoan không bị nhảy số)
        public void AddTaiKhoan(DTO_TaiKhoan taiKhoan)
        {
            var existed = da.Db.TaiKhoans.FirstOrDefault(tk => tk.TenTaiKhoan == taiKhoan.TenTaiKhoan);
            if (existed != null) throw new Exception("Tài khoản đã tồn tại.");

            // Lấy danh sách mã tài khoản hiện có
            var existingIds = da.Db.TaiKhoans
                .Select(t => t.MaTaiKhoan)
                .ToList();

            // Tìm số nhỏ nhất chưa dùng
            int nextNumber = 1;
            string maTK;
            while (true)
            {
                maTK = nextNumber < 10 ? $"TK00{nextNumber}" :
                       nextNumber < 100 ? $"TK0{nextNumber}" : $"TK{nextNumber}";

                if (!existingIds.Contains(maTK))
                    break;

                nextNumber++;
            }

            // Lấy ID lớn nhất để tiếp tục tăng (hoặc 1 nếu rỗng)
            int nextId = da.Db.TaiKhoans.Any() ? da.Db.TaiKhoans.Max(t => t.id) + 1 : 1;

            TaiKhoan newTK = new TaiKhoan
            {
                id = nextId,
                MaTaiKhoan = maTK,
                TenTaiKhoan = taiKhoan.TenTaiKhoan,
                MatKhau = taiKhoan.MatKhau,
                Quyen = taiKhoan.Quyen
            };

            da.Db.TaiKhoans.InsertOnSubmit(newTK);
            da.Db.SubmitChanges();
        }


        // Cập nhật tài khoản
        public void UpdateTK(DTO_TaiKhoan taiKhoan)
        {
            var tk = da.Db.TaiKhoans.FirstOrDefault(t => t.id == taiKhoan.Id);
            if (tk == null) throw new Exception("Tài khoản không tồn tại.");

            tk.TenTaiKhoan = taiKhoan.TenTaiKhoan;
            tk.MatKhau = taiKhoan.MatKhau;
            tk.Quyen = taiKhoan.Quyen;

            da.Db.SubmitChanges();
        }

        // Xóa tài khoản
        public void DelTK(int id)
        {
            var tk = da.Db.TaiKhoans.FirstOrDefault(t => t.id == id);
            if (tk == null) throw new Exception("Tài khoản không tồn tại.");

            da.Db.TaiKhoans.DeleteOnSubmit(tk);
            da.Db.SubmitChanges();
        }

        // Lấy ID lớn nhất
        public int GetMaxIdTK()
        {
            return da.Db.TaiKhoans.Any() ? da.Db.TaiKhoans.Max(t => t.id) : 0;
        }
    }
}
