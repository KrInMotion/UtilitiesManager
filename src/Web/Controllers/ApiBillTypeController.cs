using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Web.Models.Repositories;
using AutoMapper;
using Web.ViewModels;
using System.Net;
using Web.Models.Entities;

namespace Web.Controllers
{
    [Route("api/billtype")]
    public class ApiBillTypeController : Controller
    {
        private readonly IBillTypeRepository _billTypeRepo;

        public ApiBillTypeController(IBillTypeRepository billTypeRepo)
        {
            _billTypeRepo = billTypeRepo;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var model = Mapper.Map<IEnumerable<BillTypeListVM>>(_billTypeRepo.GetBillTypes());
            return Json(model);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]BillTypeFormVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = Mapper.Map<BillType>(vm);
                    _billTypeRepo.SaveBillType(entity);
                    if (_billTypeRepo.Commit())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<BillTypeListVM>(entity));
                    }
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json( new { ErrorMessage = ex.Message });
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Error adding new Bill type ", ModelState = ModelState });
        }

    }
}
