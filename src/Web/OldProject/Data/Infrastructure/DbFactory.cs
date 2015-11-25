using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        UtilitiesContext _context;
        public UtilitiesContext Init()
        {
            return _context ?? (_context = new UtilitiesContext());
        }

        protected override void DisposeCore()
        {
            if(_context !=null)
            {
                _context.Dispose();
            }
        }
    }
}
