using DATN.Data.Configuration;
using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data
{
    public class DataContext: DbContext
    {
        public DataContext( DbContextOptions<DataContext> option): base(option)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<GiaoVien> GiaoViens { get; set; }
        public DbSet<ThucPham> ThucPhams { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<BoPhan> BoPhans { get; set; }
        public DbSet<MonAn> MonAns { get; set; }
        public DbSet<PhieuGiao> PhieuGiaos { get; set; }
        public DbSet<ChiTietGiao> ChiTietGiaos { get; set; }
        public DbSet<PhieuBanGiao> PhieuBanGiaos { get; set; }
        public DbSet<ChiTietBanGiao> ChiTietBanGiaos { get; set; }
        public DbSet<PhieuKiemKe> PhieuKiemKes { get; set; }
        public DbSet<ChiTietKiemKe> ChiTietKiemKes { get; set; }
        public DbSet<PhieuYeuCau> PhieuYeuCaus { get; set; }
        public DbSet<ChiTietYeuCau> ChiTietYeuCaus { get; set; }
        public DbSet<PhieuCungCap> PhieuCungCaps { get; set; }
        public DbSet<ChiTietCungCap> ChiTietCungCaps { get; set; }
        public DbSet<DinhLuongMonAn> DinhLuongMonAns { get; set; }
        public DbSet<PhieuAn> PhieuAns { get; set; }
        public DbSet<HocSinh> HocSinhs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            modelBuider.ApplyConfiguration(new UserConfiguration());
            modelBuider.ApplyConfiguration(new ThucPhamConfiguration());
            modelBuider.ApplyConfiguration(new PhieuYeuCauConfiguration());
            modelBuider.ApplyConfiguration(new PhieuKiemKeConfiguration());
            modelBuider.ApplyConfiguration(new PhieuGiaoConfiguration());
            modelBuider.ApplyConfiguration(new PhieuCungCapConfiguration());
            modelBuider.ApplyConfiguration(new PhieuBanGiaoConfiguration());
            modelBuider.ApplyConfiguration(new PhieuAnConfiguration());
            modelBuider.ApplyConfiguration(new NhanVienConfiguration());
            modelBuider.ApplyConfiguration(new NhaCungCapConfiguration());
            modelBuider.ApplyConfiguration(new MonAnConfiguration());
            modelBuider.ApplyConfiguration(new GiaovienConfiguration());
            modelBuider.ApplyConfiguration(new DinhLuongMonAnConfiguration());
            modelBuider.ApplyConfiguration(new ClassConfiguration());
            modelBuider.ApplyConfiguration(new ChiTietYeuCauConfiguration());
            modelBuider.ApplyConfiguration(new ChiTietKiemKeConfiguration());
            modelBuider.ApplyConfiguration(new ChiTietGiaoConfiguration());
            modelBuider.ApplyConfiguration(new ChiTietBanGiaoConfiguration());
            modelBuider.ApplyConfiguration(new ChiTierCungCapConfiguration());
            modelBuider.ApplyConfiguration(new BoPhanConfiguration());
            modelBuider.ApplyConfiguration(new AdminConfiguration());
            modelBuider.ApplyConfiguration(new HocSinhConfiguration());
        }
    }
}
