using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_ChiNhanh
    {
        private DAL_ChiNhanh DAL_ChiNhanh = new DAL_ChiNhanh();

        public IQueryable LayDSChiNhanh()
        {
            return DAL_ChiNhanh.LayDSChiNhanh();
        }
    }
}
