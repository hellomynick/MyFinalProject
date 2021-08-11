using IdentityStore.API.Models;
using IdentityStore.Data.EntityConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityStore.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationStore>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<StorePalace> StorePalaces { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StorePalaceEntityTypeConfiguration());
            base.OnModelCreating(builder);
        }
    }
}