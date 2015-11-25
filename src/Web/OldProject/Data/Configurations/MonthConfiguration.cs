using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class MonthConfiguration: EntityBaseConfiguration<Month>
    {
        public MonthConfiguration()
        {
            Property(x => x.Name).IsRequired().HasMaxLength(30);
        }
    }
}
