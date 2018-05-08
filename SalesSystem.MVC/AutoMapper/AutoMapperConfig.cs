using AutoMapper;

namespace SalesSystem.MVC.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }
        public static void RegisterMappings()
        {
            var mapper = new MapperConfiguration((map) =>
            {
                map.AddProfile<DomainToViewModelMappingProfile>();
                map.AddProfile<ViewModelToDomainMappingProfile>();
            });

            Mapper = mapper.CreateMapper();
        }
    }
}