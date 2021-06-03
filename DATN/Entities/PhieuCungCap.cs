using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Entities
{
    public class PhieuCungCap
    {
        public PhieuCungCap()
        {
            ChiTietCungCaps = new HashSet<ChiTietCungCap>();
        }
        public string SoPhieuCugCap { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime NgayLap { get; set; }
        public bool TrangThai { get; set; } = false;
        public string GhiChu { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual ICollection<ChiTietCungCap> ChiTietCungCaps { get; set; }
        public virtual PhieuGiao PhieuGiao { get; set; }

    }
}
