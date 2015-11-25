using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BillType: IEntityBase
    {
        public BillType()
        {
            Bills = new List<Bill>();
        }
        public int Id { get; set; }
        public string TypeName { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
