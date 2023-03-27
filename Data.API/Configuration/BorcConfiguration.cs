using Entity.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.API.Configuration
{
    public class BorcConfiguration : IEntityTypeConfiguration<Borclar>
    {
        public void Configure(EntityTypeBuilder<Borclar> builder)
        {
            builder.Property(x => x.BorcMiktari).HasColumnType("decimal(18,2)");
        }
    }
}
