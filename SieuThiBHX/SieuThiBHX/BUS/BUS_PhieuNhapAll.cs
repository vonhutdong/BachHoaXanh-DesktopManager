using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_PhieuNhapAll
    {
        private DAL_PhieuNhapAll dal_pnAll = new DAL_PhieuNhapAll();
        public IQueryable LayDSPhieuNhap()
        {
            return dal_pnAll.LayDSPhieuNhap();
        }
        public IQueryable LayDSNhanVien()
        {
            return dal_pnAll.LayDSNhanVien();
        }
        public bool ThemPhieuNhap(DTO_PhieuNhap pn)
        {
            return dal_pnAll.ThemPhieuNhap(pn);
        }

        // XoaPhieuNhap()
        public void XoaPhieuNhap(int id)
        {
            dal_pnAll.XoaPhieuNhap(id);
        }

        // SuaNCC()
        public bool SuaPN(DTO_PhieuNhap pn)
        {
            return dal_pnAll.SuaPhieuNhap(pn);
        }
        public void CapNhatThanhTien(int idPhieuNhap)
        {
            dal_pnAll.CapNhatThanhTien(idPhieuNhap);
        }
        public DataTable LayDSPhieuNhapVaChiTiet_BaoCao()
        {
            return dal_pnAll.LayDSPhieuNhapVaChiTiet_BaoCao();
        }
    }
}
