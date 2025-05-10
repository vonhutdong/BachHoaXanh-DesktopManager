using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LoaiHang
    {
        private int id;
        private string maLoaiHang;
        private string tenLoaiHang;

        public DTO_LoaiHang(string maLoaiHang, string tenLoaiHang)
        {
            this.maLoaiHang = maLoaiHang;
            this.tenLoaiHang = tenLoaiHang;
        }
<<<<<<< HEAD
        
=======

>>>>>>> branch-2
        public DTO_LoaiHang(int id, string maLoaiHang, string tenLoaiHang)
        {
            this.id = id;
            this.maLoaiHang = maLoaiHang;
            this.tenLoaiHang = tenLoaiHang;
        }
<<<<<<< HEAD
<<<<<<< HEAD
        public DTO_LoaiHang() { }
=======

>>>>>>> branch-2
=======

>>>>>>> parent of d3a4bab (Merge branch 'MinhDev_V1' into tempNew)
        public int Id { get => id; set => id = value; }
        public string MaLoaiHang { get => maLoaiHang; set => maLoaiHang = value; }
        public string TenLoaiHang { get => tenLoaiHang; set => tenLoaiHang = value; }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> branch-2
