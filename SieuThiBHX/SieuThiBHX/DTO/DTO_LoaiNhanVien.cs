using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LoaiNhanVien
    {
        private int id;
        private string maLoaiNV;
        private string tenLoaiNV;



        public DTO_LoaiNhanVien() { }

        public DTO_LoaiNhanVien(string tenLoaiNV)
        {
            this.tenLoaiNV = tenLoaiNV;
        }

        public DTO_LoaiNhanVien(string maLoaiNV,string tenLoaiNV)
        {
            this.maLoaiNV = maLoaiNV;
            this.tenLoaiNV = tenLoaiNV;
        }
        public DTO_LoaiNhanVien(int id, string tenLoaiNV)
        {
            this.id = id;
            this.tenLoaiNV = tenLoaiNV;
        }
        public DTO_LoaiNhanVien(int id, string maLoaiNV, string tenLoaiNV)
        {
            this.Id = id;
            this.MaLoaiNV = maLoaiNV;
            this.TenLoaiNV = tenLoaiNV;
        }

        public int Id { get => id; set => id = value; }
        public string MaLoaiNV { get => maLoaiNV; set => maLoaiNV = value; }
        public string TenLoaiNV { get => tenLoaiNV; set => tenLoaiNV = value; }
    }
}
