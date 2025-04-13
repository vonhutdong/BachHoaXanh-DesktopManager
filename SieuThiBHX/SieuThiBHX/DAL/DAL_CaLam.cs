using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_CaLam
    {
        private DatabaseAccess da = new DatabaseAccess();
        public DatabaseAccess Da { get => da; set => da = value; }

        public IQueryable LayDSCaLam()
        {
            IQueryable temp = from cl in Da.Db.CaLams
                              select new
                              {
                                  cl.id,
                                  cl.MaCaLam,
                                  cl.TenCaLam,
                                  cl.GioBatDau,
                                  cl.GioKetThuc
                              };
            return temp;
        }

        public bool ThemCaLam(DTO_CaLam caLam)
        {
            try
            {
                if (caLam != null)
                {
                    // Check if the shift already exists in the database
                    var query2 = da.Db.CaLams.OrderByDescending(x => x.id).FirstOrDefault();
                    da.Db.CaLams.InsertOnSubmit(new CaLam
                    {
                        MaCaLam = query2 != null && query2.id < 10 ? "CL0" + (query2.id + 1) : "CL" + (query2?.id + 1),
                        TenCaLam = caLam.TenCaLam,
                        GioBatDau = caLam.GioBatDau,
                        GioKetThuc = caLam.GioKetThuc
                    });
                    da.Db.SubmitChanges(); // Commit to the database
                    return true;
                }
            }
            catch (Exception)
            {
                // Log or handle the exception as needed
                return false;
            }
            return false;
        }
    }
}
