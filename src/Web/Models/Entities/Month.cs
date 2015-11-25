using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models.Entities
{
    public class Month : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
