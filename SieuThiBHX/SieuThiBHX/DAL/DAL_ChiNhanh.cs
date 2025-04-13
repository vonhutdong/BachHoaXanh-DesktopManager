using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{

    public class DAL_ChiNhanh
    {
        private DatabaseAccess da = new DatabaseAccess();
        public DatabaseAccess Da { get => da; set => da = value; }

        public IQueryable LayDSChiNhanh()
        {
            IQueryable temp = from cn in Da.Db.ChiNhanhs
                              select new
                              {
                                  cn.id,
                                  cn.MaChiNhanh,
                                  cn.TenChiNhanh,
                                  cn.DiaChi,
                                  cn.SoDienThoai

                              };
            return temp;
        }

    }
}
