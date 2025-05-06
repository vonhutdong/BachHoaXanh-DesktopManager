using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KhachHang
    {
        private int id;
        private string maKH;
        private string tenKH;
        private string soDienThoai;
        private double diem;

        // Constructor đầy đủ
        public DTO_KhachHang(int id, string maKH, string tenKH, string soDienThoai, double diem)
        {
            this.Id = id;
            this.MaKH = maKH;
            this.TenKH = tenKH;
            this.SoDienThoai = soDienThoai;
            this.Diem = diem;
        }
        public DTO_KhachHang(int id, string tenKH, string soDienThoai, double diem)
        {
            this.Id = id;
            this.MaKH = maKH;
            this.TenKH = tenKH;
            this.SoDienThoai = soDienThoai;
            this.Diem = diem;
        }

        // Constructor không có ID (dùng khi thêm mới)
        public DTO_KhachHang(string maKH, string tenKH, string soDienThoai, double diem)
        {
            this.MaKH = maKH;
            this.TenKH = tenKH;
            this.SoDienThoai = soDienThoai;
            this.Diem = diem;
        }
        public DTO_KhachHang( string tenKH, string soDienThoai, double diem)
        {
            this.Id = id;
            this.MaKH = maKH;
            this.TenKH = tenKH;
            this.SoDienThoai = soDienThoai;
            this.Diem = diem;
        }

        // Constructor rỗng
        public DTO_KhachHang() { }

        public int Id { get => id; set => id = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public double Diem { get => diem; set => diem = value; }
    }
}
