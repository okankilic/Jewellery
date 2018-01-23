using Jewellery.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Jewellery.Presentation.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //ApiUrlHelper.ApiBaseUrl = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]);
        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    var exception = Server.GetLastError();

        //    //if(exception.GetType() == typeof(HttpException))
        //    //{
        //    //    if (Response.StatusCode == (int)HttpStatusCode.NotFound)
        //    //        Server.Transfer("~/404.html");
        //    //    else if (Response.StatusCode == (int)HttpStatusCode.Unauthorized)
        //    //        Server.Transfer("~/401.html");
        //    //    else
        //    //        Server.Transfer("~/500.html");
        //    //}

        //    Elmah.ErrorSignal.FromCurrentContext().Raise(exception);

        //    Server.ClearError();
        //}
    }
}
