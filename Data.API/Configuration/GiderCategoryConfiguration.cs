using Entity.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API.Configuration
{
    public class GiderCategoryConfiguration : IEntityTypeConfiguration<GiderCategory>
    {
        public void Configure(EntityTypeBuilder<GiderCategory> builder)
        {
            builder.HasKey(x => new { x.GiderlerId, x.CategoryId });
            builder.HasOne(x => x.Giderler).WithMany(a => a.Categories).HasForeignKey(x => x.GiderlerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Category).WithMany(a => a.Giderlers).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
