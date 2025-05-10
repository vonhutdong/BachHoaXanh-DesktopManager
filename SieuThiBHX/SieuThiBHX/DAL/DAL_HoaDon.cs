using System;
using System.Collections.Generic;
using System.Globalization;
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
                       MaHD = hd.maHD,
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

        private string RemoveDiacritics(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            var normalized = input.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
        public IQueryable TimKiemHD(string tuKhoa)
        {
            tuKhoa = tuKhoa.ToLower();

            var danhSach = da.Db.HoaDons
                .Where(hd =>
                    hd.maHD.ToLower().Contains(tuKhoa) ||
                    hd.KhachHang.tenKhachHang.ToLower().Contains(tuKhoa)
                )
                .Select(hd => new
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
                    TenKhachHang = hd.KhachHang.tenKhachHang,
                    TenKhuyenMai = hd.KhuyenMai.TenKhuyenMai,
                    TenNhanVien = hd.NhanVien.TenNhanVien
                })
                .AsQueryable();

            return danhSach;
        }

        public int GetMaxIdHD()
        {
            var query = da.Db.HoaDons.OrderByDescending(hd => hd.id).FirstOrDefault();
            return (int)query.id;
        }

        public void UpdateTotalCash2(int idHd, int toTalCash)
        {
            var hd_update = da.Db.HoaDons.SingleOrDefault(hd => hd.id == idHd);
            hd_update.tongTien = toTalCash;
            if (hd_update.idKhuyenMai == 1)
            {
                hd_update.thanhTien = toTalCash;
            }
            else
            {
                var khuyenmai = da.Db.KhuyenMais.SingleOrDefault(d => d.id == hd_update.idKhuyenMai);
                hd_update.thanhTien = toTalCash - (toTalCash * (float)(khuyenmai.GiaTri / 100));
            }

            var query = da.Db.KhuyenMais.SingleOrDefault(km => km.id == hd_update.idKhuyenMai);
            hd_update.thanhTien = toTalCash - ((query.GiaTri / 100) * toTalCash);

            // Saved
            da.Db.SubmitChanges();
        }
        //tìm idhoadon bang MaHoaDon
        public string TimMaHoaDon(int id)
        {
            var query = (from hd in da.Db.HoaDons
                         where hd.id == id
                         select new
                         {
                             hd.id,
                             hd.maHD,

                         }).FirstOrDefault();
            string maHoaDon = "";
            if (query == null)
            {
                maHoaDon = "";
            }
            else
            {
                maHoaDon = query.maHD;
            }


            return maHoaDon;
        }
        public void AddHD2(DTO_HoaDon hoaDon)
        {
            try
            {
                // Kiểm tra hóa đơn đã tồn tại chưa
                var query = (from hd in da.Db.HoaDons
                             where hd.id == hoaDon.Id
                             select hd).FirstOrDefault();

                if (query == null)
                {
                    // Lấy hóa đơn có id lớn nhất
                    var query2 = da.Db.HoaDons.OrderByDescending(hd => hd.id).FirstOrDefault();
                    int nextId = query2 != null ? query2.id + 1 : 1;

                    // Thêm hóa đơn mới
                    da.Db.HoaDons.InsertOnSubmit(new HoaDon
                    {
                        maHD = nextId < 10 ? $"HD00{nextId}" : $"HD0{nextId}",
                        ngayLapHD = DateTime.Now,
                        gioLapHD = DateTime.Now,
                        tongTien = 0,
                        thanhTien = 0,
                        idKhachHang = hoaDon.IdKhachHang,
                        idKhuyenMai = hoaDon.IdKhuyenMai,
                        idNhanVien = hoaDon.IdNhanVien
                    });

                    da.Db.SubmitChanges();
                }
            }
            catch
            {
                // Tùy bạn xử lý logging nội bộ nếu cần
                throw;
            }
        }

    }
}
