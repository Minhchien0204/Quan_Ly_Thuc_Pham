using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Models.DinhLuonMonAn
{
    public class DinhLuongMAModel
    {
        public int Id { get; set; }
        public string MaMonAn { get; set; }
        public string TenMonAn { get; set; }
        public string MaThucPham { get; set; }
        public string TenThucPham { get; set; }
        public float SoLuong { get; set; }
    }
}
