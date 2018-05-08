using System.ComponentModel.DataAnnotations;
using SalesSystem.Common.Resources;
using SalesSystem.Domain.Entities;

namespace SalesSystem.MVC.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "NameRequired", AllowEmptyStrings = false)]
        [StringLength(Product.NameMaxLength, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "NameMaxLength")]
        [Display(ResourceType = typeof(Fields), Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "UnitPriceRequired", AllowEmptyStrings = false)]
        [DataType(DataType.Currency)]
        [Display(ResourceType = typeof(Fields), Name = "Price")]
        public decimal Price { get; set; }
    }
}