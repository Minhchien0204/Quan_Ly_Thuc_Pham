using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class NhanVienConfiguration : IEntityTypeConfiguration<NhanVien>
    {
        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
            // cau hinh thuoc tinh
            builder.HasKey(nv => nv.MaNhanVien);
            // thiet lap quan he
            builder.HasOne<BoPhan>(nv => nv.BoPhan)
                .WithMany(bp => bp.NhanViens)
                .HasForeignKey(nv => nv.MaBoPhan);
        }
    }
}
