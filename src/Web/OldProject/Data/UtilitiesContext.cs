using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UtilitiesContext: DbContext
    {
        public UtilitiesContext(): base("UtilitiesManager")
        {
            //Database.SetInitializer<UtilitiesContext>(null);
        }
        public DbSet<Month> MonthSet { get; set; }
        public DbSet<BillType> BillTypeSet { get; set; }
        public DbSet<BillProvider> BillProviderSet { get; set; }
        public DbSet<Bill> BillSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new Configurations.BillTypeConfiguration());
            modelBuilder.Configurations.Add(new Configurations.MonthConfiguration());
            modelBuilder.Configurations.Add(new Configurations.BillProviderConfiguration());
            modelBuilder.Configurations.Add(new Configurations.BillConfiguration());
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }

}
