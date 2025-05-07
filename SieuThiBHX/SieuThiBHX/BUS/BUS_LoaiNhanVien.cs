using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_LoaiNhanVien
    {
        DAL_LoaiNhanVien dal_lnv = new DAL_LoaiNhanVien();
        public IQueryable GetListLNV()
        {
            return dal_lnv.GetListLNV();
        }
        public IQueryable GetListAllLNVByTen()
        {
            return dal_lnv.GetListAllLNVByTen();
        }

        public IQueryable GetListOneLNVByTen(int id)
        {
            return dal_lnv.GetListOneLNVByTen(id);
        }

        public void AddLNV(DTO_LoaiNhanVien loaiNhanVien)
        {
            dal_lnv.AddLNV(loaiNhanVien);
        }

        public void UpdateLNV(DTO_LoaiNhanVien loaiNhanVien)
        {
            dal_lnv.UpdateLNV(loaiNhanVien);
        }

        public bool DelLNV(int id)
        {
            return dal_lnv.DelLNV(id);
        }

        public bool AddLNV2(DTO_LoaiNhanVien loaiNhanVien)
        {
            return dal_lnv.AddLNV2(loaiNhanVien);
        }

        public bool UpdateLNV2(DTO_LoaiNhanVien loaiNhanVien)
        {
           return dal_lnv.UpdateLNV2(loaiNhanVien);
        }

        public int GetMaxIdLNV()
        {
            return dal_lnv.GetMaxIdLNV();
        }
    }
}
