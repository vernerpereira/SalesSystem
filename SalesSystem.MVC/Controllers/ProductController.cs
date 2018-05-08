using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using SalesSystem.Domain.Contracts.Services;
using SalesSystem.Domain.Entities;
using SalesSystem.MVC.AutoMapper;
using SalesSystem.MVC.Helpers;
using SalesSystem.MVC.ViewModels;

namespace SalesSystem.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductController(IProductService service)
        {
            _service = service;
            _mapper = AutoMapperConfig.Mapper;
        }

        public ActionResult Index(int? parameter)
        {
            var result = _service.Get(Convert.ToInt32(parameter), 5);
            ViewBag.Pagination =
                PaginationHelper.MakePagination(result.Page, result.TotalRows, result.RowsPerPage, "Product", "Index");
            return View(_mapper.Map<List<ProductViewModel>>(result.Entities));
        }
        
        public ActionResult Details(int parameter)
        {
            return View(_mapper.Map<ProductViewModel>(_service.Get(parameter)));
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                _service.Create(_mapper.Map<Product>(model));
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
            return View(_mapper.Map<ProductViewModel>(_service.Get(parameter)));
        }
        
        [HttpPost]
        public ActionResult Edit(int parameter, ProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                
                _service.Update(_mapper.Map<Product>(model));

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
        
        public ActionResult Delete(int parameter)
        {
            return View(_mapper.Map<ProductViewModel>(_service.Get(parameter)));
        }
        
        [HttpPost]
        public ActionResult Delete(int parameter, ProductViewModel model)
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
