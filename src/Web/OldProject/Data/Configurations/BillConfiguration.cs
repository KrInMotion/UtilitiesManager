using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class BillConfiguration: EntityBaseConfiguration<Bill>
    {
        public BillConfiguration()
        {
            Property(x => x.MonthId).IsRequired();
            Property(x => x.BillTypeId).IsRequired();
            Property(x => x.BillYear).IsRequired();
            Property(x => x.BillSum).IsRequired();
            Property(x => x.BillProviderId).IsRequired();
            Property(x => x.PaymentSum).IsOptional();
            Property(x => x.PaymentDate).IsOptional();
            Property(x => x.CreatedAt).IsRequired();
            Property(x => x.UpdatedAt).IsOptional();
        }
    }
}
