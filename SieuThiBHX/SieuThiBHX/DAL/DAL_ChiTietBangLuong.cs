using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_ChiTietBangLuong
    {
        private DatabaseAccess da = new DatabaseAccess();

        public IQueryable LayDSBangLuong()
        {
            try
            {
                return (from ct in da.Db.ChiTietBangLuongs
                        select new { ct.id, ct.idBangLuong, ct.NgayLam, ct.SoGioCongThucTe });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        //ds bảng lương co dieu kien
        public IQueryable LayDSChiTietBangLuong(int idBangLuong)
        {
            try
            {
                return (from ct in da.Db.ChiTietBangLuongs
                            //on ct.idNhanVien equals nv.id
                        where ct.idBangLuong == idBangLuong
                        select new { ct.id, ct.idBangLuong, ct.NgayLam, ct.SoGioCongThucTe });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public IQueryable LayDSLichLam()
        {
            return from ll in da.Db.LichLams select ll;
        }
        public void ThemChiTietBangLuong(DTO_ChiTietBangLuong ctbl)
        {
            try
            {
                var query2 = da.Db.ChiTietBangLuongs.OrderByDescending(x => x.id).FirstOrDefault();

                // Lấy bảng lương cần kiểm tra
                var bangluong = da.Db.BangLuongs.FirstOrDefault(bl => bl.id == ctbl.IdBangLuong);

                if (bangluong == null)
                    throw new Exception("Không tìm thấy bảng lương tương ứng.");

                if (bangluong.ThangNam.HasValue &&
                    bangluong.ThangNam.Value.Month == ctbl.NgayLam.Month &&
                    bangluong.ThangNam.Value.Year == ctbl.NgayLam.Year)
                {
                    // Kiểm tra trùng ngày làm
                    bool trungNgayLam = da.Db.ChiTietBangLuongs.Any(ct =>
                        ct.idBangLuong == ctbl.IdBangLuong &&
                        ct.NgayLam.Value.Date == ctbl.NgayLam.Date);

                    if (trungNgayLam)
                    {
                        throw new Exception("Đã tồn tại chi tiết bảng lương cho ngày này.");
                    }

                    // Cho phép thêm vì cùng tháng
                    ChiTietBangLuong chi = new ChiTietBangLuong
                    {
                        MaChiTietBangLuong = query2 != null && query2.id < 10
                            ? "CTBL00" + (query2.id + 1)
                            : "CTBL0" + (query2?.id + 1),
                        idBangLuong = ctbl.IdBangLuong,
                        idLichLam = ctbl.IdLichLam,
                        SoGioCongThucTe = ctbl.SoGioCongThucTe,
                        NgayLam = ctbl.NgayLam
                    };

                    da.Db.ChiTietBangLuongs.InsertOnSubmit(chi);
                    da.Db.SubmitChanges();

                    // Cập nhật bảng lương
                    var tongGioCong = da.Db.ChiTietBangLuongs
                        .Where(ct => ct.idBangLuong == ctbl.IdBangLuong)
                        .Sum(ct => ct.SoGioCongThucTe);

                    bangluong.TongGioCong = tongGioCong;
                    bangluong.Luong = tongGioCong * 50000;
                    da.Db.SubmitChanges();
                }
                else
                {
                    throw new Exception("Chỉ được thêm chi tiết bảng lương trong cùng tháng/năm với bảng lương.");
                }



            }
            catch (Exception ex)
            {
                throw new Exception("có lỗi xảy ra: " + ex.Message);
            }

        }
    }
}
