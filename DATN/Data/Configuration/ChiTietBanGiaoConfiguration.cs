using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class ChiTietBanGiaoConfiguration : IEntityTypeConfiguration<ChiTietBanGiao>
    {
        public void Configure(EntityTypeBuilder<ChiTietBanGiao> builder)
        {
            builder.HasKey(ctbg => ctbg.Id);
            builder.Property(ctbg => ctbg.Id).ValueGeneratedOnAdd().IsRequired();
            // thiet lap quan he 1 - n
            builder.HasOne<PhieuBanGiao>(ctbg => ctbg.PhieuBanGiao)
                .WithMany(pbg => pbg.ChiTietBanGiaos)
                .HasForeignKey(ctbg => ctbg.SoPhieuBanGiao);
            builder.HasOne<ThucPham>(ctbg => ctbg.ThucPham)
                .WithMany(tp => tp.ChiTietBanGiaos)
                .HasForeignKey(ctbg => ctbg.MaThucPham);
        }
    }
}
