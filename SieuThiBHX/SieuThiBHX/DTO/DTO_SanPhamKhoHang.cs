using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_SanPhamKhoHang
    {
        private int id { get; set; }
        private string maSanPham { get; set; }
        private string tenSanPham { get; set; }
        private int idLoaiHang { get; set; }
        private double giaBan { get; set; }
        private int soLuong { get; set; }
        private System.Data.Linq.Binary anhSanPham { get; set; }



        public int Id { get => id; set => id = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public string MaSanPham { get => maSanPham; set => maSanPham = value; }
        public int IdLoaiHang { get => idLoaiHang; set => idLoaiHang = value; }
        public double GiaBan { get => giaBan; set => giaBan = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public System.Data.Linq.Binary AnhSanPham { get => anhSanPham; set => anhSanPham = value; }
    }
}
