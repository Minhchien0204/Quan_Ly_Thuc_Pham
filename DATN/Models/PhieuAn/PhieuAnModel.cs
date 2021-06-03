using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Models.PhieuAn
{
    public class PhieuAnModel
    {
        public string SophieuAn { get; set; }
        public string MaGV { get; set; }
        public string Name { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }
        public bool TrangThai { get; set; }
        public string GhiChu { get; set; }
    }
}
