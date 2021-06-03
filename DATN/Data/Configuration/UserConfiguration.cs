using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Dinh cau hinh cho thuoc tinh
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd().IsRequired(); // chi dinh id tu tang va not null
            builder.Property(u => u.GioiTinh).HasDefaultValue(true); // khoi tao gia tri mac dinh cho thuoc tinh
            // chi dinh so luong ky tu toi da hoac so byte
            builder.Property(u => u.DienThoai).HasMaxLength(10);
            builder.Property(u => u.DiaChi).HasMaxLength(150);
            // thiet lap quan he
            builder.HasOne<Admin>(a => a.Admin)
                .WithOne(u => u.User)
                .HasForeignKey<Admin>(e => e.UserId);
            builder.HasOne<GiaoVien>(g => g.GiaoVien)
                .WithOne(u => u.User)
                .HasForeignKey<GiaoVien>(g => g.UserId);
            builder.HasOne<NhanVien>(n => n.NhanVien)
                .WithOne(u => u.User)
                .HasForeignKey<NhanVien>(n => n.UserId);
        }
    }
}
