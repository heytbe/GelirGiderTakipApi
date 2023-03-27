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
    public class BorcCategoryConfiguration : IEntityTypeConfiguration<BorcCategory>
    {
        public void Configure(EntityTypeBuilder<BorcCategory> builder)
        {
            builder.HasKey(x => new { x.BorcId, x.CategoryId });
            builder.HasOne(x => x.Borc).WithMany(a => a.Categories).HasForeignKey(x => x.BorcId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.Category).WithMany(a => a.Borcs).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
