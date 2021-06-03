using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Entities
{
    public class NhaCungCap
    {
        public NhaCungCap()
        {
            ChiTietCungCaps = new HashSet<ChiTietCungCap>();
            ChiTietGiaos = new HashSet<ChiTietGiao>();
        }
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public virtual ICollection<ChiTietCungCap> ChiTietCungCaps { get; set; }
        public virtual ICollection<ChiTietGiao> ChiTietGiaos { get; set; }
    }
}
