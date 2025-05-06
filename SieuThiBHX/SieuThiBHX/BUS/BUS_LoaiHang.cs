using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_LoaiHang
    {
        DAL_LoaiHang dal_lh = new DAL_LoaiHang();

        public IQueryable LayDSLH()
        {
            return dal_lh.LayDSLH();
        }
        public void ThemLoaiHang(DTO_LoaiHang dto_lh)
        {
            dal_lh.ThemLoaiHang(dto_lh);
        }
        //xóa loại hàng
        public void XoaLoaiHang(int id)
        {
            dal_lh.XoaLoaiHang(id);
        }
        //sửa loại hàng
        public void SuaLoaHang(DTO_LoaiHang dto_lh)
        {
            dal_lh.SuaLoaiHang(dto_lh);
        }
    }
}
