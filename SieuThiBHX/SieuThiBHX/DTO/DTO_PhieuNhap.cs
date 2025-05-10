using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_PhieuNhap
    {
        // Fields
        private int id;
        private DateTime ngayNhap;
        private float thanhTien;
        private int idNhanVien;

        // Constructors
        public DTO_PhieuNhap() { }

        public DTO_PhieuNhap(int id, DateTime ngayNhap, float thanhTien, int idNhanVien)
        {
            this.id = id;
            this.ngayNhap = ngayNhap;
            this.thanhTien = thanhTien;
            this.idNhanVien = idNhanVien;
        }

        public DTO_PhieuNhap(DateTime ngayNhap, float thanhTien, int idNhanVien)
        {
            this.ngayNhap = ngayNhap;
            this.thanhTien = thanhTien;
            this.idNhanVien = idNhanVien;
        }

        // Properties
        public int Id { get => id; set => id = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public float ThanhTien { get => thanhTien; set => thanhTien = value; }
        public int IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
    }
}
