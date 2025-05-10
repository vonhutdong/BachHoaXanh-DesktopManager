using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_KhuyenMai
    {
        DAL_KhuyenMai dal_km = new DAL_KhuyenMai();

        // Methods
        public IQueryable GetListKM()
        {
            return dal_km.GetListKM();
        }
        // Thêm khuyến mãi
        public void AdddKhuyenMai(DTO_KhuyenMai khuyenMai)
        {
            dal_km.AddKM(khuyenMai);
        }
        public void UpdateKhuyenMai(DTO_KhuyenMai khuyenMai)
        {
            dal_km.UpdateKM(khuyenMai);
        }
        public void DeleteTaiKhoan(int id)
        {
            dal_km.DelKM(id);
        }
        public int getIdKhuyenMai(string maKM)
        {
            return dal_km.getIdKhuyenMai(maKM);
        }
    }
}
