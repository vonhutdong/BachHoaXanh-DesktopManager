using System;
using System.Linq;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_ChiTietPhieuNhap
    {
        private DAL_ChiTietPhieuNhap dalCTPN = new DAL_ChiTietPhieuNhap();

        public IQueryable LayDSCTPN()
        {
            return dalCTPN.LayDSChiTietPhieuNhap();
        }

        public IQueryable LayDSSP()
        {
            return dalCTPN.LayDSSP();
        }

        public bool ThemChiTiet(DTO_ChiTietPhieuNhap ct)
        {
            return dalCTPN.ThemChiTiet(ct);
        }

        public bool SuaChiTiet(DTO_ChiTietPhieuNhap ct)
        {
            return dalCTPN.SuaChiTiet(ct);
        }

        public void XoaChiTiet(int idChiTiet, int idPhieuNhap)
        {
            dalCTPN.XoaChiTiet(idChiTiet, idPhieuNhap);
        }
    }
}
