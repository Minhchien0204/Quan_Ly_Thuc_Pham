using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Models.ChiTietGiao
{
    public class ChiTietGiaoModel
    {
        public int Id { get; set; }
        public string SoPhieuGiao { get; set; }
        public string MaThucPham { get; set; }
        public string TenThucPham { get; set; }
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public float SoLuong { get; set; }
        public decimal DonGia { get; set; }
    }
}
