using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhanVien
    {
        private int id;
        private string maNV;
        private string tenNV;
        private string SoDT;
        private string diaChi;
        private int idLNV;
        private int idTK;


        public DTO_NhanVien() { }

        public DTO_NhanVien(string tenNV, string soDT, string diaChi, int idLNV, int idTK)
        {
            this.tenNV = tenNV;
            this.SoDT = soDT;
            this.diaChi = diaChi;
            this.idLNV = idLNV;
            this.idTK = idTK;
        }
        public DTO_NhanVien(int id, string tenNV, string soDT, string diaChi, int idLNV, int idTK)
        {
            this.id = id;
            this.tenNV = tenNV;
            SoDT = soDT;
            this.diaChi = diaChi;
            this.idLNV = idLNV;
            this.idTK = idTK;
        }
        public DTO_NhanVien(int id, string maNV, string tenNV, string soDT, string diaChi, int idLNV, int idTK)
        {
            this.id = id;
            this.maNV = maNV;
            this.tenNV = tenNV;
            SoDT = soDT;
            this.diaChi = diaChi;
            this.idLNV = idLNV;
            this.idTK = idTK;
        }

        public int Id { get => id; set => id = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string SoDT1 { get => SoDT; set => SoDT = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int IdLNV { get => idLNV; set => idLNV = value; }
        public int IdTK { get => idTK; set => idTK = value; }
    }
}
