using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_CaLam
    {
        private DAL_CaLam dal_cl = new DAL_CaLam();

        //lay danh sach calam
        public IQueryable LayDSCaLam()
        {
            return dal_cl.LayDSCaLam();
        }

        //them ca lam
        public bool ThemCaLam(DTO.DTO_CaLam caLam)
        {
            return dal_cl.ThemCaLam(caLam);
        }
        public bool XoaCaLam(int id)
        {
            return dal_cl.XoaCaLam(id);
        }
    }
}
