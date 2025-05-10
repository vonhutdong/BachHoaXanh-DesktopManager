using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_HoaDon
    {
        DAL_HoaDon dal_hd = new DAL_HoaDon();

        public IQueryable GetListHD()
        {
            return dal_hd.GetListHD();
        }

        public bool DelHD(int id)
        {
            return dal_hd.DeleteHD(id);
        }

        public bool updateHD(DTO_HoaDon dto_hd)
        {
            return dal_hd.UpdateHD(dto_hd);
        }
        public IQueryable TimKiemHD(string tuKhoa)
        {
            return dal_hd.TimKiemHD(tuKhoa);
        }

    }
}
