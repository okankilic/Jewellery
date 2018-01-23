using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jewellery.Presentation.WebUI.Filters
{
    public class CustomHandleErrorAttribute: HandleErrorAttribute
    {
        protected Logger _Logger = LogManager.GetCurrentClassLogger();

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
                return;

            filterContext.ExceptionHandled = true;

            var exception = filterContext.Exception;

            if (exception.InnerException != null)
                exception = exception.InnerException;

            Elmah.ErrorSignal.FromCurrentContext().Raise(exception);

            filterContext.HttpContext.Response.Redirect("~/500.html");
        }
    }
}