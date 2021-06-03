using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Entities
{
    public class DinhLuongMonAn
    {
        public int Id { get; set; }
        public string MaMonAn { get; set; }
        public string MaThucPham { get; set; }
        public float SoLuong { get; set; }
        public virtual MonAn MonAn { get; set; }
        public virtual ThucPham ThucPham { get; set; }
    }
}
