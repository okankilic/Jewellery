using Jewellery.Data.JewelleryDBEntities;
using Jewellery.Infrastructure.Core.Constants;
using Jewellery.Presentation.WebUI.Filters;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Jewellery.Presentation.WebUI.Base
{
    [CustomAuthenticate]
    [Authorize(Roles = Roles.Any)]
    public abstract class CustomControllerBase: Controller
    {
        //private HttpClient _HttpClient = new HttpClient();

        protected Logger _Logger = LogManager.GetCurrentClassLogger();

        protected JewelleryDBEntities _DB = new JewelleryDBEntities();
    }
}