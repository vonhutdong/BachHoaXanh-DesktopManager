using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_LoaiHang
    {
        private DatabaseAccess da = new DatabaseAccess();

        public IQueryable LayDSLH()
        {
            return da.Db.LoaiHangs.Select(lh => new { lh.id, lh.maLoaiHang, lh.tenLoaiHang });
        }
    }
}
