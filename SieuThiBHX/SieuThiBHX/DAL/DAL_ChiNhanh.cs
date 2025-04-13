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
        public void themChiNhanh(DTO_ChiNhanh chiNhanh)
        {
            try
            {
                var data = da.Db.ChiNhanhs.SingleOrDefault(cn => cn.MaChiNhanh == chiNhanh.MaChiNhanh);
                if (data == null)
                {
                    if (chiNhanh.SoDienThoai.Length < 10 || chiNhanh.SoDienThoai.Length > 11)
                    {
                        throw new Exception("Số diên thoại không hợp lệ!");
                    }
                    if (chiNhanh.MaChiNhanh.Length > 30)
                    {
                        throw new Exception("Mã chi nhánh không quá 30 kí tự!");
                    }
                    if (chiNhanh.TenChiNhanh.Length > 50)
                    {
                        throw new Exception("Tên chi nhánh không quá 50 kí tự!");
                    }
                    if (chiNhanh.DiaChi.Length > 50)
                    {
                        throw new Exception("Địa chỉ nhánh không quá 50 kí tự!");
                    }
                    ChiNhanh chi = new ChiNhanh();
                    chi.MaChiNhanh = chiNhanh.MaChiNhanh;
                    chi.TenChiNhanh = chiNhanh.TenChiNhanh;
                    chi.SoDienThoai = chiNhanh.SoDienThoai;
                    chi.DiaChi = chiNhanh.DiaChi;

                    da.Db.ChiNhanhs.InsertOnSubmit(chi);
                    da.Db.SubmitChanges();
                }
                else
                {
                    throw new Exception("Thêm thất bại! Mã chi nhánh đã tồn tại");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("có lỗi xảy ra: " + ex.Message);
            }

        }
        //xóa chi nhánh
        public void xoaChiNhanh(int id)
        {
            try
            {
                var data = da.Db.ChiNhanhs.FirstOrDefault(dt => dt.id == id);
                if (data == null)
                {
                    throw new Exception("Không tìm thấy chi nhánh cần xóa!");
                }

                da.Db.ChiNhanhs.DeleteOnSubmit(data);
                da.Db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra: " + ex.Message);
            }
        }


        //sửa chi nhánh
        public void suaChiNhanh(DTO_ChiNhanh chiNhanh)
        {
            try
            {
                if (chiNhanh.SoDienThoai.Length < 10 || chiNhanh.SoDienThoai.Length > 11)
                {
                    throw new Exception("Số điện thoại không hợp lệ!");
                }
                if (chiNhanh.MaChiNhanh.Length > 30)
                {
                    throw new Exception("Mã chi nhánh không quá 30 kí tự!");
                }
                if (chiNhanh.TenChiNhanh.Length > 50)
                {
                    throw new Exception("Tên chi nhánh không quá 50 kí tự!");
                }
                if (chiNhanh.DiaChi.Length > 50)
                {
                    throw new Exception("Địa chỉ không quá 50 kí tự!");
                }

                var data = da.Db.ChiNhanhs.FirstOrDefault(dt => dt.id == chiNhanh.Id);
                if (data == null)
                {
                    throw new Exception("Không tìm thấy chi nhánh cần sửa!");
                }

                data.MaChiNhanh = chiNhanh.MaChiNhanh;
                data.TenChiNhanh = chiNhanh.TenChiNhanh;
                data.SoDienThoai = chiNhanh.SoDienThoai;
                data.DiaChi = chiNhanh.DiaChi;
                da.Db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra: " + ex.Message);
            }
        }
       


    }
}
