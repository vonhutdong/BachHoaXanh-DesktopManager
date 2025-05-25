using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_PhieuNhapAll
    {
        // Fields
        private DatabaseAccess da = new DatabaseAccess();
        public DatabaseAccess Da { get => da; set => da = value; }

        // Lấy danh sách phiếu nhập
        public IQueryable LayDSPhieuNhap()
        {
            IQueryable temp = from pn in da.Db.PhieuNhaps
                              select new
                              {
                                  id = pn.id,
                                  MaPhieuNhap = pn.MaPhieuNhap,
                                  NgayNhap = pn.NgayNhap,
                                  ThanhTien = pn.ThanhTien,
                                  MaNhanVien = pn.idNhanVien
                              };
            return temp;
        }

        public IQueryable LayDSNhanVien()
        {
            IQueryable queryable = from nv in da.Db.NhanViens
                                   select new
                                   {
                                       nv.id,
                                       nv.MaNhanVien,
                                       nv.TenNhanVien,
                                       nv.SoDienThoai,
                                       nv.DiaChi,
                                       nv.idLoaiNhanVien,
                                       nv.idTaiKhoan
                                   };
            return queryable;
        }

        // Thêm phiếu nhập
        public bool ThemPhieuNhap(DTO_PhieuNhap pn)
        {
            try
            {
                if (pn != null)
                {
                    // Tìm MaPhieuNhap lớn nhất hiện tại
                    var lastMaPN = da.Db.PhieuNhaps
                        .OrderByDescending(p => p.MaPhieuNhap)
                        .Select(p => p.MaPhieuNhap)
                        .FirstOrDefault();

                    int nextNumber = 1;

                    if (!string.IsNullOrEmpty(lastMaPN) && lastMaPN.StartsWith("PN"))
                    {
                        string numberPart = lastMaPN.Substring(2); // Bỏ "PN", lấy phần số
                        if (int.TryParse(numberPart, out int parsed))
                        {
                            nextNumber = parsed + 1;
                        }
                    }

                    // Tạo mã phiếu nhập mới: PN001, PN010, PN105,...
                    string maPhieuNhap = "PN" + nextNumber.ToString("D3");

                    // Tạo đối tượng mới
                    var newPhieuNhap = new PhieuNhap
                    {
                        MaPhieuNhap = maPhieuNhap,
                        NgayNhap = pn.NgayNhap,
                        ThanhTien = 0, // Tạm thời gán 0
                        idNhanVien = pn.IdNhanVien
                    };

                    da.Db.PhieuNhaps.InsertOnSubmit(newPhieuNhap);
                    da.Db.SubmitChanges();

                    return true;
                }
                else
                {
                    throw new Exception("Dữ liệu phiếu nhập không hợp lệ (null).");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm phiếu nhập: " + ex.Message);
            }
        }


        // Sửa phiếu nhập
        public bool SuaPhieuNhap(DTO_PhieuNhap pn)
        {
            try
            {
                var pnn = da.Db.PhieuNhaps.FirstOrDefault(dt => dt.id == pn.Id);
                if (pnn != null)
                {
                    pnn.NgayNhap = pn.NgayNhap;
                    pnn.idNhanVien = pn.IdNhanVien;
                    // Không sửa thành tiền trực tiếp!
                    da.Db.SubmitChanges();

                    return true;
                }
                else
                {
                    throw new Exception("Không tìm thấy phiếu nhập để sửa.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi sửa phiếu nhập: " + ex.Message);
            }
        }

        // Xóa phiếu nhập
        public void XoaPhieuNhap(int id)
        {
            try
            {
                var data = da.Db.PhieuNhaps.FirstOrDefault(dt => dt.id == id);
                if (data == null)
                {
                    throw new Exception("Không tìm thấy phiếu nhập để xóa.");
                }

                da.Db.PhieuNhaps.DeleteOnSubmit(data);
                da.Db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa phiếu nhập: " + ex.Message);
            }
        }

        // ✅ Hàm cập nhật lại thành tiền từ chi tiết phiếu nhập
        public void CapNhatThanhTien(int idPhieuNhap)
        {
            try
            {
                var phieuNhap = da.Db.PhieuNhaps.FirstOrDefault(p => p.id == idPhieuNhap);
                if (phieuNhap != null)
                {
                    var thanhTien = da.Db.ChiTietPhieuNhaps
                        .Where(c => c.idPhieuNhap == idPhieuNhap)
                        .Sum(c => (double?)(c.SoLuong * c.DonGia)); // Trả về double?

                    phieuNhap.ThanhTien = thanhTien ?? 0; // Gán 0 nếu null

                    da.Db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật thành tiền: " + ex.Message);
            }
        }
        public DataTable LayDSPhieuNhapVaChiTiet_BaoCao()
        {
            string connectionString = da.Db.Connection.ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetDanhSachPhieuNhapVaChiTiet", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

    }
}
