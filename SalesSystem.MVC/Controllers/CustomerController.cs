using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using SalesSystem.Common.Resources;
using SalesSystem.Domain.Contracts.Services;
using SalesSystem.MVC.AutoMapper;
using SalesSystem.MVC.AutoMapper.Custom;
using SalesSystem.MVC.Helpers;
using SalesSystem.MVC.ViewModels;

namespace SalesSystem.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService service)
        {
            _service = service;
            _mapper = AutoMapperConfig.Mapper;
        }

        public ActionResult Index(int? parameter)
        {
            var result = _service.Get(Convert.ToInt32(parameter), 5);
            ViewBag.Pagination =
                PaginationHelper.MakePagination(result.Page, result.TotalRows, result.RowsPerPage, "Customer", "Index");
            return View(_mapper.Map<List<CustomerViewModel>>(result.Entities));
        }

        public ActionResult Details(int parameter)
        {
            return View(_mapper.Map<CustomerViewModel>(_service.Get(parameter)));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel model)
        {
            try
            {
                CustomValidate(model);
                if (!ModelState.IsValid)
                    return View(model);

                _service.Create(model.ToCustomer());
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        public ActionResult Edit(int parameter)
        {
            return View(_mapper.Map<CustomerViewModel>(_service.Get(parameter)));
        }

        [HttpPost]
        public ActionResult Edit(int parameter, CustomerViewModel model)
        {
            try
            {
                CustomValidate(model);
                if (!ModelState.IsValid)
                    return View(model);

                _service.Update(model.ToCustomer());

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        private void CustomValidate(CustomerViewModel model)
        {
            if(!_service.ValidateEmail(model.Email, model.Id))
                ModelState.AddModelError("Email", Errors.ExistentEmail);
            if (!_service.ValidateCpf(model.Cpf, model.Id))
                ModelState.AddModelError("Cpf", Errors.ExistentCpf);
        }

        public ActionResult Delete(int parameter)
        {
            return View(_mapper.Map<CustomerViewModel>(_service.Get(parameter)));
        }

        [HttpPost]
        public ActionResult Delete(int parameter, CustomerViewModel model)
        {
            try
            {
                _service.Delete(_service.Get(parameter));

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}