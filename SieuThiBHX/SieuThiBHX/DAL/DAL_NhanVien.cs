using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_NhanVien
    {
        DatabaseAccess da = new DatabaseAccess();
        public IQueryable LayDSNhanVien()
        {
            IQueryable queryable = from nv in da.Db.NhanViens
                                   select new
                                   {
                                       nv.id,
                                       nv.MaNhanVien,
                                       nv.TenNhanVien,
                                       nv.SoDienThoai,
                                       nv.DiaChi,
                                       nv.idLoaiNhanVien,
                                       nv.idTaiKhoan
                                   };
            return queryable;
        }
        public bool AddNV(DTO_NhanVien nhanVien)
        {
            try
            {
                // Checked nhanVien saved in db NhanVien?
                var query = (from nv in da.Db.NhanViens
                             where nv.MaNhanVien == nhanVien.MaNV
                             select nv).FirstOrDefault();

                if (query == null)
                {
                    // Added new record nhanvien in db NhanVien
                    da.Db.NhanViens.InsertOnSubmit(new NhanVien
                    {
                        MaNhanVien = nhanVien.MaNV,
                        TenNhanVien = nhanVien.TenNV,
                        SoDienThoai = nhanVien.SoDT1,
                        DiaChi = nhanVien.DiaChi,
                        idLoaiNhanVien = nhanVien.IdLNV,
                        idTaiKhoan = nhanVien.IdTK,

                    });

                    // Saved db
                    da.Db.SubmitChanges();
                    return true;


                }

            }
            catch (Exception ex)
            {
                // Messaged
                throw;
                return false;
            }
            return false;
        }

        // Update nhanVien
        public bool UpdateNV(DTO_NhanVien nhanVien)
        {
            try
            {
                string nameNV = string.Empty;

                if (nhanVien != null)
                {
                    NhanVien nv_update = da.Db.NhanViens.Single(nv => nv.id == nhanVien.Id);

                    nv_update.MaNhanVien = nhanVien.MaNV;
                    nv_update.TenNhanVien = nhanVien.TenNV;
                    nv_update.SoDienThoai = nhanVien.SoDT1;
                    nv_update.DiaChi = nhanVien.DiaChi;
                    nv_update.idLoaiNhanVien = nhanVien.IdLNV;
                    nv_update.idTaiKhoan = nhanVien.IdTK;

                    // Saved db
                    da.Db.SubmitChanges();
                    nameNV = nv_update.TenNhanVien;
                    return true;
                }

            }
            catch (Exception ex)
            {
                // Messaged
                throw;
                return false;
            }
            return false;
        }

        // Delete nhanVien
        public bool DeleteNV(int id)
        {
            try
            {
                // Initialize Variables
                string nameNV = string.Empty;

                // Checked id nhanvien is saved in db NhanVien
                var query = (from nv in da.Db.NhanViens
                             where nv.id == id
                             select nv).Count();

                if (query == 1)
                {
                    // Init NhanVien
                    NhanVien nv_update = da.Db.NhanViens.Single(nv => nv.id == id);

                    // Saved db
                    da.Db.NhanViens.DeleteOnSubmit(nv_update);
                    da.Db.SubmitChanges();
                    nameNV = nv_update.TenNhanVien;

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

        public bool AddNV2(DTO_NhanVien nhanVien)
        {
            try
            {
                // Checked nhanVien saved in db NhanVien?
                var query = (from nv in da.Db.NhanViens
                             where nv.MaNhanVien == nhanVien.MaNV
                             select nv).FirstOrDefault();

                if (query == null)
                {
                    // Get max(id) in table NhanVien
                    var query2 = da.Db.NhanViens.OrderByDescending(nv => nv.id).FirstOrDefault();

                    // Get string MaNhanVien
                    string maNV = string.Empty;
                    switch (nhanVien.IdLNV)
                    {
                        case 1:
                            maNV = "QL";
                            break;
                        case 2:
                            maNV = "NV";
                            break;
                        case 3:
                            maNV = "GD";
                            break;
                        case 4:
                            maNV = "TP";
                            break;
                        case 5:
                            maNV = "PP";
                            break;
                        case 6:
                            maNV = "CV";
                            break;
                        case 7:
                            maNV = "TTS";
                            break;
                        case 8:
                            maNV = "NVKD";
                            break;
                        case 9:
                            maNV = "KS";
                            break;
                        case 10:
                            maNV = "HTKT";
                            break;
                        default:
                            maNV = "NV";
                            break;
                    }

                    // Added new record nhanvien in db NhanVien
                    da.Db.NhanViens.InsertOnSubmit(new NhanVien
                    {
                        MaNhanVien = query2.id < 10 ? maNV + "00" + (query2.id + 1) : maNV + "0" + (query2.id + 1),
                        TenNhanVien = nhanVien.TenNV,
                        SoDienThoai = nhanVien.SoDT1,
                        DiaChi = nhanVien.DiaChi,
                        idLoaiNhanVien = nhanVien.IdLNV,
                        idTaiKhoan = nhanVien.IdTK,
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

        public bool UpdateNV2(DTO_NhanVien nhanVien)
        {
            try
            {
                // Initialize Variables
                string nameNV = string.Empty;

                // Checked nhanVien != null
                if (nhanVien != null)
                {
                    // Init NhanVien
                    NhanVien nv_update = da.Db.NhanViens.Single(nv => nv.id == nhanVien.Id);

                    // Get string MaNhanVien
                    string maNV = string.Empty;
                    switch (nhanVien.IdLNV)
                    {
                        case 1:
                            maNV = "QL";
                            break;
                        case 2:
                            maNV = "NV";
                            break;
                        case 3:
                            maNV = "GD";
                            break;
                        case 4:
                            maNV = "TP";
                            break;
                        case 5:
                            maNV = "PP";
                            break;
                        case 6:
                            maNV = "CV";
                            break;
                        case 7:
                            maNV = "TTS";
                            break;
                        case 8:
                            maNV = "NVKD";
                            break;
                        case 9:
                            maNV = "KS";
                            break;
                        case 10:
                            maNV = "HTKT";
                            break;
                        default:
                            maNV = "NV";
                            break;
                    }

                    // Updated nv_update
                    nv_update.MaNhanVien = nv_update.id < 10 ? maNV + "00" + (nv_update.id) : maNV + "0" + (nv_update.id);
                    nv_update.TenNhanVien = nhanVien.TenNV;
                    nv_update.SoDienThoai = nhanVien.SoDT1;
                    nv_update.DiaChi = nhanVien.DiaChi;
                    nv_update.idLoaiNhanVien = nhanVien.IdLNV;
                    nv_update.idTaiKhoan = nhanVien.IdTK;

                    // Saved db
                    da.Db.SubmitChanges();
                    nameNV = nv_update.TenNhanVien;
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
        public int GetMaxIdNV()
        {
            var query = da.Db.NhanViens.OrderByDescending(nv => nv.id).FirstOrDefault();

            return (int)query.id;
        }

        public IQueryable SearchNvByMaNV(string maNV)
        {
            var query = from nv in da.Db.NhanViens
                        where nv.MaNhanVien.ToLower().Contains(maNV.ToLower())
                        select new
                        {
                            nv.id,
                            nv.MaNhanVien,
                            nv.TenNhanVien,
                            nv.SoDienThoai,
                            nv.DiaChi
                        };

            return query;
        }

        public IQueryable SearchNvBytenNV(string tenNV)
        {
            var query = from nv in da.Db.NhanViens
                        where nv.TenNhanVien.ToLower().Contains(tenNV.ToLower())
                        select new
                        {
                            nv.id,
                            nv.MaNhanVien,
                            nv.TenNhanVien,
                            nv.SoDienThoai,
                            nv.DiaChi
                        };

            return query;
        }

        public IQueryable GetListNV2()
        {
            IQueryable query = from nv in da.Db.NhanViens
                               select new
                               {
                                   nv.id,
                                   nv.MaNhanVien,
                                   nv.TenNhanVien,
                                   nv.SoDienThoai,
                                   nv.DiaChi,
                               };
            return query;
        }

        public DTO_NhanVien getNhanVien(int idTaiKhoan)
        {
            var nhanvien = da.Db.NhanViens.FirstOrDefault(nv => nv.id == idTaiKhoan);

            if (nhanvien == null)
                return null; 

            DTO_NhanVien dto_NhanVien = new DTO_NhanVien
            {
                Id = nhanvien.id,
                TenNV = nhanvien.TenNhanVien,
                SoDT1 = nhanvien.SoDienThoai,
                DiaChi = nhanvien.DiaChi,
                IdLNV = (int)nhanvien.idLoaiNhanVien,
                IdTK = (int)nhanvien.idTaiKhoan 
            };

            return dto_NhanVien;
        }

    }
}
