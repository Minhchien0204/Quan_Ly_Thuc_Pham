using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Entities
{
    public class PhieuAn
    {
        public string SophieuAn { get; set; }
        public string MaGV { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }
        public bool TrangThai { get; set; } = false;
        public string GhiChu { get; set; }
        public virtual GiaoVien GiaoVien { get; set; }
    }
}
