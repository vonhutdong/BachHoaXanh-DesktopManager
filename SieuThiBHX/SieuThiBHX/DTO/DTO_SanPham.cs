using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_SanPham
    {
        private int id;
        private string maSanPham;
        private string tenSanPham;
        private string donViTinh;
        private float donGia;
        private DateTime ngaySanXuat;
        private DateTime hanSuDung;
        private int idLoaiHang;
        private int idNhaCungCap;
        private byte[] anhSanPham;

        public DTO_SanPham(string maSanPham, string tenSanPham, string donViTinh, float donGia, DateTime ngaySanXuat, DateTime hanSuDung, int idLoaiHang, int idNhaCungCap, byte[] anhSanPham)
        {
            this.maSanPham = maSanPham;
            this.tenSanPham = tenSanPham;
            this.donViTinh = donViTinh;
            this.donGia = donGia;
            this.ngaySanXuat = ngaySanXuat;
            this.hanSuDung = hanSuDung;
            this.idLoaiHang = idLoaiHang;
            this.idNhaCungCap = idNhaCungCap;
            this.anhSanPham = anhSanPham;
        }
        public DTO_SanPham(int id, string maSanPham, string tenSanPham, string donViTinh, float donGia, DateTime ngaySanXuat, DateTime hanSuDung, int idLoaiHang, int idNhaCungCap, byte[] anhSanPham)
        {
            this.id = id;
            this.maSanPham = maSanPham;
            this.tenSanPham = tenSanPham;
            this.donViTinh = donViTinh;
            this.donGia = donGia;
            this.ngaySanXuat = ngaySanXuat;
            this.hanSuDung = hanSuDung;
            this.idLoaiHang = idLoaiHang;
            this.idNhaCungCap = idNhaCungCap;
            this.anhSanPham = anhSanPham;
        }

        public int Id { get => id; set => id = value; }
        public string MaSanPham { get => maSanPham; set => maSanPham = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        public float DonGia { get => donGia; set => donGia = value; }
        public DateTime NgaySanXuat { get => ngaySanXuat; set => ngaySanXuat = value; }
        public DateTime HanSuDung { get => hanSuDung; set => hanSuDung = value; }
        public int IdLoaiHang { get => idLoaiHang; set => idLoaiHang = value; }
        public int IdNhaCungCap { get => idNhaCungCap; set => idNhaCungCap = value; }
        public byte[] AnhSanPham { get => anhSanPham; set => anhSanPham = value; }
    }
}
