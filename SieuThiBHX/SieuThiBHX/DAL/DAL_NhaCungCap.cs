using DTO;
using System;
using System.Linq;

namespace DAL
{
    public class DAL_NhaCungCap
    {
        // Fields
        private DatabaseAccess da = new DatabaseAccess();
        public DatabaseAccess Da { get => da; set => da = value; }

        // LayDSNCC()
        public IQueryable LayDSNCC()
        {
            IQueryable temp = from ncc in da.Db.NhaCungCaps
                              select new
                              {
                                  id = ncc.id,
                                  MaNCC = ncc.MaNhaCungCap,
                                  TenNCC = ncc.TenNhaCungCap,
                                  SDT = ncc.SoDienThoai,
                                  DiaChi = ncc.DiaChi
                              };
            return temp;
        }

        // ThemNCC()
        public void themNCC(DTO_NhaCungCap ncc)
        {
            // Kiểm tra tên nhà cung cấp đã tồn tại
            var existed = da.Db.NhaCungCaps.FirstOrDefault(x => x.TenNhaCungCap == ncc.TenNhaCungCap);
            if (existed != null)
                throw new Exception("Tên nhà cung cấp đã tồn tại.");

            // Lấy danh sách mã NCC đã có
            var existingMaNCCs = da.Db.NhaCungCaps
                .Select(n => n.MaNhaCungCap)
                .ToList();

            // Tìm mã NCC nhỏ nhất chưa dùng
            int nextNumber = 1;
            string maNCC;
            while (true)
            {
                maNCC = nextNumber < 10 ? $"NCC00{nextNumber}" :
                        nextNumber < 100 ? $"NCC0{nextNumber}" : $"NCC{nextNumber}";
                if (!existingMaNCCs.Contains(maNCC))
                    break;
                nextNumber++;
            }

            // Lấy id tiếp theo
            int nextId = da.Db.NhaCungCaps.Any() ? da.Db.NhaCungCaps.Max(t => t.id) + 1 : 1;

            // Tạo và thêm mới
            NhaCungCap newNCC = new NhaCungCap
            {
                MaNhaCungCap = maNCC,
                TenNhaCungCap = ncc.TenNhaCungCap,
                SoDienThoai = ncc.SoDienThoai,
                DiaChi = ncc.DiaChi
            };

            da.Db.NhaCungCaps.InsertOnSubmit(newNCC);
            da.Db.SubmitChanges();
        }


        // XoaNCC()
        public void xoaNCC(int id)
        {
            var ncc = da.Db.NhaCungCaps.FirstOrDefault(t => t.id == id);
            if (ncc == null) throw new Exception("Nhà cung cấp không tồn tại.");

            da.Db.NhaCungCaps.DeleteOnSubmit(ncc);
            da.Db.SubmitChanges();
        }

        // SuaNCC()
        public void suaNCC(DTO_NhaCungCap ncc)
        {
            var nCC = da.Db.NhaCungCaps.FirstOrDefault(t => t.id == ncc.Id);
            if (nCC == null) throw new Exception("Mã khuyến mãi không tồn tại.");

            nCC.TenNhaCungCap = ncc.TenNhaCungCap;
            nCC.SoDienThoai = ncc.SoDienThoai;
            nCC.DiaChi = ncc.DiaChi;
            da.Db.SubmitChanges();
        }
    }
}
