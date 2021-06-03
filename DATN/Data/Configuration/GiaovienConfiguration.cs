using DATN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Data.Configuration
{
    public class GiaovienConfiguration: IEntityTypeConfiguration<GiaoVien>
    {
    public void Configure(EntityTypeBuilder<GiaoVien> builder)
            {
            // cau hinh thuoc tinh
            builder.HasKey(gv => gv.MaGV);
            // thiet lap quan he voi cac bang
            builder.HasOne<Class>(gv => gv.Class)
                .WithOne(cl => cl.GiaoVien)
                .HasForeignKey<GiaoVien>(gv => gv.MaLop);
            }
    }
}
