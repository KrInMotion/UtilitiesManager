using AutoMapper;
using Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class BillTypeController : Controller
    {
        private readonly IBillTypeService _billTypeService;

        public BillTypeController(IBillTypeService billTypeService)
        {
            _billTypeService = billTypeService;
        }

        // GET: BillType/Index
        public ActionResult Index()
        {
            var model =  Mapper.Map<IEnumerable<BillType>, IEnumerable<BillTypeViewModel>>(_billTypeService.GetBillTypes());
            return View(model);
        }

        //GET: BillType/Edit/{id}
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var entity = _billTypeService.GetBillType(id);
            if (entity == null)
                return HttpNotFound();
            var model = Mapper.Map<BillType, BillTypeFormModel>(entity);
            return View(model);
        }

        //POST: BillType/Edit/{id}
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(BillTypeFormModel model)
        {
            var entity = _billTypeService.GetBillType(model.Id);
            if (entity == null)
                return HttpNotFound();
            if(ModelState.IsValid)
            {
                if(_billTypeService.GetBillTypesByName(model.TypeName).Count()>0)
                {
                    ModelState.AddModelError("", "Введенное наименование уже существует, введите другое.");
                    return View(model);
                }
                entity.TypeName = model.TypeName;
                _billTypeService.SaveBillType();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //GET: BillType/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new BillTypeFormModel();
            return View(model);
        }

        //POST: BillType/Create/
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(BillTypeFormModel model)
        {
            if (ModelState.IsValid)
            {
                if (_billTypeService.GetBillTypesByName(model.TypeName).Count() > 0)
                {
                    ModelState.AddModelError("", "Введенное наименование уже существует, введите другое.");
                    return View(model);
                }
                var entity = Mapper.Map<BillType>(model);
                _billTypeService.CreateBillType(entity);
                _billTypeService.SaveBillType();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}