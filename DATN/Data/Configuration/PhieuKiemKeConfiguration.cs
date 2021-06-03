using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class PhieuKiemKeConfiguration : IEntityTypeConfiguration<PhieuKiemKe>
    {
        public void Configure(EntityTypeBuilder<PhieuKiemKe> builder)
        {
            builder.HasKey(pkk => pkk.SoPhieuKiemKe);
            builder.Property(pkk => pkk.SoPhieuKiemKe).IsRequired();
            //thiet lap quan he 1 - n
            builder.HasOne<NhanVien>(pkk => pkk.NhanVien)
                .WithMany(nv => nv.PhieuKiemKes)
                .HasForeignKey(pkk => pkk.MaNhanVien);
        }
    }
}
