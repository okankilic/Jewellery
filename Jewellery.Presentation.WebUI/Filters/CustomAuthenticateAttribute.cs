using Jewellery.BusinessLogic;
using Jewellery.Data.Common.Models;
using Jewellery.Data.JewelleryDBEntities;
using Jewellery.Infrastructure.Core;
using Jewellery.Presentation.WebUI.Helpers;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Security;

namespace Jewellery.Presentation.WebUI.Filters
{
    public class CustomAuthenticateAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (IsAnonymousAction(filterContext.ActionDescriptor) == true)
                return;

            FormsAuthenticationTicket ticket = null;

            try
            {
                ticket = AuthenticationHelper.GetTicket(filterContext.HttpContext);
            }
            catch (Exception ex)
            {
                logger.Debug(ex, "An error occured and supressed while trying to get FormsAuthentication ticket");

                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            var userData = AuthenticationHelper.GetUserData(filterContext.HttpContext);

            AccountDTO account = null;

            try
            {
                var db = new JewelleryDBEntities();
                account = AccountBL.GetByTokenString(userData.TokenString, db);
            }
            catch (Exception exc)
            {
                logger.Debug(exc, "Exception occured and suppressed while checking for authentication by token");
            }

            if (account == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            ticket = AuthenticationHelper.CreateTicket(userData.TokenString, account, ticket?.IsPersistent ?? true);

            var identity = new FormsIdentity(ticket);

            filterContext.Principal = new GenericPrincipal(identity, new string[] { account.Role });
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (IsAnonymousAction(filterContext.ActionDescriptor) == true)
                return;

            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
                filterContext.Result = new RedirectResult(FormsAuthentication.LoginUrl + "?returnUrl=" + filterContext.HttpContext.Request.Path);
        }

        private bool IsAnonymousAction(ActionDescriptor actionDescriptor)
        {
            return actionDescriptor.GetCustomAttributes(inherit: true).OfType<AllowAnonymousAttribute>().Any();
        }
    }
}