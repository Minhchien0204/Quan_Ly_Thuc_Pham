using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Models
{
    public class HocSinhModel
    {
        public int Idhs { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string DienThoai { get; set; }
        public string MaLop { get; set; }
    }
}
