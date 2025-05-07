using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_KhoHang
    {
        // Fields
        private DatabaseAccess da = new DatabaseAccess();
        // Methods
        public IQueryable LoadDSKhoHang()
        {
            //load kho hàng
            return from kh in da.Db.KhoHangs
                   join sp in da.Db.SanPhams
                   on kh.idSanPham equals sp.id
                   select new { kh.id, kh.idSanPham, sp.tenSanPham, kh.soLuong };
        }
        //sửa kho
        public void SuaKhoHang(DTO_KhoHang khohang)
        {
            try
            {
                var upp = da.Db.KhoHangs.FirstOrDefault(k => k.id == khohang.Id);
                if (upp != null)
                {
                    upp.soLuong = khohang.SoLuong;
                    da.Db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
