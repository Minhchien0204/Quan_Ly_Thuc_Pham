using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Entities
{
    public class MonAn
    {
        public MonAn()
        {
            DinhLuongMonAns = new HashSet<DinhLuongMonAn>();
        }
        public string MaMonAn { get; set; }
        public string TenMonAn { get; set; }
        public string MaNhanVien { get; set; }
        public string BuaAn { get; set; }
        public virtual ICollection<DinhLuongMonAn> DinhLuongMonAns { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
