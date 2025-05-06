using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_SanPham
    {
        private DatabaseAccess da = new DatabaseAccess();
        
        public IQueryable LoadNhaCungCap()
        {
            return from sl in da.Db.NhaCungCaps
                   select sl;
        }

        public IQueryable LayDSSanPham()
        {
            try
            {
                return from sp in da.Db.SanPhams
                       select sp;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm: " + ex.Message);
            }
        }

        public List<DTO_SanPhamKhoHang> ListSanPham()
        {
            try
            {
                return (from sp in da.Db.SanPhams
                        join kho in da.Db.KhoHangs
                        on sp.id equals kho.idSanPham
                        select new DTO_SanPhamKhoHang
                        {
                            Id = sp.id,
                            MaSanPham = sp.maSanPham,
                            TenSanPham = sp.tenSanPham,
                            IdLoaiHang = (int)sp.idLoaiHang,
                            GiaBan = (double)sp.donGia,
                            SoLuong = (int)kho.soLuong,
                            AnhSanPham = sp.anhSanPham
                        }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra: " + ex.Message);
            }
        }

        public void ThemSanPham(DTO_SanPham sanpham)
        {
            try
            {
                //kiểm tra mã sản phẩm có tồn tại chưa
                var data = da.Db.SanPhams.FirstOrDefault(dt => dt.maSanPham == sanpham.MaSanPham);
                if (data == null)
                {
                    //Sản phẩm được thêm
                    SanPham sp = new SanPham();
                    sp.maSanPham = sanpham.MaSanPham;
                    sp.tenSanPham = sanpham.TenSanPham;
                    sp.donViTinh = sanpham.DonViTinh;
                    sp.donGia = sanpham.DonGia;
                    sp.ngaySanXuat = sanpham.NgaySanXuat;
                    sp.hanSuDung = sanpham.HanSuDung;
                    sp.idLoaiHang = sanpham.IdLoaiHang;
                    sp.idNhaCungCap = sanpham.IdNhaCungCap;
                    sp.anhSanPham = sanpham.AnhSanPham;
                    da.Db.SanPhams.InsertOnSubmit(sp);
                    da.Db.SubmitChanges();
                }
                else
                {
                    //quăng lỗi
                    throw new Exception("Mã sản phẩm đã tồn tại!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra: " + ex.Message);
            }
        }

        public void XoaSanPham(int id)
        {
            try
            {
                //tìm sản phẩm xóa
                var data = da.Db.SanPhams.FirstOrDefault(dt => dt.id == id);
                da.Db.SanPhams.DeleteOnSubmit(data);
                da.Db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra: " + ex.Message);
            }
        }

        public void SuaSanPham(DTO_SanPham sanphamdto)
        {
            try
            {
                //kiểm tra mã loại hàng có tồn tại chưa
                var sp = da.Db.SanPhams.FirstOrDefault(dt => dt.id == sanphamdto.Id);
                if (sp != null)
                {
                    sp.maSanPham = sanphamdto.MaSanPham;
                    sp.tenSanPham = sanphamdto.TenSanPham;
                    sp.donViTinh = sanphamdto.DonViTinh;
                    sp.donGia = sanphamdto.DonGia;
                    sp.ngaySanXuat = sanphamdto.NgaySanXuat;
                    sp.hanSuDung = sanphamdto.HanSuDung;
                    sp.idLoaiHang = sanphamdto.IdLoaiHang;
                    sp.idNhaCungCap = sanphamdto.IdNhaCungCap;
                    sp.anhSanPham = sanphamdto.AnhSanPham;
                    //cập nhật lại
                    da.Db.SubmitChanges();
                }
                else
                {
                    //quăng lỗi
                    throw new Exception("Không tìm thấy!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra: " + ex.Message);
            }

        }

        public IQueryable LocSpTheoTen(string key)
        {
            var query = from sp in da.Db.SanPhams
                        where sp.tenSanPham.ToLower().Contains(key.ToLower())
                        select new
                        {
                            sp.id,
                            sp.maSanPham,
                            sp.tenSanPham,
                            sp.donViTinh,
                            sp.donGia,
                        };

            return query;
        }

        public int GetSoLuongSpTrongKho(int id)
        {
            var query = (from sp in da.Db.SanPhams
                         join kho in da.Db.KhoHangs
                         on sp.id equals kho.idSanPham
                         where sp.id == id
                         select new
                         {
                             Id = sp.id,
                             TenSanPham = sp.tenSanPham,
                             SoLuong = kho.soLuong
                         }).FirstOrDefault();

            return (int)query.SoLuong;
        }

        public IQueryable GetListSP()
        {
            var query = from sp in da.Db.SanPhams
                        join kho in da.Db.KhoHangs
                        on sp.id equals kho.idSanPham
                        select new
                        {
                            sp.id,
                            sp.maSanPham,
                            sp.tenSanPham,
                            sp.donViTinh,
                            sp.donGia,
                            kho.soLuong
                        };

            return query;
        }

        public IQueryable SearchSpByTenSP(string tenSp)
        {
            var query = from sp in da.Db.SanPhams
                        join kho in da.Db.KhoHangs
                        on sp.id equals kho.idSanPham
                        where sp.tenSanPham.ToLower().Contains(tenSp.ToLower())
                        select new
                        {
                            sp.id,
                            sp.maSanPham,
                            sp.tenSanPham,
                            sp.donViTinh,
                            sp.donGia,
                            kho.soLuong
                        };

            return query;
        }

        public IQueryable SearchSpByDVT(string donViTinh)
        {
            var query = from sp in da.Db.SanPhams
                        join kho in da.Db.KhoHangs
                        on sp.id equals kho.idSanPham
                        where sp.donViTinh.ToLower().Contains(donViTinh.ToLower())
                        select new
                        {
                            sp.id,
                            sp.maSanPham,
                            sp.tenSanPham,
                            sp.donViTinh,
                            sp.donGia,
                            kho.soLuong
                        };

            return query;
        }
    }
}
