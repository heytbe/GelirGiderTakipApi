using Core.API.Entities;
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
    public class ImagesConfiguration : IEntityTypeConfiguration<Images>
    {
        public void Configure(EntityTypeBuilder<Images> builder)
        {
            builder.HasOne(x => x.Giderler).WithMany(a => a.Images).HasForeignKey(x => x.GiderlerId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.Gelirler).WithMany(a => a.Images).HasForeignKey(x => x.GelirlerId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.Borc).WithMany(a => a.Images).HasForeignKey(x => x.BorcId);
            builder.HasOne(x => x.Category).WithOne(a => a.Images).HasForeignKey<Category>(x => x.ImagesId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
