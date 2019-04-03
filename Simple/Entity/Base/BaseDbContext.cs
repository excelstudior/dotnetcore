using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple.Entity.Base;
using Simple.Entity.EntityTypeConfiguration;
using Microsoft.Extensions.Configuration;

namespace Simple.Entity.Base
{
    public class BaseDbContext:DbContext
    {
        public BaseDbContext()
        {
        }

        public BaseDbContext(DbContextOptions<BaseDbContext> options ):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connection = Configuration["ConnectionStrings:MsSqlConnection"];
            optionsBuilder.UseMySQL(Startup.Configuration["ConnectionStrings:MySqlConnection"]);
            //optionsBuilder.UseSqlServer(Startup.Configuration["ConnectionStrings:MsSqlConnection"]);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
        }
    }
}
