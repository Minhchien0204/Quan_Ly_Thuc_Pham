using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Entities
{
    public class PhieuKiemKe
    {
        public PhieuKiemKe()
        {
            ChiTietKiemKes = new HashSet<ChiTietKiemKe>();
        }
        public string SoPhieuKiemKe { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime NgayLap { get; set; }
        public string GhiChu { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual ICollection<ChiTietKiemKe> ChiTietKiemKes { get; set; }
    }
}
