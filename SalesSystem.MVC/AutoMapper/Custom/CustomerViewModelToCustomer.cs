using SalesSystem.Domain.Entities;
using SalesSystem.Domain.ValueObjects;
using SalesSystem.MVC.ViewModels;

namespace SalesSystem.MVC.AutoMapper.Custom
{
    public static class CustomerViewModelToCustomer
    {
        public static Customer ToCustomer(this CustomerViewModel model)
        {
            return new Customer(model.Name,
                model.BornDate,
                new Phone(model.Phone.Split(' ')[0].Replace("(", "").Replace(")", ""), model.Phone.Split(' ')[1]),
                new Cpf(model.Cpf.Replace(".", "").Replace("-", "")),
                new Email(model.Email)) {Id = model.Id};
        }
    }
}