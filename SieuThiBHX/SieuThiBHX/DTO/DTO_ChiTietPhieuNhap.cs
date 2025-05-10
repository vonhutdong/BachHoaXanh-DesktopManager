using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietPhieuNhap
    {
        // Fields
        private int id;
        private int soLuong;
        private float donGia;
        private int idPhieuNhap;
        private int idSanPham;

        // Constructors
        public DTO_ChiTietPhieuNhap() { }

        public DTO_ChiTietPhieuNhap(int id, int soLuong, float donGia, int idPhieuNhap, int idSanPham)
        {
            this.id = id;
            this.soLuong = soLuong;
            this.donGia = donGia;
            this.idPhieuNhap = idPhieuNhap;
            this.idSanPham = idSanPham;
        }

        public DTO_ChiTietPhieuNhap(int soLuong, float donGia, int idPhieuNhap, int idSanPham)
        {
            this.soLuong = soLuong;
            this.donGia = donGia;
            this.idPhieuNhap = idPhieuNhap;
            this.idSanPham = idSanPham;
        }

        // Properties
        public int Id { get => id; set => id = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public float DonGia { get => donGia; set => donGia = value; }
        public int IdPhieuNhap { get => idPhieuNhap; set => idPhieuNhap = value; }
        public int IdSanPham { get => idSanPham; set => idSanPham = value; }
    }
}
