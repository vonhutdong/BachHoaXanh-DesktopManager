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
                   select new
                   {
                       hd.id,
                       hd.maHD,
                       hd.ngayLapHD,
                       hd.gioLapHD,
                       hd.tongTien,
                       hd.thanhTien,
                       hd.idKhachHang,
                       hd.idKhuyenMai,
                       hd.idNhanVien
                   };
        }


    }
}
