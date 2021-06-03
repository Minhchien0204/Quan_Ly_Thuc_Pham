using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Entities
{
    public class ThucPham
    {
        public ThucPham()
        {
            DinhLuongMonAns = new HashSet<DinhLuongMonAn>();
            ChiTietYeuCaus = new HashSet<ChiTietYeuCau>();
            ChiTietCungCaps = new HashSet<ChiTietCungCap>();
            ChiTietBanGiaos = new HashSet<ChiTietBanGiao>();
            ChiTietGiaos = new HashSet<ChiTietGiao>();
            ChiTietKiemKes = new HashSet<ChiTietKiemKe>();
        }
        public string MaThucPham { get; set; }
        public string TenThucPham { get; set; }
        public string DonVi { get; set; }
        public virtual ICollection<ChiTietYeuCau> ChiTietYeuCaus { get; set; }
        public virtual ICollection<ChiTietCungCap> ChiTietCungCaps { get; set; }
        public virtual ICollection<ChiTietKiemKe> ChiTietKiemKes { get; set; }
        public virtual ICollection<ChiTietGiao> ChiTietGiaos { get; set; }
        public virtual ICollection<ChiTietBanGiao> ChiTietBanGiaos { get; set; }
        public virtual ICollection<DinhLuongMonAn> DinhLuongMonAns { get; set; }
    } 
}
