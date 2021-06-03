using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class ChiTietKiemKeConfiguration : IEntityTypeConfiguration<ChiTietKiemKe>
    {
        public void Configure(EntityTypeBuilder<ChiTietKiemKe> builder)
        {
            builder.HasKey(ctkk => ctkk.Id);
            builder.Property(ctkk => ctkk.Id).ValueGeneratedOnAdd().IsRequired();
            // thiet lap quan he
            builder.HasOne<PhieuKiemKe>(ctkk => ctkk.PhieuKiemKe)
                .WithMany(pkk => pkk.ChiTietKiemKes)
                .HasForeignKey(ctkk => ctkk.SoPhieuKiemKe);
            builder.HasOne<ThucPham>(ctkk => ctkk.ThucPham)
                .WithMany(tp => tp.ChiTietKiemKes)
                .HasForeignKey(ctkk => ctkk.MaThucPham);
        }
    }
}
