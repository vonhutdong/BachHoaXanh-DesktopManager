using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_LoaiHang
    {
        private DatabaseAccess da = new DatabaseAccess();

<<<<<<< HEAD
        public IQueryable<DTO_LoaiHang> LayDSLH()
        {
            return da.Db.LoaiHangs.Select(lh => new DTO_LoaiHang
            {
                Id = lh.id,
                MaLoaiHang = lh.maLoaiHang,
                TenLoaiHang = lh.tenLoaiHang
            });
=======
        public IQueryable LayDSLH()
        {
            return da.Db.LoaiHangs.Select(lh => new { lh.id, lh.maLoaiHang, lh.tenLoaiHang });
>>>>>>> branch-2
        }
        public void ThemLoaiHang(DTO_LoaiHang loaihangdto)
        {
            try
            {
                // kiểm tra mã loại hàng có tồn tại chưa (không xét is_deleted)
                var data = da.Db.LoaiHangs.FirstOrDefault(dt => dt.maLoaiHang == loaihangdto.MaLoaiHang);
                if (data == null)
                {
                    // kiểm tra độ dài
                    if (loaihangdto.MaLoaiHang.Length > 30)
                        throw new Exception("Mã loại hàng không quá 30 kí tự!");

                    if (loaihangdto.TenLoaiHang.Length > 50)
                        throw new Exception("Tên loại hàng không quá 50 kí tự!");

                    // tạo mới loại hàng
                    LoaiHang lh = new LoaiHang
                    {
                        maLoaiHang = loaihangdto.MaLoaiHang,
                        tenLoaiHang = loaihangdto.TenLoaiHang
                    };

                    da.Db.LoaiHangs.InsertOnSubmit(lh);
                    da.Db.SubmitChanges();
                }
                else
                {
                    throw new Exception("Mã loại hàng đã tồn tại!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra: " + ex.Message);
            }
        }
        public void XoaLoaiHang(int id)
        {
            try
            {
                // Tìm loại hàng cần xóa
                var data = da.Db.LoaiHangs.FirstOrDefault(dt => dt.id == id);
                if (data != null)
                {
                    da.Db.LoaiHangs.DeleteOnSubmit(data);
                    da.Db.SubmitChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy loại hàng với ID này.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra: " + ex.Message);
            }
        }
        public void SuaLoaiHang(DTO_LoaiHang dto_lh)
        {
            try
            {
                var lh = da.Db.LoaiHangs.FirstOrDefault(dt => dt.id == dto_lh.Id);
                if (lh != null)
                {
                    if (dto_lh.MaLoaiHang.Length > 30)
                        throw new Exception("Mã loại hàng không quá 30 kí tự!");

                    if (dto_lh.TenLoaiHang.Length > 50)
                        throw new Exception("Tên loại hàng không quá 50 kí tự!");

                    lh.maLoaiHang = dto_lh.MaLoaiHang;
                    lh.tenLoaiHang = dto_lh.TenLoaiHang;

                    da.Db.SubmitChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy loại hàng với ID này.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra: " + ex.Message);
            }
        }



    }
<<<<<<< HEAD
}
=======
}
>>>>>>> branch-2
