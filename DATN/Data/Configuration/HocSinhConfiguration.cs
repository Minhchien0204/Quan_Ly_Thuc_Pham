using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class HocSinhConfiguration : IEntityTypeConfiguration<HocSinh>
    {
        public void Configure(EntityTypeBuilder<HocSinh> builder)
        {
            builder.HasKey(hs => hs.Idhs);
            builder.Property(hs => hs.Idhs).ValueGeneratedOnAdd().IsRequired();
            // thiet lap quan he
            builder.HasOne<Class>(hs => hs.Class)
                .WithMany(cl => cl.HocSinhs)
                .HasForeignKey(hs => hs.MaLop);
        }
    }
}
