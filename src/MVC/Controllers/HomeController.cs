using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Mvc.Controllers
{
    // renders home page only

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          //  ViewBag.Crumbs = new List<BreadCrumb>();
          //  ViewBag.Crumbs.Add(new BreadCrumb { Title = "home" });

            ViewBag.Menu = "home";

            return View();
        }
    }
}
