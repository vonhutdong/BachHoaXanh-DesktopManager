using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_KhuyenMai
    {
        private DatabaseAccess da = new DatabaseAccess();
        public DatabaseAccess Da { get => da; set => da = value; }

        public int getIdKhuyenMai(string maKM)
        {
            var query = da.Db.KhuyenMais.FirstOrDefault(dl => dl.MaKhuyenMai == maKM);
            if (query == null)
            {
                return 0;
            }
            return query.id;
        }
        public IQueryable GetListKM()
        {
            IQueryable query = from km in da.Db.KhuyenMais
                               select new
                               {
                                   km.id,
                                   km.MaKhuyenMai,
                                   km.TenKhuyenMai,
                                   km.GiaTri
                               };
            return query;
        }
        public void AddKM(DTO_KhuyenMai khuyenMai)
        {
            var existed = da.Db.KhuyenMais.FirstOrDefault(km => km.TenKhuyenMai == khuyenMai.TenKhuyenMai);
            if (existed != null)
                throw new Exception("Tên khuyến mãi đã tồn tại.");
            // Lấy danh sách mã khuyến mãi đã có
            var existingMaKMs = da.Db.KhuyenMais
                .Select(km => km.MaKhuyenMai)
                .ToList();
            // Tìm số nhỏ nhất chưa dùng
            int nextNumber = 1;
            string maKM;
            while (true)
            {
                maKM = nextNumber < 10 ? $"KM00{nextNumber}" :
                       nextNumber < 100 ? $"KM0{nextNumber}" : $"KM{nextNumber}";
                if (!existingMaKMs.Contains(maKM))
                    break;
                nextNumber++;
            }
            int nextId = da.Db.KhuyenMais.Any() ? da.Db.KhuyenMais.Max(t => t.id) + 1 : 1;
            // Thêm khuyến mãi mới
            KhuyenMai newKM = new KhuyenMai
            {
                MaKhuyenMai = maKM,
                TenKhuyenMai = khuyenMai.TenKhuyenMai,
                GiaTri = khuyenMai.GiaTri,
            };
            da.Db.KhuyenMais.InsertOnSubmit(newKM);
            da.Db.SubmitChanges();
        }
        public void UpdateKM(DTO_KhuyenMai khuyenMai)
        {
            var km = da.Db.KhuyenMais.FirstOrDefault(t => t.id == khuyenMai.Id);
            if (km == null) throw new Exception("Mã khuyến mãi không tồn tại.");

            km.TenKhuyenMai = khuyenMai.TenKhuyenMai;
            km.GiaTri = khuyenMai.GiaTri;
            da.Db.SubmitChanges();
        }

        // Xóa tài khoản
        public void DelKM(int id)
        {
            var km = da.Db.KhuyenMais.FirstOrDefault(t => t.id == id);
            if (km == null) throw new Exception("Mã khuyến mãi không tồn tại.");

            da.Db.KhuyenMais.DeleteOnSubmit(km);
            da.Db.SubmitChanges();
        }



    }
}
