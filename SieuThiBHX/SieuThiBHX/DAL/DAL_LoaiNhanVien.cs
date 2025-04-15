using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_LoaiNhanVien
    {
        private DatabaseAccess da = new DatabaseAccess();
        
        public IQueryable GetListLNV()
        {
            IQueryable query = from lnv in da.Db.LoaiNhanViens
                               select new
                               {
                                   lnv.id,
                                   lnv.MaLoaiNhanVien,
                                   lnv.TenLoaiNhanVien,
                                   
                               };
            return query;
        }

        public IQueryable GetListAllLNVByTen()
        {
            IQueryable query = from lnv in da.Db.LoaiNhanViens
                               select new
                               {
                                   Id = lnv.id,
                                   TenLoaiNhanVien = lnv.TenLoaiNhanVien
                               };
            return query;
        }

        public IQueryable GetListOneLNVByTen(int id)
        {
            IQueryable query = from lnv in da.Db.LoaiNhanViens
                               where lnv.id == id
                               select new
                               {
                                   Id = lnv.id,
                                   TenLoaiNhanVien = lnv.TenLoaiNhanVien
                               };
            return query;
        }

        public bool AddLNV(DTO_LoaiNhanVien loaiNhanVien)
        {
            try
            {
                // Checked new record loainhanvien saved in db LoaiNhanVien
                var query = (from lnv in da.Db.LoaiNhanViens
                             where lnv.MaLoaiNhanVien == loaiNhanVien.MaLoaiNV
                             select lnv).FirstOrDefault();

                // Added new record loainhanvien
                if (query == null)
                {
                    da.Db.LoaiNhanViens.InsertOnSubmit(new LoaiNhanVien
                    {
                        MaLoaiNhanVien = loaiNhanVien.MaLoaiNV,
                        TenLoaiNhanVien = loaiNhanVien.TenLoaiNV,
                        
                    });

                    // Saved db
                    da.Db.SubmitChanges();
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                throw;
                return false;
            }
            return false;
        }

        public bool UpdateLNV(DTO_LoaiNhanVien loaiNhanVien)
        {
            try
            {
                // Initialize Variables
                string nameLNV = string.Empty;

                // Checked loainhanvien != null
                if (loaiNhanVien != null)
                {
                    // Init LoaiNhanVien
                    LoaiNhanVien lnv_update = da.Db.LoaiNhanViens.Single(lnv => lnv.id == loaiNhanVien.Id);

                    // Updated lnv_update
                    lnv_update.MaLoaiNhanVien = loaiNhanVien.MaLoaiNV;
                    lnv_update.TenLoaiNhanVien = loaiNhanVien.TenLoaiNV;
                    

                    // Saved db
                    da.Db.SubmitChanges();
                    nameLNV = loaiNhanVien.TenLoaiNV;
                    return true;
                    
                }
                
            }
            catch (Exception ex)
            {

                throw;
                return false;
            }
            return false;
        }

        public bool DelLNV(int id)
        {
            try
            {
                // Initialize Variables
                string nameLNV = string.Empty;

                // Checked id lnv saved in db lnv?
                var query = (from lnv in da.Db.LoaiNhanViens
                             where lnv.id == id
                             select lnv).Count();

                if (query == 1)
                {
                    // Init LoaiNhanVien
                    LoaiNhanVien lnv_update = da.Db.LoaiNhanViens.Single(lnv => lnv.id == id);

                    da.Db.LoaiNhanViens.DeleteOnSubmit(lnv_update);
                    // Saved db
                    da.Db.SubmitChanges();
                    //nameLNV = lnv_update.TenLoaiNhanVien;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
                return false;
            }
            return false;
        }

        //AddLNV2 not have maLNV
        public bool AddLNV2(DTO_LoaiNhanVien loaiNhanVien)
        {
            try
            {
                // Checked new record loainhanvien saved in db LoaiNhanVien
                var query = (from lnv in da.Db.LoaiNhanViens
                             where lnv.MaLoaiNhanVien == loaiNhanVien.MaLoaiNV
                             select lnv).FirstOrDefault();

                // Added new record loainhanvien
                if (query == null)
                {
                    // Checked max(id) record in table LoaiNhanVien
                    var query2 = da.Db.LoaiNhanViens.OrderByDescending(lnv => lnv.id).FirstOrDefault();

                    da.Db.LoaiNhanViens.InsertOnSubmit(new LoaiNhanVien
                    {
                        MaLoaiNhanVien = query2.id < 10 ? "LNV00" + (query2.id + 1) : "LNV0" + (query2.id + 1),
                        TenLoaiNhanVien = loaiNhanVien.TenLoaiNV,

                    });

                    // Saved db
                    da.Db.SubmitChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
                return false;
            }
            return false;
        }

        //public bool AddLNV2(DTO_LoaiNhanVien lnv)
        //{
        //    try
        //    {
        //        LoaiNhanVien newLNV = new LoaiNhanVien
        //        {
        //            MaLoaiNhanVien = lnv.MaLoaiNV,
        //            TenLoaiNhanVien = lnv.TenLoaiNV
        //        };

        //        da.Db.LoaiNhanViens.InsertOnSubmit(newLNV);
        //        da.Db.SubmitChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        // UpdateLNV2 not have maLNV
        public bool UpdateLNV2(DTO_LoaiNhanVien loaiNhanVien)
        {
            if (loaiNhanVien == null) return false;

            try
            {
                var lnv = da.Db.LoaiNhanViens.SingleOrDefault(x => x.id == loaiNhanVien.Id);

                if (lnv != null)
                {
                    lnv.TenLoaiNhanVien = loaiNhanVien.TenLoaiNV;
                    da.Db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật loại nhân viên: " + ex.Message);
            }

            return false;
        }



        // Get max(id) in table LoaiNhanVien
        public int GetMaxIdLNV()
        {
            var query = da.Db.LoaiNhanViens.OrderByDescending(lnv => lnv.id).FirstOrDefault();

            return (int)query.id;
        }
    }
}

