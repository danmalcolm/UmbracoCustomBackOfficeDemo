using System.Web.Mvc;

namespace UmbracoCustomBackOfficeDemo.PropertyManagement.Controllers
{
    public class AgentsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var agent = new Agent {Id = id, Name = "Agent " + id};
            return View(agent);
        }

    }
}