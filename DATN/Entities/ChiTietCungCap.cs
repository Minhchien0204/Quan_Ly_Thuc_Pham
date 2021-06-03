using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Entities
{
    public class ChiTietCungCap
    {
        public int Id { get; set; }
        public string SoPhieuCugCap { get; set; }
        public string MaThucPham { get; set; }
        public string MaNhaCungCap { get; set; }
        public float SoLuong { get; set; }
        public virtual PhieuCungCap PhieuCungCap { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
        public virtual ThucPham ThucPham { get; set; }
    }
}
