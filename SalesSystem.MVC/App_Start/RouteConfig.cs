using System.Web.Mvc;
using System.Web.Routing;

namespace SalesSystem.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{parameter}",
                defaults: new { controller = "Sale", action = "Index", parameter = UrlParameter.Optional }
            );
        }
    }
}
