using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class ThucPhamConfiguration : IEntityTypeConfiguration<ThucPham>
    {
        public void Configure(EntityTypeBuilder<ThucPham> builder)
        {
            builder.HasKey(tp => tp.MaThucPham);
            builder.Property(tp => tp.MaThucPham).IsRequired();
        }
    }
}
