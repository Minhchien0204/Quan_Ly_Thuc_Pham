using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Entities
{
    public class PhieuGiao
    {
        public PhieuGiao()
        {
            ChiTietGiaos = new HashSet<ChiTietGiao>();
        }
        public string SoPhieuGiao { get; set; }
        public string MaNhanVien { get; set; }
        public string SoPhieuCugCap { get; set; }
        public DateTime NgayLap { get; set; }
        public string GhiChu { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual ICollection<ChiTietGiao> ChiTietGiaos { get; set; }
        public virtual PhieuCungCap PhieuCungCap { get; set; }
     }
}
