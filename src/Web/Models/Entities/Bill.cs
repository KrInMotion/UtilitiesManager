using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models.Entities
{
    public class Bill : IEntityBase
    {
        public int Id { get; set; }
        public int BillTypeId { get; set; }
        public virtual BillType BillType { get; set; }
        public int BillProviderId { get; set; }
        public virtual BillProvider BillProvider { get; set; }
        public int MonthId { get; set; }
        public virtual Month Month { get; set; }
        public int BillYear { get; set; }
        public double BillSum { get; set; }
        public double? PaymentSum { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
