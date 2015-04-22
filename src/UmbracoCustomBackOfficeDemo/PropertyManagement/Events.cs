using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;
using UmbracoCustomBackOfficeDemo.PropertyManagement.Controllers;

namespace UmbracoCustomBackOfficeDemo.PropertyManagement
{
    public class Events : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            RouteTable.Routes.MapRoute("PropertyManagement.Default", "umbraco/property-management/{controller}/{action}",
                new { action = "Index" },
                new[] {typeof (AgentsController).Namespace});
        }
    }
}