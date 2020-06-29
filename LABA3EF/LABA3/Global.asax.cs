using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using PhonesBook.Core.Repositories;


namespace LABA3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            IKernel kernel = new StandardKernel();
           // kernel.Bind<IUnitOfWork>().To<PhonesBookInfrastructure.EntityFramework.UnitOfWork>().InThreadScope();
            kernel.Bind<IUnitOfWork>().To<PhonesBookInfrastructure.JSON.UnitOfWork>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
