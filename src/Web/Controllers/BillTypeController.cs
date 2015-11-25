using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Web.Models.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    public class BillTypeController : Controller
    {
        private readonly IBillTypeRepository _billTypeRepo;

        public BillTypeController(IBillTypeRepository billTypeRepo)
        {
            _billTypeRepo = billTypeRepo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = _billTypeRepo.GetBillTypes();
            return View();
        }
    }
}
