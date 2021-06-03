using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class ChiTierCungCapConfiguration : IEntityTypeConfiguration<ChiTietCungCap>
    {
        public void Configure(EntityTypeBuilder<ChiTietCungCap> builder)
        {
            builder.HasKey(ctcc => ctcc.Id);
            builder.Property(ctcc => ctcc.Id).ValueGeneratedOnAdd().IsRequired();
            // thiet lap quan he 1 - n
            builder.HasOne<PhieuCungCap>(ctcc => ctcc.PhieuCungCap)
                .WithMany(pcc => pcc.ChiTietCungCaps)
                .HasForeignKey(ctcc => ctcc.SoPhieuCugCap);
            builder.HasOne<ThucPham>(ctcc => ctcc.ThucPham)
                .WithMany(tp => tp.ChiTietCungCaps)
                .HasForeignKey(ctcc => ctcc.MaThucPham);
            builder.HasOne<NhaCungCap>(ctcc => ctcc.NhaCungCap)
                .WithMany(ncc => ncc.ChiTietCungCaps)
                .HasForeignKey(ctcc => ctcc.MaNhaCungCap);
        }
    }
}
