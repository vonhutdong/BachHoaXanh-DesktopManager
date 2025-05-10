using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class DAL_ChiTietPhieuNhap
    {
        private DatabaseAccess da = new DatabaseAccess();
        private DAL_PhieuNhapAll dalPhieuNhapAll = new DAL_PhieuNhapAll();

        public IQueryable LayDSChiTietPhieuNhap()
        {
            IQueryable temp = from cl in da.Db.ChiTietPhieuNhaps
                              join pn in da.Db.PhieuNhaps
                              on cl.idPhieuNhap equals pn.id
                              join sp in da.Db.SanPhams
                              on cl.idSanPham equals sp.id
                              select new
                              {
                                  id = cl.id,
                                  SoLuong = cl.SoLuong,
                                  DonGia = cl.DonGia,
                                  idPhieuNhap = pn.MaPhieuNhap,
                                  idSanPham = sp.tenSanPham,
                                  idpn = cl.idPhieuNhap,
                                  idsp = cl.idSanPham
                              };
            return temp;
        }
        public IQueryable LayDSSP()
        {
            IQueryable temp = from ll in da.Db.SanPhams
                              select new
                              {
                                  ll.id,
                                  ll.tenSanPham,
                              };
            return temp;
        }
        public bool ThemChiTiet(DTO_ChiTietPhieuNhap ct)
        {
            try
            {
                if (ct != null)
                {
                    ChiTietPhieuNhap chiTiet = new ChiTietPhieuNhap
                    {
                        idPhieuNhap = ct.IdPhieuNhap,
                        idSanPham = ct.IdSanPham,
                        SoLuong = ct.SoLuong,
                        DonGia = ct.DonGia
                    };

                    da.Db.ChiTietPhieuNhaps.InsertOnSubmit(chiTiet);
                    da.Db.SubmitChanges();

                    // ✅ Cập nhật lại thành tiền
                    dalPhieuNhapAll.CapNhatThanhTien(ct.IdPhieuNhap);

                    return true;
                }
                else
                {
                    throw new Exception("Chi tiết phiếu nhập không hợp lệ.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm chi tiết phiếu nhập: " + ex.Message);
            }
        }

        public bool SuaChiTiet(DTO_ChiTietPhieuNhap ct)
        {
            try
            {
                var chiTiet = da.Db.ChiTietPhieuNhaps.FirstOrDefault(c => c.id == ct.Id);
                if (chiTiet != null)
                {
                    chiTiet.idSanPham = ct.IdSanPham;
                    chiTiet.SoLuong = ct.SoLuong;
                    chiTiet.DonGia = ct.DonGia;
                    da.Db.SubmitChanges();

                    // ✅ Cập nhật lại thành tiền
                    dalPhieuNhapAll.CapNhatThanhTien(ct.IdPhieuNhap);

                    return true;
                }
                else
                {
                    throw new Exception("Không tìm thấy chi tiết phiếu nhập để sửa.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi sửa chi tiết phiếu nhập: " + ex.Message);
            }
        }

        public void XoaChiTiet(int idChiTiet, int idPhieuNhap)
        {
            try
            {
                var chiTiet = da.Db.ChiTietPhieuNhaps.FirstOrDefault(c => c.id == idChiTiet);
                if (chiTiet == null)
                {
                    throw new Exception("Không tìm thấy chi tiết phiếu nhập để xóa.");
                }

                da.Db.ChiTietPhieuNhaps.DeleteOnSubmit(chiTiet);
                da.Db.SubmitChanges();

                // ✅ Cập nhật lại thành tiền
                dalPhieuNhapAll.CapNhatThanhTien(idPhieuNhap);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa chi tiết phiếu nhập: " + ex.Message);
            }
        }
    }
}
