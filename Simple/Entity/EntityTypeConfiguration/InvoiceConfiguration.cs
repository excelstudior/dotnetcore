using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Simple.Entity.EntityTypeConfiguration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasOne(i => i.Customer).WithMany(c => c.Invoices).HasForeignKey(i => i.CustomerId);
            builder.Property(i => i.CreatedDateTime).ValueGeneratedOnAdd();
            builder.Property(i => i.UpdatedDateTime).ValueGeneratedOnAddOrUpdate();
        }
    }
}
