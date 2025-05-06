using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_BangLuong
    {
        DAL_BangLuong dal_bangluong = new DAL_BangLuong();
        public IQueryable LayDSBangLuong()
        {
            return dal_bangluong.LayDSBangLuong();
        }
        public IQueryable LayDSBangLuong(int idNhanVien)
        {
            return dal_bangluong.LayDSBangLuong(idNhanVien);
        }
        public IQueryable DSNhanVien()
        {
            return dal_bangluong.DSNhanVien();
        }
        public void ThemBangLuong(DTO_BangLuong bangluong)
        {
            dal_bangluong.ThemBangLuong(bangluong);
        }
    }
}
