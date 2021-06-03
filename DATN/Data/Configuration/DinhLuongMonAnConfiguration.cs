using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class DinhLuongMonAnConfiguration : IEntityTypeConfiguration<DinhLuongMonAn>
    {
        public void Configure(EntityTypeBuilder<DinhLuongMonAn> builder)
        {
            // cau hinh thuoc tinh
            builder.HasKey(dl => dl.Id);
            builder.Property(dl => dl.Id).ValueGeneratedOnAdd().IsRequired();
            //thiet lap quan he
            builder.HasOne<MonAn>(dl => dl.MonAn)
                .WithMany(ma => ma.DinhLuongMonAns)
                .HasForeignKey(dl => dl.MaMonAn);
            builder.HasOne<ThucPham>(dl => dl.ThucPham)
                .WithMany(tp => tp.DinhLuongMonAns)
                .HasForeignKey(dl => dl.MaThucPham);
        }
    }
}
