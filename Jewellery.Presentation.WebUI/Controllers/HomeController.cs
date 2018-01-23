using Jewellery.Infrastructure.Core.Constants;
using Jewellery.Presentation.WebUI.Base;
using Jewellery.Presentation.WebUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jewellery.Presentation.WebUI.Controllers
{
    public class HomeController : CustomControllerBase
    {
        public ActionResult Index()
        {
            if(User.IsInRole(Roles.Customer))
            {
                return RedirectToAction("Index", "Product");
            }
            else if (User.IsInRole(Roles.Boiler) || User.IsInRole(Roles.Polisher) || User.IsInRole(Roles.StoneCutter))
            {
                return RedirectToAction("Index", "Order");
            }
            else if (User.IsInRole(Roles.Admin))
            {
                return RedirectToAction("Index", "Order");
            }

            return View();
        }
    }
}