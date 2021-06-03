using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Entities
{
    public class ChiTietGiao
    {
        public int Id { get; set; }
        public string SoPhieuGiao { get; set; }
        public string MaThucPham { get; set; }
        public string MaNhaCungCap { get; set; }
        public float SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
        public virtual PhieuGiao PhieuGiao { get; set; }
        public virtual ThucPham ThucPham { get; set; }
    }
}
