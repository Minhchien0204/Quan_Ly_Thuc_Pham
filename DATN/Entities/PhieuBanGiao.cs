using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Entities
{
    public class PhieuBanGiao
    {
        public PhieuBanGiao()
        {
            ChiTietBanGiaos = new HashSet<ChiTietBanGiao>();
        }
        public string SoPhieuBanGiao { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime NgayLap { get; set; }
        public string SoPhieuYeuCau { get; set; }
        public string GhiChu { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual PhieuYeuCau PhieuYeuCau { get; set;}
        public virtual ICollection<ChiTietBanGiao> ChiTietBanGiaos { get; set; }
    }
}
