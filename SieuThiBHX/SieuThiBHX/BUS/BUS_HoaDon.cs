using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_HoaDon
    {
        DAL_HoaDon dal_hd = new DAL_HoaDon();

        public IQueryable GetListHD()
        {
            return dal_hd.GetListHD();
        }
    }
}
