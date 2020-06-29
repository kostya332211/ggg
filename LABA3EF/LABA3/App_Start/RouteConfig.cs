using System.Web.Mvc;
using System.Web.Routing;

namespace LABA3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Dict",
                url: "{controller}/{action}",
                defaults: new { controller = "Dict", action = "Index" }
            );
        }
    }
}
