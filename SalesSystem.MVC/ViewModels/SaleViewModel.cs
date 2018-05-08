using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SalesSystem.Common.Resources;

namespace SalesSystem.MVC.ViewModels
{
    public class SaleViewModel
    {
        public SaleViewModel()
        {
            SaleProducts = new List<SaleProductViewModel>();
        }

        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(ResourceType = typeof(Fields), Name = "SaleDate")]
        public DateTime PersistDate { get; set; }

        [Display(ResourceType = typeof(Fields), Name = "OrderNumber")]
        public string OrderNumber { get; set; }

        [Display(ResourceType = typeof(Fields), Name = "Customer")]
        public int CustomerId { get; set; }

        public virtual CustomerViewModel Customer { get; set; }
        public virtual ICollection<SaleProductViewModel> SaleProducts { get; set; }

        [Display(ResourceType = typeof(Fields), Name = "TotalSale")]
        public virtual decimal TotalSale => SaleProducts.Sum(sp => sp.TotalPrice);
    }
}