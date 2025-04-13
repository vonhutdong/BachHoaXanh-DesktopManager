using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Security.Claims;
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

        public bool XoaCaLam(int id)
        {
            try
            {
                // Tìm ca làm theo ID
                var data = da.Db.CaLams.FirstOrDefault(dt => dt.id == id);

                // Kiểm tra nếu không tìm thấy
                if (data == null)
                {
                    return false;
                }

                // Xóa và lưu thay đổi
                da.Db.CaLams.DeleteOnSubmit(data);
                da.Db.SubmitChanges();

                // Xóa thành công
                return true;
            }
            catch (Exception ex)
            {
                // Có thể log lỗi ở đây nếu muốn: Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool SuaCaLam(DTO_CaLam caLam)
        {
            try
            {
                //kiểm tra mã ca lam có tồn tại chưa
                var kh = da.Db.CaLams.FirstOrDefault(dt => dt.id == caLam.Id);
                if (kh != null)
                {
                    //kh.MaCaLam = caLam.MaCaLam;
                    kh.TenCaLam = caLam.TenCaLam;
                    kh.GioBatDau = caLam.GioBatDau;
                    kh.GioKetThuc = caLam.GioKetThuc;
                    da.Db.SubmitChanges();

                    // Thông báo
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return false;
        }
            


    }
}
