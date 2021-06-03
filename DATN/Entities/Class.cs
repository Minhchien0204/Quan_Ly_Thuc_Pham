using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Entities
{
    public class Class
    {
        public Class()
        {
            HocSinhs = new HashSet<HocSinh>();
        }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public int SoLuong { get; set; }
        public virtual GiaoVien GiaoVien { get; set; }
        public virtual ICollection<HocSinh> HocSinhs { get; set; }
    }
}
