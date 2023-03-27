using Entity.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API.Configuration
{
    public class GelirCategoryConfiguration : IEntityTypeConfiguration<GelirCategory>
    {
        public void Configure(EntityTypeBuilder<GelirCategory> builder)
        {
            builder.HasKey(x => new { x.GelirlerId,x.CategoryId});
            builder.HasOne(x => x.Category).WithMany(a => a.Gelirlers).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Gelirler).WithMany(a => a.Categories).HasForeignKey(x => x.GelirlerId).OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
