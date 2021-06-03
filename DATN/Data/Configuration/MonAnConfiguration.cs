using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class MonAnConfiguration : IEntityTypeConfiguration<MonAn>
    {
        public void Configure(EntityTypeBuilder<MonAn> builder)
        {
            builder.HasKey(ma => ma.MaMonAn);
            builder.Property(ma => ma.MaMonAn).IsRequired();
            // thiet lap quan he
            builder.HasOne<NhanVien>(ma => ma.NhanVien)
                .WithMany(nv => nv.MonAns)
                .HasForeignKey(ma => ma.MaNhanVien);
        }
    }
}
