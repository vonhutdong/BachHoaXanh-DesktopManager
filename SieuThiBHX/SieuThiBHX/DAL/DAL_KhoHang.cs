using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_KhoHang
    {
        // Fields
        private DatabaseAccess da = new DatabaseAccess();
        // Methods
        public IQueryable LoadKhoHang()
        {
            var result = from kh in da.Db.KhoHangs
                         join sp in da.Db.SanPhams on kh.idSanPham equals sp.id
                         group kh by new { kh.idSanPham, sp.tenSanPham } into g
                         select new
                         {
                             idSanPham = g.Key.idSanPham,
                             TenSanPham = g.Key.tenSanPham,
                             SoLuong = g.Sum(kh => kh.soLuong),
                             id = g.Select(kh => kh.id).FirstOrDefault() // hoặc default nếu không cần
                         };
            return result;
        }


        //sửa kho
        public void SuaKhoHang(DTO_KhoHang khohang)
        {
            try
            {
                // Tìm tất cả dòng của sản phẩm này trong kho
                var danhSachKho = da.Db.KhoHangs.Where(k => k.idSanPham == khohang.IdSanPham).ToList();

                if (danhSachKho.Count == 0) return;

                // Tổng hiện tại
                int tongSoLuongHienTai = danhSachKho.Sum(k => k.soLuong) ?? 0;

                // Tính chênh lệch cần cập nhật
                int chenhlech = khohang.SoLuong - tongSoLuongHienTai;

                // Cộng vào dòng đầu tiên
                danhSachKho[0].soLuong += chenhlech;

                da.Db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi sửa kho hàng: " + ex.Message);
            }
        }
        public DataTable LoadReportData()
        {
            var query = from kh in da.Db.KhoHangs
                        join sp in da.Db.SanPhams on kh.idSanPham equals sp.id
                        join ct in da.Db.ChiTietPhieuNhaps on kh.idChiTietPhieuNhap equals ct.id
                        join pn in da.Db.PhieuNhaps on ct.idPhieuNhap equals pn.id
                        where kh.soLuong > 0
                        select new
                        {
                            MaSanPham = sp.maSanPham,
                            TenSanPham = sp.tenSanPham,
                            SoLuong = kh.soLuong,
                            NgayNhap = pn.NgayNhap.Value.Date
                        };

            // Tạo DataTable thủ công
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSanPham", typeof(string));
            dt.Columns.Add("TenSanPham", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("NgayNhap", typeof(DateTime));

            foreach (var item in query.ToList())
            {
                dt.Rows.Add(item.MaSanPham, item.TenSanPham, item.SoLuong, item.NgayNhap);
            }

            return dt;
        }
        public void CapNhatSoLuong(int id, int soluong)
        {
            try
            {
                var khohang = da.Db.KhoHangs.FirstOrDefault(kh => kh.idSanPham == id);
                khohang.soLuong -= soluong;
                da.Db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
