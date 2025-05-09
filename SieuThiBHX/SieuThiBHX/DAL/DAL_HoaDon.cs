using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_HoaDon
    {
        DatabaseAccess da = new DatabaseAccess();

        public IQueryable GetListHD()
        {
            return from hd in da.Db.HoaDons
                   join kh in da.Db.KhachHangs on hd.idKhachHang equals kh.id
                   join nv in da.Db.NhanViens on hd.idNhanVien equals nv.id
                   join km in da.Db.KhuyenMais on hd.idKhuyenMai equals km.id into leftJoinKM
                   from km in leftJoinKM.DefaultIfEmpty() // phòng trường hợp không có KM
                   select new
                   {
                       hd.id,
                       hd.maHD,
                       hd.ngayLapHD,
                       hd.gioLapHD,
                       hd.tongTien,
                       hd.thanhTien,
                       hd.idKhuyenMai,
                       hd.idKhachHang,
                       hd.idNhanVien,
                       TenKhachHang = kh.tenKhachHang,
                       TenKhuyenMai = km != null ? km.TenKhuyenMai : "Không áp dụng",
                       TenNhanVien = nv.TenNhanVien
                   };
        }
        public bool DeleteHD(int id)
        {
            try
            {
                var hd = da.Db.HoaDons.SingleOrDefault(h => h.id == id);
                if (hd != null)
                {
                    da.Db.HoaDons.DeleteOnSubmit(hd);
                    da.Db.SubmitChanges();
                    return true; // Xóa thành công
                }
                return false; // Không tìm thấy
            }
            catch
            {
                return false; // Có lỗi xảy ra
            }
        }

        public bool UpdateHD(DTO_HoaDon hoaDon)
        {
            try
            {
                if (hoaDon != null)
                {
                    HoaDon hd_update = da.Db.HoaDons.SingleOrDefault(hd => hd.id == hoaDon.Id);

                    if (hd_update != null)
                    {
                        hd_update.idKhachHang = hoaDon.IdKhachHang;
                        hd_update.idKhuyenMai = hoaDon.IdKhuyenMai;
                        hd_update.idNhanVien = hoaDon.IdNhanVien;

                        da.Db.SubmitChanges();
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }


    }
}
