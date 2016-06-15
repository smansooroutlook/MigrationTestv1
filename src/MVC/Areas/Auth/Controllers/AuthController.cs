using ActionService;
using Microsoft.AspNetCore.Mvc;
using Mvc.Areas.Auth.Models;

namespace Mvc.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class AuthController : Controller
    {
        IService service { get; set; }

        // default constructor
        public AuthController() : this(new Service()) { }

        // overloaded 'injectable' constructor
        // ** Constructor Dependency Injection (DI).
        public AuthController(IService service) { this.service = service; }

        // login page

        [HttpGet]
        public ActionResult Login()
        {
            //ViewBag.Crumbs = new List<BreadCrumb>();
            //ViewBag.Crumbs.Add(new BreadCrumb { Title = "home", Url = "/" });
            //ViewBag.Crumbs.Add(new BreadCrumb { Title = "login" });

            ViewBag.Menu = "login";

            var model = new LoginModel();
            return View(model);
        }

        // login post back

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (service.Login(model.Email, model.Password))
                {
                    if (!string.IsNullOrEmpty(returnUrl)) return Redirect(returnUrl);

                    return RedirectToAction("Administration", "Admin", new { area = "Admin" });
                }
            }

            ModelState.AddModelError("", "The email and/or password are incorrect.");

            //ViewBag.Crumbs = new List<BreadCrumb>();
            //ViewBag.Crumbs.Add(new BreadCrumb { Title = "home", Url = "/" });
            //ViewBag.Crumbs.Add(new BreadCrumb { Title = "login" });

            ViewBag.Menu = "login";

            return View(model);
        }

        // logout page

        [HttpGet]
        public ActionResult Logout()
        {
            //ViewBag.Crumbs = new List<BreadCrumb>();
            //ViewBag.Crumbs.Add(new BreadCrumb { Title = "home", Url = "/" });
            //ViewBag.Crumbs.Add(new BreadCrumb { Title = "logout" });

            ViewBag.Menu = "home";

            service.Logout();

            return View();
        }
    }
}
