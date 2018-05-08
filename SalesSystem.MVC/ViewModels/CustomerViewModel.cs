using System;
using System.ComponentModel.DataAnnotations;
using SalesSystem.Common.Resources;
using SalesSystem.Domain.Entities;

namespace SalesSystem.MVC.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "NameRequired", AllowEmptyStrings = false)]
        [StringLength(Product.NameMaxLength, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "NameMaxLength")]
        [Display(ResourceType = typeof(Fields), Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "BornDateRequired", AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(Fields), Name = "BornDate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BornDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "PhoneRequired", AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(Fields), Name = "Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "CpfRequired", AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(Fields), Name = "Cpf")]
        public string Cpf { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "EmailRequired", AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(Fields), Name = "Email")]
        public string Email { get; set; }

        [Display(ResourceType = typeof(Fields), Name = "Age")]
        public virtual int Age { get; set; }
    }
}