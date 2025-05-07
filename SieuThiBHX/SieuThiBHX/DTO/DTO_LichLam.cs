using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LichLam
    {
        //Fields
        private int id;
        private string maLichLam;
        private DateTime ngayLam;
        private int idNhanVien;
        private int idCaLam;


        public DTO_LichLam(string maLichLam, DateTime ngayLam, int idNhanVien, int idCaLam)
        {
            this.MaLichLam = maLichLam;
            this.NgayLam = ngayLam;
            this.IdNhanVien = idNhanVien;
            this.IdCaLam = idCaLam;
        }

        public DTO_LichLam(int id, string maLichLam, DateTime ngayLam, int idNhanVien, int idCaLam)
        {
            this.Id = id;
            this.MaLichLam = maLichLam;
            this.NgayLam = ngayLam;
            this.IdNhanVien = idNhanVien;
            this.IdCaLam = idCaLam;
        }

        public DTO_LichLam(DateTime ngayLam, int idNhanVien, int idCaLam)
        {
            this.Id = id;
            this.MaLichLam = maLichLam;
            this.NgayLam = ngayLam;
            this.IdNhanVien = idNhanVien;
            this.IdCaLam = idCaLam;
        }

        public DTO_LichLam(int id, DateTime ngayLam, int idNhanVien, int idCaLam)
        {
            this.Id = id;
            this.MaLichLam = maLichLam;
            this.NgayLam = ngayLam;
            this.IdNhanVien = idNhanVien;
            this.IdCaLam = idCaLam;
        }

        public int Id { get => id; set => id = value; }
        public string MaLichLam { get => maLichLam; set => maLichLam = value; }
        public DateTime NgayLam { get => ngayLam; set => ngayLam = value; }
        public int IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
        public int IdCaLam { get => idCaLam; set => idCaLam = value; }
    }
}
