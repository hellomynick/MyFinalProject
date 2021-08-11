using IdentityStore.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityStore.Data.EntityConfiguration
{
    public class StorePalaceEntityTypeConfiguration : IEntityTypeConfiguration<StorePalace>
    {
        public void Configure(EntityTypeBuilder<StorePalace> builder)
        {
            builder.ToTable("StorePalace");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .UseHiLo("store_palace_hilo")
               .IsRequired();

            builder.Property(cb => cb.Place)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
