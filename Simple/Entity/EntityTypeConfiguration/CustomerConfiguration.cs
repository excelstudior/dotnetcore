using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Entity.EntityTypeConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasIndex(b => b.Name).IsUnique();
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Name).HasMaxLength(100);
            builder.HasKey(b => b.Id);
        }
    }
}
