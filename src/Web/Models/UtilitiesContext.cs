using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Entities;

namespace Web.Models
{
    public class UtilitiesContext: DbContext
    {
        public DbSet<BillType> BillTypes { get; set; }
        public DbSet<BillProvider> BillProviders { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<Bill> Bills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BillType>()
                .ToTable("BillType")
                .Property(x => x.TypeName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<BillProvider>()
                .ToTable("BillProvider")
                .Property(x => x.ProviderName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Month>()
                .ToTable("Month")
                .Property(x => x.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill");
                entity.Property(x => x.MonthId).IsRequired();
                entity.Property(x => x.BillTypeId).IsRequired();
                entity.Property(x => x.BillYear).IsRequired();
                entity.Property(x => x.BillSum).IsRequired();
                entity.Property(x => x.BillProviderId).IsRequired();
                entity.Property(x => x.CreatedAt).IsRequired();
            });
        }
    }
}
