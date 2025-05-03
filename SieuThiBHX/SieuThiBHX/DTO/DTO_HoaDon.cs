using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HoaDon
    {
        private int id;
        private string maHoaDon;
        private DateTime ngayLapHD;
        private DateTime gioLapHD;
        private float tongTien;
        private float thanhTien;
        private int idKhachHang;
        private int idKhuyenMai;
        private int idNhanVien;

        public DTO_HoaDon(string maHoaDon, DateTime ngayLapHD, DateTime gioLapHD, float tongTien,
            float thanhTien, int idKhachHang, int idKhuyenMai, int idNhanVien)
        {
            this.maHoaDon = maHoaDon;
            this.ngayLapHD = ngayLapHD;
            this.gioLapHD = gioLapHD;
            this.tongTien = tongTien;
            this.thanhTien = thanhTien;
            this.idKhachHang = idKhachHang;
            this.idKhuyenMai = idKhuyenMai;
            this.idNhanVien = idNhanVien;
        }

        public DTO_HoaDon(int id, int idKhachHang, int idKhuyenMai, int idNhanVien)
        {
            this.id = id;
            this.idKhachHang = idKhachHang;
            this.idKhuyenMai = idKhuyenMai;
            this.idNhanVien = idNhanVien;
        }

        public DTO_HoaDon(int idKhachHang, int idKhuyenMai, int idNhanVien)
        {
            this.idKhachHang = idKhachHang;
            this.idKhuyenMai = idKhuyenMai;
            this.idNhanVien = idNhanVien;
        }
        public DTO_HoaDon(int id, string maHoaDon, DateTime ngayLapHD, DateTime gioLapHD,
            float tongTien, float thanhTien, int idKhachHang, int idKhuyenMai, int idNhanVien)
        {
            this.Id = id;
            this.MaHoaDon = maHoaDon;
            this.NgayLapHD = ngayLapHD;
            this.GioLapHD = gioLapHD;
            this.TongTien = tongTien;
            this.ThanhTien = thanhTien;
            this.IdKhachHang = idKhachHang;
            this.IdKhuyenMai = idKhuyenMai;
            this.IdNhanVien = idNhanVien;
        }

        public int Id { get => id; set => id = value; }
        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public DateTime NgayLapHD { get => ngayLapHD; set => ngayLapHD = value; }
        public DateTime GioLapHD { get => gioLapHD; set => gioLapHD = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
        public float ThanhTien { get => thanhTien; set => thanhTien = value; }
        public int IdKhachHang { get => idKhachHang; set => idKhachHang = value; }
        public int IdKhuyenMai { get => idKhuyenMai; set => idKhuyenMai = value; }
        public int IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
    }
}
