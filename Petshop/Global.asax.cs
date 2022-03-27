using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Petshop.Api.Rest
{
    public class WebApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}