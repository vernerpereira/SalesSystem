using AutoMapper;
using SalesSystem.Domain.Entities;
using SalesSystem.MVC.ViewModels;

namespace SalesSystem.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, Product>();
            CreateMap<SaleViewModel, Sale>();
            CreateMap<SaleProductViewModel, SaleProduct>();
        }
    }
}