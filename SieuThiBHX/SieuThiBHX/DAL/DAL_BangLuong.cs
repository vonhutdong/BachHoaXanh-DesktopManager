using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{

    public class DAL_BangLuong
    {
        private DatabaseAccess da = new DatabaseAccess();

        public IQueryable LayDSBangLuong()
        {
            try
            {
                return (from b in da.Db.BangLuongs
                        join nv in da.Db.NhanViens
                        on b.idNhanVien equals nv.id
                        select new
                        {
                            b.id,
                            nv.TenNhanVien,
                            b.MaBangLuong,
                            b.ThangNam,
                            b.TongGioCong,
                            b.Luong,
                            b.idNhanVien
                        });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        //ds bảng lương co dieu kien
        public IQueryable LayDSBangLuong(int idNhanVien)
        {
            try
            {
                return (from b in da.Db.BangLuongs
                        join nv in da.Db.NhanViens
                        on b.idNhanVien equals nv.id
                        where b.idNhanVien == idNhanVien
                        select new
                        {
                            b.id,
                            nv.TenNhanVien,
                            b.MaBangLuong,
                            b.ThangNam,
                            b.TongGioCong,
                            b.Luong,
                            b.idNhanVien
                        });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public IQueryable LayBangLuongTheoThang(int idNhanVien, int thang, int nam)
        {
            try
            {
                return (from b in da.Db.BangLuongs
                        join nv in da.Db.NhanViens
                        on b.idNhanVien equals nv.id
                        where b.idNhanVien == idNhanVien
                              && b.ThangNam.Value.Month == thang
                              && b.ThangNam.Value.Year == nam
                        select new
                        {
                            b.id,
                            nv.TenNhanVien,
                            b.MaBangLuong,
                            b.ThangNam,
                            b.TongGioCong,
                            b.Luong,
                            b.idNhanVien
                        });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ThemBangLuong(DTO_BangLuong bangluong)
        {
            try
            {
                var query2 = da.Db.BangLuongs.OrderByDescending(x => x.id).FirstOrDefault();
                var data = da.Db.BangLuongs.SingleOrDefault(cn => cn.MaBangLuong == bangluong.MaBangLuong);
                if (data == null)
                {
                    da.Db.BangLuongs.InsertOnSubmit(new BangLuong
                    {
                        MaBangLuong = query2 != null && query2.id < 10 ? "BL00" + (query2.id + 1) : "BL0" + (query2?.id + 1),
                        ThangNam = bangluong.ThangNam,
                        Luong = bangluong.Luong,
                        TongGioCong = bangluong.TongGioCong,
                        idNhanVien = bangluong.IdNhanVien

                    });
                    da.Db.SubmitChanges();
                }
                else
                {
                    throw new Exception("Mã bảng lương đã tồn tại");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra: " + ex.Message);
            }
        }

        public IQueryable DSNhanVien()
        {
            return from nv in da.Db.NhanViens
                   select nv;
        }
    }
}
