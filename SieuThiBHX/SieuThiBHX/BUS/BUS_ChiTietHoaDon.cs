using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_ChiTietHoaDon
    {
        DAL_ChiTietHoaDon dal_CTHD = new DAL_ChiTietHoaDon();

        public IQueryable GetListCTHD()
        {
            return dal_CTHD.GetListCTHD();
        }

        public void AddCTHD(DTO_ChiTietHoaDon chiTietHoaDon)
        {
            dal_CTHD.AddCTHD(chiTietHoaDon);
        }
        public IQueryable GetListCTHDTheoMaHD(int idMaHD)
        {
            return dal_CTHD.GetListCTHDTheoMaHD(idMaHD);
        }
        public void AddCTHD2(DTO_ChiTietHoaDon chiTietHoaDon)
        {
            dal_CTHD.AddCTHD2(chiTietHoaDon);
        }
        public int GetTotalCashByIdHd(int idHd)
        {
            return dal_CTHD.GetTotalCashByIdHd(idHd);
        }
    }
}
