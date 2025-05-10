using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietBangLuong
    {
        private int id;
        private string maChiTietBangLuong;
        private float soGioCongThucTe;
        private int idBangLuong;
        private int idLichLam;
        private DateTime ngayLam;

        public DTO_ChiTietBangLuong(float soGioCongThucTe, int idBangLuong, int idLichLam, DateTime ngayLam)
        {
            this.soGioCongThucTe = soGioCongThucTe;
            this.idBangLuong = idBangLuong;
            this.idLichLam = idLichLam;
            this.ngayLam = ngayLam;
        }
        public DTO_ChiTietBangLuong() { }
        public DTO_ChiTietBangLuong(int id, float soGioCongThucTe, int idBangLuong, int idLichLam, DateTime ngayLam)
        {
            this.id = id;
            this.soGioCongThucTe = soGioCongThucTe;
            this.idBangLuong = idBangLuong;
            this.idLichLam = idLichLam;
            this.ngayLam = ngayLam;
        }

        public int Id { get => id; set => id = value; }
        public float SoGioCongThucTe { get => soGioCongThucTe; set => soGioCongThucTe = value; }
        public int IdBangLuong { get => idBangLuong; set => idBangLuong = value; }
        public int IdLichLam { get => idLichLam; set => idLichLam = value; }
        public DateTime NgayLam { get => ngayLam; set => ngayLam = value; }
        public string MaChiTietBangLuong { get => maChiTietBangLuong; set => maChiTietBangLuong = value; }
    }
}
