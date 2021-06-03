using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Entities
{
    public class ChiTietYeuCau
    {
        public int Id { get; set; }
        public string SoPhieuYeuCau { get; set; }
        public string MaThucPham { get; set; }
        public float SoLuong { get; set; }
        public virtual ThucPham ThucPham { get; set; }
        public virtual PhieuYeuCau PhieuYeuCau { get; set; }
    }
}
