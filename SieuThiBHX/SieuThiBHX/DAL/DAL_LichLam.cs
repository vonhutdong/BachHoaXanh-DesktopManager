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
                // Check mã lịch làm có != null hay không?
                if (lichLam != null)
                {
                    // Check có lịch làm trong DB LichLam hay chưa?
                    var query2 = da.Db.LichLams.OrderByDescending(l => l.id).FirstOrDefault();

                    da.Db.LichLams.InsertOnSubmit(new LichLam
                    {
                        MaLichLam = query2.id < 10 ? "LL0" + (query2.id + 1) : "LL" + (query2.id + 1),
                        NgayLam = lichLam.NgayLam,
                        idNhanVien = lichLam.IdNhanVien,
                        idCaLam = lichLam.IdCaLam,
                    });


                    da.Db.SubmitChanges(); // Xác nhận thay đổi DB LichLam
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return false;
        }

        // XoaLichLam()
        public bool XoaLichLam(int id)
        {
            try
            {
                try
                {
                    //tìm lịch làm
                    var data = da.Db.LichLams.FirstOrDefault(dt => dt.id == id);
                    da.Db.LichLams.DeleteOnSubmit(data);
                    da.Db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Có lỗi xảy ra: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return false;
        }

        // SuaLichLam()
        public bool SuaLichLam(DTO_LichLam lichLam)
        {
            try
            {
                // Kiểm tra mã lịch làm có tồn tại chưa
                var ll = da.Db.LichLams.FirstOrDefault(dt => dt.id == lichLam.Id);
                if (ll != null)
                {
                    ll.MaLichLam = lichLam.MaLichLam;
                    ll.NgayLam = lichLam.NgayLam;
                    ll.idNhanVien = lichLam.IdNhanVien;
                    ll.idCaLam = lichLam.IdCaLam;

                    // Cập nhật thay đổi
                    da.Db.SubmitChanges();
                    return true;
                }
                else
                {
                    // Trường hợp mã lịch làm không tồn tại
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi nếu có
                // Bạn có thể log lỗi ở đây hoặc xử lý lỗi theo cách của mình
                Console.WriteLine(ex.Message);
                return false;
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


    }
}