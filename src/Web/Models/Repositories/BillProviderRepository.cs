using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Entities;

namespace Web.Models.Repositories
{
    public interface IBillProviderRepository
    {
        List<BillProvider> GetBillProviders();
    }

    public class BillProviderRepository: IBillProviderRepository
    {
        private readonly UtilitiesContext _context;

        public BillProviderRepository(UtilitiesContext context)
        {
            _context = context;
        }

        public List<BillProvider> GetBillProviders()
        {
            return _context.BillProviders.ToList();
        }
    }
}
