using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_KhoHang
    {
        //dal
        DAL_KhoHang dal_kh = new DAL_KhoHang();
        //load kho hàng
        public IQueryable LoadKhoHang()
        {
            return dal_kh.LoadKhoHang();
        }
        public void SuaKhoHang(DTO_KhoHang khohang)
        {
            dal_kh.SuaKhoHang(khohang);
        }
    }
}
