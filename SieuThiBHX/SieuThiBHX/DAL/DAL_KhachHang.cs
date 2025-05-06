using System;
using System.Collections.Generic;
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
        public void XoaKH(int id)
        {
            try
            {
                // Tìm khách hàng theo ID
                var data = da.Db.KhachHangs.FirstOrDefault(dt => dt.id == id);
                if (data != null)
                {
                    da.Db.KhachHangs.DeleteOnSubmit(data);
                    da.Db.SubmitChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy khách hàng với ID này.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi xóa khách hàng: " + ex.Message);
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
        public IQueryable<DTO_KhachHang> TimKiemTheoTen(string ten)
        {
            return da.Db.KhachHangs
                .Where(kh => kh.tenKhachHang.Contains(ten))
                .Select(kh => new DTO_KhachHang
                (
                    kh.id,
                    kh.maKhachHang,
                    kh.tenKhachHang,
                    kh.soDienThoai,
                    (float)(kh.diem ?? 0) // nếu diem là nullable trong DB
                ));
        }
        public IQueryable<DTO_KhachHang> TimKiemTheoSoDienThoai(string soDienThoai)
        {
            return da.Db.KhachHangs
                .Where(kh => kh.soDienThoai.Contains(soDienThoai))
                .Select(kh => new DTO_KhachHang
                (
                    kh.id,
                    kh.maKhachHang,
                    kh.tenKhachHang,
                    kh.soDienThoai,
                    (float)(kh.diem ?? 0)
                ));
        }




    }
}
