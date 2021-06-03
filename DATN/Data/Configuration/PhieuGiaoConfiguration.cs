using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class PhieuGiaoConfiguration : IEntityTypeConfiguration<PhieuGiao>
    {
        public void Configure(EntityTypeBuilder<PhieuGiao> builder)
        {
            builder.HasKey(pg => pg.SoPhieuGiao);
            builder.Property(pg => pg.SoPhieuGiao).IsRequired();
            //thiet lap quan he
            builder.HasOne<NhanVien>(pg => pg.NhanVien)
                .WithMany(nv => nv.PhieuGiaos)
                .HasForeignKey(pg => pg.MaNhanVien);
            builder.HasOne<PhieuCungCap>(pbg => pbg.PhieuCungCap)
                .WithOne(pyc => pyc.PhieuGiao)
                .HasForeignKey<PhieuGiao>(pbg => pbg.SoPhieuCugCap);
        }
    }
}
