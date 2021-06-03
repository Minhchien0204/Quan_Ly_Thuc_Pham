using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class ChiTietGiaoConfiguration : IEntityTypeConfiguration<ChiTietGiao>
    {
        public void Configure(EntityTypeBuilder<ChiTietGiao> builder)
        {
            builder.HasKey(ctg => ctg.Id);
            builder.Property(ctg => ctg.Id).ValueGeneratedOnAdd().IsRequired();
            // thiet lap quan he 1 - n
            builder.HasOne<PhieuGiao>(ctg => ctg.PhieuGiao)
                .WithMany(pg => pg.ChiTietGiaos)
                .HasForeignKey(ctg => ctg.SoPhieuGiao);
            builder.HasOne<ThucPham>(ctg => ctg.ThucPham)
                .WithMany(tp => tp.ChiTietGiaos)
                .HasForeignKey(ctg => ctg.MaThucPham);
            builder.HasOne<NhaCungCap>(ctg => ctg.NhaCungCap)
             .WithMany(ncc => ncc.ChiTietGiaos)
             .HasForeignKey(ctg => ctg.MaNhaCungCap);
        }
    }
}
