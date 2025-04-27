using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_LoaiHang
    {
        DAL_LoaiHang dal_lh = new DAL_LoaiHang();

        public IQueryable LayDSLH()
        {
            return dal_lh.LayDSLH();
        }
    }
}
