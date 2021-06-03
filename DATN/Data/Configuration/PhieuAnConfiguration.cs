using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class PhieuAnConfiguration : IEntityTypeConfiguration<PhieuAn>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PhieuAn> builder)
        {
            builder.HasKey(pa => pa.SophieuAn);
            builder.Property(pa => pa.SophieuAn).IsRequired();
            //thiet lap quan he 1- n
            builder.HasOne<GiaoVien>(pa => pa.GiaoVien)
                .WithMany(gv => gv.PhieuAns)
                .HasForeignKey(pa => pa.MaGV);
           
        }
    }
}
