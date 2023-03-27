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
    public class GiderlerConfiguration : IEntityTypeConfiguration<Giderler>
    {
        public void Configure(EntityTypeBuilder<Giderler> builder)
        {
            builder.Property(x => x.GiderMiktari).HasColumnType("decimal(18,2)");
        }
    }
}
