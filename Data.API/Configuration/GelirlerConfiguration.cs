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
    public class GelirlerConfiguration : IEntityTypeConfiguration<Gelirler>
    {
        public void Configure(EntityTypeBuilder<Gelirler> builder)
        {
            builder.Property(x => x.GelirMiktari).HasColumnType("decimal(18,2)"); 
        }
    }
}
