using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_ChiNhanh
    {
        private DAL_ChiNhanh dal_chiNhanh = new DAL_ChiNhanh();

        public IQueryable LayDSChiNhanh()
        {
            return dal_chiNhanh.LayDSChiNhanh();
        }
        public void themChiNhanh(DTO_ChiNhanh chiNhanh)
        {
            dal_chiNhanh.themChiNhanh(chiNhanh);
        }
        //xóa chi nhánh
        public void xoaChiNhanh(int id)
        {
            dal_chiNhanh.xoaChiNhanh(id);
        }
        public void suaChinhNhanh(DTO_ChiNhanh chiNhanh)
        {
            dal_chiNhanh.suaChiNhanh(chiNhanh);
        }

    }
}
