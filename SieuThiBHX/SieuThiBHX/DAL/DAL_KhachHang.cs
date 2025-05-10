using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_KhachHang
    {
        private DatabaseAccess da = new DatabaseAccess();

        public IQueryable<DTO_KhachHang> LayDSKH()
        {
            return from kh in da.Db.KhachHangs
                   select new DTO_KhachHang
                   (
                       kh.id,
                       kh.maKhachHang,
                       kh.tenKhachHang,
                       kh.soDienThoai,
                       kh.DiaChi,
                       kh.diem ?? 0
                   );
        }

        public DTO_KhachHang LayKhachHang_SDT(string sodienthoai)
        {
            var linqKH = da.Db.KhachHangs.FirstOrDefault(kh => kh.soDienThoai == sodienthoai);
            if (linqKH == null)
            {
                return null;
            }

            DTO_KhachHang khachhang = new DTO_KhachHang
            {
                Id = linqKH.id,
                TenKH = linqKH.tenKhachHang,
                MaKH = linqKH.maKhachHang,
                SoDienThoai = linqKH.soDienThoai,
                DiaChi = linqKH.DiaChi,
                Diem = (float)(linqKH.diem ?? 0)
            };

            return khachhang;
        }
        public bool ThemKH(DTO_KhachHang khachHang)
        {
            try
            {
                if (khachHang == null)
                    return false;

                // Lấy id lớn nhất để tạo mã khách hàng mới
                var lastKH = da.Db.KhachHangs.OrderByDescending(kh => kh.id).FirstOrDefault();
                int newId = (lastKH != null) ? lastKH.id + 1 : 1;
                string maKH = newId < 10 ? "KH0" + newId : "KH" + newId;

                KhachHang newKH = new KhachHang
                {
                    maKhachHang = maKH,
                    tenKhachHang = khachHang.TenKH,
                    soDienThoai = khachHang.SoDienThoai,
                    DiaChi = khachHang.DiaChi,
                    diem = khachHang.Diem
                };

                da.Db.KhachHangs.InsertOnSubmit(newKH);
                da.Db.SubmitChanges();

                return true;
            }
            catch
            {
                return false; // hoặc log lỗi nếu cần
            }
        }
        public bool XoaKH(int id)
        {
            try
            {
                var kh = da.Db.KhachHangs.FirstOrDefault(k => k.id == id);
                if (kh != null)
                {
                    da.Db.KhachHangs.DeleteOnSubmit(kh);
                    da.Db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaKH(DTO_KhachHang khachHang)
        {
            try
            {
                var kh = da.Db.KhachHangs.FirstOrDefault(dt => dt.id == khachHang.Id);
                if (kh != null)
                {
                    kh.tenKhachHang = khachHang.TenKH;
                    kh.soDienThoai = khachHang.SoDienThoai;
                    kh.DiaChi = khachHang.DiaChi;
                    kh.diem = khachHang.Diem;

                    da.Db.SubmitChanges();
                    return true;
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


        public IQueryable<DTO_KhachHang> TimKiemTheoTenHoacSDT(string tukhoa)
        {
            string keyword = RemoveDiacritics(tukhoa.ToLower());

            var danhSach = da.Db.KhachHangs.ToList()
                .Where(kh =>
                    (!string.IsNullOrEmpty(kh.tenKhachHang) &&
                        RemoveDiacritics(kh.tenKhachHang.ToLower()).Contains(keyword))
                    ||
                    (!string.IsNullOrEmpty(kh.soDienThoai) &&
                        kh.soDienThoai.Contains(tukhoa))
                    ||
                    (!string.IsNullOrEmpty(kh.DiaChi) &&
                        RemoveDiacritics(kh.DiaChi.ToLower()).Contains(keyword))
                )
                .Select(kh => new DTO_KhachHang(
                    kh.id,
                    kh.maKhachHang,
                    kh.tenKhachHang,
                    kh.soDienThoai,
                    kh.DiaChi,
                    (float)(kh.diem ?? 0)))
                .AsQueryable();

            return danhSach;
        }


    }
}
