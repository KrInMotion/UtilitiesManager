using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class BillProviderConfiguration: EntityBaseConfiguration<BillProvider>
    {
        public BillProviderConfiguration()
        {
            Property(x => x.ProviderName).IsRequired().HasMaxLength(255);
        }
    }
}
