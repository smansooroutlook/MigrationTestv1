using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mvc.Code
{
    // sets selected menu item

    public class MenuAttribute : ActionFilterAttribute
    {
        MenuItem selectedMenu;

        public MenuAttribute(MenuItem selectedMenu)
        {
            this.selectedMenu = selectedMenu;
        }

        // sets selected menu in ViewData

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ((Controller)filterContext.Controller).ViewBag["SelectedMenu"] = selectedMenu.ToString().ToLower();
        }
    }
}