using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class BillTypeConfiguration: EntityBaseConfiguration<BillType>
    {
        public BillTypeConfiguration()
        {
            Property(x => x.TypeName).IsRequired().HasMaxLength(50);
        }
    }
}
