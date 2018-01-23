using Jewellery.Presentation.WebUI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jewellery.Presentation.WebUI.Controllers
{
    public class CustomerController : CustomControllerBase
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}