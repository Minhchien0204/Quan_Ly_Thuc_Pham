using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class PhieuBanGiaoConfiguration : IEntityTypeConfiguration<PhieuBanGiao>
    {
        public void Configure(EntityTypeBuilder<PhieuBanGiao> builder)
        {
            builder.HasKey(pbg => pbg.SoPhieuBanGiao);
            builder.Property(pbg => pbg.SoPhieuBanGiao).IsRequired();
            // thiet lap quan he 1 - n va 1 - 1
            builder.HasOne<NhanVien>(pbg => pbg.NhanVien)
                .WithMany(nv => nv.PhieuBanGiaos)
                .HasForeignKey(pbg => pbg.MaNhanVien);
            builder.HasOne<PhieuYeuCau>(pbg => pbg.PhieuYeuCau)
                .WithOne(pyc => pyc.PhieuBanGiao)
                .HasForeignKey<PhieuBanGiao>(pbg => pbg.SoPhieuYeuCau);
        }
    }
}
