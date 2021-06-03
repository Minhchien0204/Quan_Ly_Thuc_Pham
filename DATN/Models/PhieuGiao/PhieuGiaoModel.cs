using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Models.PhieuGiao
{
    public class PhieuGiaoModel
    {
        public string SoPhieuGiao { get; set; }
        public string MaNhanVien { get; set; }
        public string Name { get; set; }
        public string SoPhieuCugCap { get; set; }
        public DateTime NgayLap { get; set; }
        public string GhiChu { get; set; }
    }
}
