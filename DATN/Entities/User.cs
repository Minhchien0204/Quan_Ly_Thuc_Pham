using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public bool GioiTinh { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Role { get; set; }
        public virtual Admin Admin { get; set; }
        public virtual GiaoVien GiaoVien { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
