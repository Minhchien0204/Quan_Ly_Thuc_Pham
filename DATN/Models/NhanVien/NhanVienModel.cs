using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Models.NhanVien
{
    public class NhanVienModel
    {
        public string MaNhanVien { get; set; }
        public string Name { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public DateTime NgaySinh { get; set; }
        public string TenBoPhan { get; set; }
    }
}
