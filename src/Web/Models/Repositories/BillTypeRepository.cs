using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Entities;

namespace Web.Models.Repositories
{
    public interface IBillTypeRepository
    {
        IEnumerable<BillType> GetBillTypes();
        IEnumerable<BillType> GetBillTypesByName(string billTypeName);
        BillType GetBillType(int id);

    }

    public class BillTypeRepository : IBillTypeRepository
    {
        private readonly UtilitiesContext _context;

        public BillTypeRepository(UtilitiesContext context)
        {
            _context = context;
        }

        public BillType GetBillType(int id)
        {
            return _context.BillTypes.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<BillType> GetBillTypes()
        {
            return _context.BillTypes.ToList();
        }

        public IEnumerable<BillType> GetBillTypesByName(string billTypeName)
        {
            return _context.BillTypes.Where(x => x.TypeName.ToUpper() == billTypeName.ToUpper()).ToList();
        }
    }
}
