using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SalesSystem.Domain.Contracts.Services;
using SalesSystem.Domain.Entities;
using SalesSystem.MVC.AutoMapper;
using SalesSystem.MVC.Helpers;
using SalesSystem.MVC.ViewModels;

namespace SalesSystem.MVC.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService _service;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public SaleController(ISaleService service, ICustomerService customerService, IProductService productService)
        {
            _service = service;
            _customerService = customerService;
            _productService = productService;
            _mapper = AutoMapperConfig.Mapper;
        }

        public ActionResult Index(int? parameter)
        {
            var result = _service.Get(Convert.ToInt32(parameter), 5);
            ViewBag.Pagination =
                PaginationHelper.MakePagination(result.Page, result.TotalRows, result.RowsPerPage, "Sale", "Index");
            return View(_mapper.Map<List<SaleViewModel>>(result.Entities));
        }

        public ActionResult Details(int parameter)
        {
            return View(_mapper.Map<SaleViewModel>(_service.Get(parameter)));
        }

        public ActionResult Create()
        {
            ViewBag.CustomerId =
                new SelectList(_customerService.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(SaleViewModel model)
        {
            try
            {
                foreach (var item in Request.Form["products.index"].Split(','))
                {
                    var spvm = new SaleProductViewModel()
                    {
                        ProductId = Convert.ToInt32(item),
                        Quantity = Convert.ToInt32(Request.Form["products[" + item + "].quantity"]),
                        UnitPrice = Convert.ToDecimal(Request.Form["products[" + item + "].unitValue"],
                            CultureInfo.InvariantCulture)
                    };
                    model.SaleProducts.Add(spvm);
                        
                }

                if (!ModelState.IsValid)
                {
                    ViewBag.CustomerId =
                        new SelectList(_customerService.GetAll(), "Id", "Name", model.CustomerId);
                    return View(model);
                }

                _service.Create(_mapper.Map<Sale>(model));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult SearchProduct(string term)
        {
            return Json( _productService.Get(term).Select(p=>new{value=p.Name, id=p.Id, price=p.Price}), JsonRequestBehavior.AllowGet );
        }
        
        public ActionResult Delete(int parameter)
        {
            return View(_mapper.Map<SaleViewModel>(_service.Get(parameter)));
        }

        [HttpPost]
        public ActionResult Delete(int parameter, SaleViewModel model)
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