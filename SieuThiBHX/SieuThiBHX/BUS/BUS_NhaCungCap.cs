using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_NhaCungCap
    {
        // Fields
        private DAL_NhaCungCap dal_ncc = new DAL_NhaCungCap();

        //Method
        // LayDSNCC()
        public IQueryable LayDSNCC()
        {
            return dal_ncc.LayDSNCC();
        }

        // ThemNCC()
        public void ThemNCC(DTO_NhaCungCap ncc)
        {
             dal_ncc.themNCC(ncc);
        }

        // XoaNCC()
        public void XoaNCC(int id)
        {
            dal_ncc.xoaNCC(id);
        }

        // SuaNCC()
        public void SuaNCC(DTO_NhaCungCap ncc)
        {
            dal_ncc.suaNCC(ncc);
        }
    }
}
