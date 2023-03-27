using Entity.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API.Context
{
    public class AppDbContext : IdentityDbContext<UserApp, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Gelirler> Gelirlers { get; set; }
        public DbSet<GelirCategory> GelirCategories { get; set; }
        public DbSet<GiderCategory> GiderCategories { get; set; }
        public DbSet<BorcCategory> BorcCategories { get; set; }
        public DbSet<Giderler> Giderlers { get; set; }
        public DbSet<Borclar> Borcs { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}
