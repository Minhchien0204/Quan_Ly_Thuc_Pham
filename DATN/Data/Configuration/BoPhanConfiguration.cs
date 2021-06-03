using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class BoPhanConfiguration : IEntityTypeConfiguration<BoPhan>
    {
        public void Configure(EntityTypeBuilder<BoPhan> builder)
        {
            // cau hinh thuoc tinh
            builder.HasKey(bp => bp.MaBoPhan);
            builder.Property(bp => bp.TenBoPhan).HasMaxLength(50);
        }
    }
}
