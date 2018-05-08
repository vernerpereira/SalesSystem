using AutoMapper;
using SalesSystem.Domain.Entities;
using SalesSystem.MVC.ViewModels;

namespace SalesSystem.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(a => a.Phone,
                    b => b.MapFrom( c=>c.Phone.GetFullPhone()
                    ))
                .ForMember(a=>a.Cpf,
                    b=>b.MapFrom(c=>c.Cpf.GetFormated()
                    ))
                .ForMember(a=>a.Email,
                    b=>b.MapFrom(c=>c.Email.Address
                    ));
            

            CreateMap<Sale, SaleViewModel>();
            CreateMap<SaleProduct, SaleProductViewModel>();
        }
    }
}