using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_SanPham
    {
        public IQueryable LoadNCC()
        {
            return dal_sp.LoadNhaCungCap();
        }
        //dal sản phẩm
        DAL_SanPham dal_sp = new DAL_SanPham();
        public IQueryable LoadDSSanPham()
        {
            return dal_sp.LayDSSanPham();
        }
        public void ThemSanPham(DTO_SanPham sanpham)
        {
            dal_sp.ThemSanPham(sanpham);
        }
        //xoa san pham
        public void XoaSanPham(int id)
        {
            dal_sp.XoaSanPham(id);
        }
        public void SuaSanPham(DTO_SanPham sanPham)
        {
            dal_sp.SuaSanPham(sanPham);
        }
        public List<DTO_SanPhamKhoHang> ListSanPham()
        {
            return dal_sp.ListSanPham();
        }
        //public List<DTO_SanPhamKhoHang> ListTimKiemSanPhamBangMa(string tukhoa)
        //{
        //    return dal_sp.ListTimKiemSanPhamBangMa(tukhoa);
        //}


        public IQueryable LocSpTheoTen(string key)
        {
            return dal_sp.LocSpTheoTen(key);
        }

        public int GetSoLuongSpTrongKho(int id)
        {
            return dal_sp.GetSoLuongSpTrongKho(id);
        }

        public IQueryable GetListSP()
        {
            return dal_sp.GetListSP();
        }

        public IQueryable SearchSpByTenSP(string tenSp)
        {
            return dal_sp.SearchSpByTenSP(tenSp);
        }

        public IQueryable SearchSpByDVT(string donViTinh)
        {
            return dal_sp.SearchSpByDVT(donViTinh);
        }
    }
}
