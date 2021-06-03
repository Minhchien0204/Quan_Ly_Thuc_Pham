using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class PhieuCungCapConfiguration : IEntityTypeConfiguration<PhieuCungCap>
    {
        public void Configure(EntityTypeBuilder<PhieuCungCap> builder)
        {
            builder.HasKey(pcc => pcc.SoPhieuCugCap);
            builder.Property(pcc => pcc.SoPhieuCugCap).IsRequired();
            //thiet lap quan he 1- n
            builder.HasOne<NhanVien>(pcc => pcc.NhanVien)
                .WithMany(nv => nv.PhieuCungCaps)
                .HasForeignKey(pcc => pcc.MaNhanVien);
            
        }
    }
}
