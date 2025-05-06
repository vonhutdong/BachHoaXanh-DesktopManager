using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_KhachHang
    {
        private DAL_KhachHang dal_kh = new DAL_KhachHang();

        public IQueryable LayDSKH()
        {
            return dal_kh.LayDSKH();
        }
        public DTO_KhachHang LayKhachHang_SDT(string sodienthoai)
        {
            return dal_kh.LayKhachHang_SDT(sodienthoai);
        }
        public bool ThemKhachHang(DTO_KhachHang khachHang)
        {
            return dal_kh.ThemKH(khachHang);
        }
        public bool XoaKH(int id)
        {
            return dal_kh.XoaKH(id);
        }

        public bool SuaKH(DTO_KhachHang khachHang)
        {
            return dal_kh.SuaKH(khachHang);
        }
        public IQueryable<DTO_KhachHang> TimKiemTheoTenHoacSDT(string tukhoa)
        {
            return dal_kh.TimKiemTheoTenHoacSDT(tukhoa);
        }

    }
}
