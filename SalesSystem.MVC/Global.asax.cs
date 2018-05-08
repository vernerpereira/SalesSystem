using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common.WebHost;
using SalesSystem.Business.Services;
using SalesSystem.Domain.Contracts.Repositories;
using SalesSystem.Domain.Contracts.Services;
using SalesSystem.Infrastructure.Data.Repositories;
using SalesSystem.MVC.AutoMapper;

namespace SalesSystem.MVC
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        private void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<ISaleRepository>().To<SaleRepository>();

            kernel.Bind<ICustomerService>().To<CustomerService>();
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<ISaleService>().To<SaleService>();
        }
    }
}
