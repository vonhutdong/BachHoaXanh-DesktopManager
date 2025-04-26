using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CaLam
    {
        private int id;
        private string maCaLam;
        private string tenCaLam;
        private string gioBatDau;
        private string gioKetThuc;

        public DTO_CaLam() {}
        public DTO_CaLam(int id, string maCaLam, string tenCaLam, string gioBatDau, string gioKetThuc)
        {
            this.id = id;
            this.maCaLam = maCaLam;
            this.tenCaLam = tenCaLam;
            this.gioBatDau = gioBatDau;
            this.gioKetThuc = gioKetThuc;
        }
        public DTO_CaLam(int id, string tenCaLam, string gioBatDau, string gioKetThuc)
        {
            this.Id = id;
            this.TenCaLam = tenCaLam;
            this.GioBatDau = gioBatDau;
            this.GioKetThuc = gioKetThuc;
        }
        public DTO_CaLam(string tenCaLam, string gioBatDau, string gioKetThuc)
        {
            this.TenCaLam = tenCaLam;
            this.GioBatDau = gioBatDau;
            this.GioKetThuc = gioKetThuc;
        }
        public int Id { get => id; set => id = value; }
        public string MaCaLam { get => maCaLam; set => maCaLam = value; }
        public string TenCaLam { get => tenCaLam; set => tenCaLam = value; }
        public string GioBatDau { get => gioBatDau; set => gioBatDau = value; }
        public string GioKetThuc { get => gioKetThuc; set => gioKetThuc = value; }
    }
}
