using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Entities
{
    public class NhanVien
    {
        public NhanVien()
        {
            MonAns = new HashSet<MonAn>();
            PhieuYeuCaus = new HashSet<PhieuYeuCau>();
            PhieuBanGiaos = new HashSet<PhieuBanGiao>();
            PhieuCungCaps = new HashSet<PhieuCungCap>();
            PhieuGiaos = new HashSet<PhieuGiao>();
            PhieuKiemKes = new HashSet<PhieuKiemKe>();
        }
        public string MaNhanVien { get; set; }
        public int UserId { get; set; }
        public string MaBoPhan { get; set; }
        public virtual BoPhan BoPhan { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<PhieuYeuCau> PhieuYeuCaus { get; set; }
        public virtual ICollection<PhieuCungCap> PhieuCungCaps { get; set; }
        public virtual ICollection<PhieuKiemKe> PhieuKiemKes { get; set; }
        public virtual ICollection<PhieuGiao> PhieuGiaos { get; set; }
        public virtual ICollection<PhieuBanGiao> PhieuBanGiaos { get; set; }
        public virtual ICollection<MonAn> MonAns { get; set; }

    }
}
