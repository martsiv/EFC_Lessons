using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Shop_data_access.Entities;

namespace Shop_data_access.Data.Configurations
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.Property(x => x.Salary).HasColumnType("money");
            builder.HasOne(w => w.Position).WithMany(p => p.Workers).HasForeignKey(w => w.PositionId);
            builder.HasOne(w => w.Shop).WithMany(s => s.Workers).HasForeignKey(w => w.ShopId);
            
        }
    }
}
