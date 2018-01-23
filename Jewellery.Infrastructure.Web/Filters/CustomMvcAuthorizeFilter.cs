using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Jewellery.Infrastructure.Web.Filters
{
    public class CustomMvcAuthorizeFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public string Roles { get; set; }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = filterContext.HttpContext.User;

            if (user == null)
                filterContext.Result = new HttpUnauthorizedResult();

            var identity = user.Identity;
            if(identity == null)
                filterContext.Result = new HttpUnauthorizedResult();

            if (!identity.IsAuthenticated)
                filterContext.Result = new HttpUnauthorizedResult();

            //if(identity.)

            throw new NotImplementedException();
        }
    }
}
