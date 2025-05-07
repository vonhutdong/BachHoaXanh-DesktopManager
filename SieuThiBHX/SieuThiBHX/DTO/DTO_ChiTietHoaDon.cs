using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietHoaDon
    {
        private int id;
        private int soLuong;
        private int idHoaDon;
        private int idSanPham;

        public DTO_ChiTietHoaDon(int id, int soLuong, int idHoaDon, int idSanPham)
        {
            this.Id = id;
            this.SoLuong = soLuong;
            this.IdHoaDon = idHoaDon;
            this.IdSanPham = idSanPham;
        }
        public DTO_ChiTietHoaDon(int soLuong, int idHoaDon, int idSanPham)
        {
            this.soLuong = soLuong;
            this.idHoaDon = idHoaDon;
            this.idSanPham = idSanPham;
        }
        public DTO_ChiTietHoaDon()
        {
            this.id = 0;
            this.soLuong = 0;
            this.idHoaDon = 0;
            this.idSanPham = 0;
            
        }

        public int Id { get => id; set => id = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int IdHoaDon { get => idHoaDon; set => idHoaDon = value; }
        public int IdSanPham { get => idSanPham; set => idSanPham = value; }
    }
}
