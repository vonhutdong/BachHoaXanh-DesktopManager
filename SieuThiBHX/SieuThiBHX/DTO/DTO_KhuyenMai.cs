using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
        public class DTO_KhuyenMai
        {
            // Fields
            private int id;
            private string maKhuyenMai;
            private string tenKhuyenMai;
            private float giaTri;
 

            // Constructors
            public DTO_KhuyenMai()
            {
                
            }

            public DTO_KhuyenMai(int id, string maKhuyenMai, string tenKhuyenMai, float giaTri)
            {
                this.id = id;
                this.maKhuyenMai = maKhuyenMai;
                this.tenKhuyenMai = tenKhuyenMai;
                this.giaTri = giaTri;
            }

            public DTO_KhuyenMai(int id, string tenKhuyenMai, float giaTri)
            {
                this.id = id;
                this.tenKhuyenMai = tenKhuyenMai;
                this.giaTri = giaTri;
            }

            public DTO_KhuyenMai(string maKhuyenMai, string tenKhuyenMai, float giaTri)
            {
                this.maKhuyenMai = maKhuyenMai;
                this.tenKhuyenMai = tenKhuyenMai;
                this.giaTri = giaTri;
            }

            public DTO_KhuyenMai(string tenKhuyenMai, float giaTri)
            {
                this.tenKhuyenMai = tenKhuyenMai;
                this.giaTri = giaTri;
            }

            // Properties
            public int Id { get => id; set => id = value; }
            public string MaKhuyenMai { get => maKhuyenMai; set => maKhuyenMai = value; }
            public string TenKhuyenMai { get => tenKhuyenMai; set => tenKhuyenMai = value; }
            public float GiaTri { get => giaTri; set => giaTri = value; }
    
        }
    
}
