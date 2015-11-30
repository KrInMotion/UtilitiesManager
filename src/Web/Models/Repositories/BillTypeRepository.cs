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
        bool Commit();
        void SaveBillType(BillType entity);
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

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void SaveBillType(BillType entity)
        {
            _context.BillTypes.Add(entity);
        }
    }
}
