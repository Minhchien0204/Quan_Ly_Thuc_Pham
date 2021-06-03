using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class PhieuYeuCauConfiguration : IEntityTypeConfiguration<PhieuYeuCau>
    {
        public void Configure(EntityTypeBuilder<PhieuYeuCau> builder)
        {
            builder.HasKey(pyc => pyc.SoPhieuYeuCau);
            builder.Property(pyc => pyc.SoPhieuYeuCau).IsRequired().HasMaxLength(50);
            //thiet lap quan he
            builder.HasOne<NhanVien>(pyc => pyc.NhanVien)
                .WithMany(nv => nv.PhieuYeuCaus)
                .HasForeignKey(pyc => pyc.MaNhanVien);
        }
    }
}
