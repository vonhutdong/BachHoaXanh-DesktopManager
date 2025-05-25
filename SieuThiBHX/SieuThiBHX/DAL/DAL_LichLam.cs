using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_LichLam
    {
        private DatabaseAccess da = new DatabaseAccess();

        public DatabaseAccess Da { get => da; set => da = value; }

        // Methods
        // LayDSLichLam()
        public IQueryable LayDSLichLam()
        {
            try
            {
                return (from b in da.Db.LichLams
                        join nv in da.Db.NhanViens
                        on b.idNhanVien equals nv.id
                        join cl in da.Db.CaLams
                        on b.idCaLam equals cl.id
                        select new
                        {
                            b.id,
                            MaLichLam = b.MaLichLam,
                            NgayLam = b.NgayLam,
                            TenNhanVien = nv.TenNhanVien,
                            TenCaLam = cl.TenCaLam,
                            Ten = b.idCaLam,
                        });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // ThemLichLam()
        public bool ThemLichLam(DTO_LichLam lichLam)
        {
            try
            {
                if (lichLam == null || lichLam.IdCaLam <= 0 || lichLam.IdNhanVien <= 0)
                    return false;

                int newId = 1;
                var lastLichLam = da.Db.LichLams.OrderByDescending(l => l.id).FirstOrDefault();
                if (lastLichLam != null)
                {
                    newId = lastLichLam.id + 1;
                }

                string maLichLam = newId < 10 ? "LL00" + newId : "LL0" + newId;

                da.Db.LichLams.InsertOnSubmit(new LichLam
                {
                    MaLichLam = maLichLam,
                    NgayLam = lichLam.NgayLam,
                    idNhanVien = lichLam.IdNhanVien,
                    idCaLam = lichLam.IdCaLam,
                });

                da.Db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm lịch làm: " + ex.Message, ex);
            }
        }


        // XoaLichLam()
        public bool XoaLichLam(int id)
        {
            try
            {
                var data = da.Db.LichLams.FirstOrDefault(dt => dt.id == id);
                if (data == null)
                    return false;

                da.Db.LichLams.DeleteOnSubmit(data);
                da.Db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa lịch làm: " + ex.Message, ex);
            }
        }


        // SuaLichLam()
        public bool SuaLichLam(DTO_LichLam lichLam)
        {
            try
            {
                if (lichLam == null || lichLam.Id <= 0)
                    return false;

                var ll = da.Db.LichLams.FirstOrDefault(dt => dt.id == lichLam.Id);
                if (ll != null)
                {
                    // Tránh gán null cho cột không cho phép null
                    if (!string.IsNullOrWhiteSpace(lichLam.MaLichLam))
                        ll.MaLichLam = lichLam.MaLichLam;

                    ll.NgayLam = lichLam.NgayLam;
                    ll.idNhanVien = lichLam.IdNhanVien;
                    ll.idCaLam = lichLam.IdCaLam;

                    da.Db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật lịch làm: " + ex.Message, ex);
            }
        }






        public IQueryable LayDSNV()
        {
            IQueryable temp = from ll in da.Db.NhanViens
                              select new
                              {
                                  ll.id,
                                  ll.TenNhanVien,
                              };
            return temp;
        }

        //Tìm kiếm theo tên
        public IQueryable timkiemTheoTen(string ten)
        {
            return from b in da.Db.LichLams
                   join nv in da.Db.NhanViens
                   on b.idNhanVien equals nv.id
                   join cl in da.Db.CaLams
                   on b.idCaLam equals cl.id
                   where nv.TenNhanVien.Contains(ten) // Điều kiện tìm kiếm theo tên
                   select new
                   {
                       id = b.id,
                       MaLichLam = b.MaLichLam,
                       NgayLam = b.NgayLam,
                       TenNhanVien = nv.TenNhanVien,
                       TenCaLam = cl.TenCaLam,
                       ten = b.idCaLam,
                   }; // Trả về đối tượng LichLam
        }


        //Tìm kiếm theo số điện thoại
        public IQueryable timkiemTheoNgay(DateTime ngay)
        {
            return from b in da.Db.LichLams
                   join nv in da.Db.NhanViens
                   on b.idNhanVien equals nv.id
                   join cl in da.Db.CaLams
                   on b.idCaLam equals cl.id
                   where b.NgayLam.Value.Date == ngay.Date
                   select new
                   {
                       id = b.id,
                       MaLichLam = b.MaLichLam,
                       NgayLam = b.NgayLam,
                       TenNhanVien = nv.TenNhanVien,
                       TenCaLam = cl.TenCaLam,
                       ten = b.idCaLam,
                   };
        }

        public bool DellLL(int id)
        {
            try
            {
                var lichLam = da.Db.LichLams.SingleOrDefault(lnv => lnv.id == id);

                if (lichLam != null)
                {
                    da.Db.LichLams.DeleteOnSubmit(lichLam); // Xóa lịch làm
                    da.Db.SubmitChanges(); // Lưu thay đổi
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa lịch làm: {ex.Message}");
                return false;
            }
            return false;
        }
        public LichLam GetLichLamByMa(int maLichLam)
        {
            return da.Db.LichLams
                .FirstOrDefault(ll => ll.id == maLichLam);
        }



    }
}