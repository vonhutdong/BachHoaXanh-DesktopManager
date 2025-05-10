using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dal_nv = new DAL_NhanVien();

        public IQueryable LayDSNhanVien()
        {
            return dal_nv.LayDSNhanVien();
        }
        public bool AddNV(DTO.DTO_NhanVien nhanVien)
        {
            return dal_nv.AddNV(nhanVien);
        }

        public bool UpdateNV(DTO.DTO_NhanVien nhanVien)
        {
            return dal_nv.UpdateNV(nhanVien);
        }
        public bool XoaNV(int id)
        {
            return dal_nv.DeleteNV(id);
        }
        public bool AddNV2(DTO_NhanVien nv)
        {
            return dal_nv.AddNV2(nv);
        }

        public bool UpdateNV2(DTO_NhanVien nv)
        {
            return dal_nv.UpdateNV2(nv);
        }

        public int GetMaxIdNV()
        {
            return dal_nv.GetMaxIdNV();
        }

        public IQueryable SearchNvByMaNV(string maNV)
        {
            return dal_nv.SearchNvByMaNV(maNV);
        }

        public IQueryable SearchNvBytenNV(string tenNV)
        {
            return dal_nv.SearchNvBytenNV(tenNV);
        }

        public IQueryable GetListNV2()
        {
            return dal_nv.GetListNV2();
        }
        public DTO_NhanVien getNhanVien(int idTaiKhoan)
        {
            return dal_nv.getNhanVien(idTaiKhoan);
        }
    }
}
