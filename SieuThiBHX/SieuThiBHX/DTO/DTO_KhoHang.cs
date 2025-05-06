using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KhoHang
    {
        private int id;
        private int idSanPham;
        private int soLuong;

        public DTO_KhoHang(int id, int idSanPham, int soLuong)
        {
            this.Id = id;
            this.IdSanPham = idSanPham;
            this.SoLuong = soLuong;
        }

        public int Id { get => id; set => id = value; }
        public int IdSanPham { get => idSanPham; set => idSanPham = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
