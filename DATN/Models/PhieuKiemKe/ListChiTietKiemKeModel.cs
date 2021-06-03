using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Models.PhieuKiemKe
{
    public class ListChiTietKiemKeModel
    {
        public int Id { get; set; }
        public string SoPhieuKiemKe { get; set; }
        public string MaThucPham { get; set; }
        public string TenThucPham { get; set; }
        public float SoLuong { get; set; }
        public string ChatLuong { get; set; }
    }
}
