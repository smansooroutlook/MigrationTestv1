using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace MVC.Helper
{
    public static class IApplicationBuilderExtension
    {
        public static IApplicationBuilder UseAddMVCConfig(this IApplicationBuilder app)
        {

            app.UseMvc(routes =>
            //routes.MapDelete("{resource}.axd/{*pathInfo}");

            // home and error page

            //routes.MapRoute("", "", new { area = "", controller = "Home", action = "Index" }),
            //routes.MapRoute("", "error", new { area = "", controller = "Home", action = "Error" }),                            
            {
                routes.MapRoute(name: "error", template: "{controller=Home}/{action=Error}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //routes.MapAreaRoute(
                //    name: "shopping",
                //    areaName: "shopping",
                //    template: "Shop/{controller=Shop}/{action=Shopping}");

                //routes.MapRoute(
                //    name: "default1",
                //    template: "{controller=Home}/{action=Index}/{id?}",
                //    defaults: new { area = "" }
                //    );


                routes.MapRoute(
                    name: "Shop",                    
                    template: "{controller=Shop}/{action}",
                    defaults: new { area = "Areas" }
                    );

                routes.MapAreaRoute(
                    name: "Products",
                    areaName: "products",
                    template: "{controller=Shop}/{action=products}");


            }
                    );


            return app;
        }

    }
}


