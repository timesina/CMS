using Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Stage.Api.Controllers
{



    public class HomeController : Controller
    {

        public HomeController()
        {
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
