using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class ChiTietYeuCauConfiguration : IEntityTypeConfiguration<ChiTietYeuCau>
    {
        public void Configure(EntityTypeBuilder<ChiTietYeuCau> builder)
        {
            builder.HasKey(ctyc => ctyc.Id);
            builder.Property(ctyc => ctyc.Id).ValueGeneratedOnAdd().IsRequired();
            // thiet lap quan he 1 - n
            builder.HasOne<PhieuYeuCau>(ctyc => ctyc.PhieuYeuCau)
                .WithMany(pyc => pyc.ChiTietYeuCaus)
                .HasForeignKey(ctyc => ctyc.SoPhieuYeuCau);
            builder.HasOne<ThucPham>(ctyc => ctyc.ThucPham)
                .WithMany(tp => tp.ChiTietYeuCaus)
                .HasForeignKey(ctyc => ctyc.MaThucPham);
        }
    }
}
