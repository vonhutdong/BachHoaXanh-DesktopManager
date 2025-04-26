using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BangLuong
    {
        private int id;
        private string maBangLuong;
        private DateTime thangNam;
        private float tongGioCong;
        private float _luong;
        private int idNhanVien;

        public DTO_BangLuong(string maBangLuong, DateTime thangNam, float tongGioCong, float luong, int idNhanVien)
        {
            this.maBangLuong = maBangLuong;
            this.thangNam = thangNam;
            this.tongGioCong = tongGioCong;
            _luong = luong;
            this.idNhanVien = idNhanVien;
        }
        public DTO_BangLuong() { }
        public DTO_BangLuong(int id, string maBangLuong, DateTime thangNam, float tongGioCong, float luong, int idNhanVien)
        {
            this.id = id;
            this.maBangLuong = maBangLuong;
            this.thangNam = thangNam;
            this.tongGioCong = tongGioCong;
            _luong = luong;
            this.idNhanVien = idNhanVien;
        }

        public int Id { get => id; set => id = value; }
        public string MaBangLuong { get => maBangLuong; set => maBangLuong = value; }
        public DateTime ThangNam { get => thangNam; set => thangNam = value; }
        public float TongGioCong { get => tongGioCong; set => tongGioCong = value; }
        public float Luong { get => _luong; set => _luong = value; }
        public int IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
    }
}
