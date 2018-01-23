using Jewellery.BusinessLogic;
using Jewellery.Data.Common.Models;
using Jewellery.Data.JewelleryDBEntities;
using Jewellery.Presentation.WebUI.Base;
using Jewellery.Presentation.WebUI.Helpers;
using Jewellery.Presentation.WebUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Jewellery.Presentation.WebUI.Controllers
{
    public class AccountController : CustomControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            var adminAccount = new AccountDTO()
            {
                FullName = ConfigurationManager.AppSettings["AdminFullName"],
                MobilePhone = ConfigurationManager.AppSettings["AdminMobilePhone"],
                Password = ConfigurationManager.AppSettings["AdminPassword"],
                Role = Jewellery.Infrastructure.Core.Constants.Roles.Admin
            };

            var isAdminAccountExists = AccountBL.IsAccountExists(adminAccount, this._DB);
            if (isAdminAccountExists == false)
                AccountBL.Create(adminAccount, this._DB);

            var model = new AccountViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(AccountViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return LoginAndRedirect(model);
        }

        private ActionResult LoginAndRedirect(AccountViewModel model)
        {
            string tokenString = null;

            try
            {
                tokenString = AccountBL.Login(model.MobilePhone, model.Password, this._DB);

                var account = AccountBL.GetByTokenString(tokenString, this._DB);

                var ticket = AuthenticationHelper.CreateTicket(tokenString, account, model.RememberMe);

                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));

                Response.Cookies.Add(authCookie);
            }
            catch
            {
                // Do nothing
            }

            if(string.IsNullOrWhiteSpace(tokenString))
            {
                ModelState.AddModelError("Summary", "Kullanıcı bulunamadı. Kullanıcı adı ve şifrenizi kontrol edip tekrar deneyiniz.");

                return View("Login", model);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return Redirect(FormsAuthentication.DefaultUrl);    
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            var model = new RegisterAccountViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterAccountViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var account = new AccountDTO()
            {
                FullName = model.FullName,
                MobilePhone = model.MobilePhone,
                Password = model.Password,
                Role = Infrastructure.Core.Constants.Roles.Customer
            };

            AccountBL.Create(account, this._DB);

            return RedirectToAction("Login");
        }

        [HttpGet]
        [Authorize(Roles = Infrastructure.Core.Constants.Roles.Admin)]
        public ActionResult Index()
        {
            var model = AccountBL.GetList(base._DB);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = Infrastructure.Core.Constants.Roles.Admin)]
        public ActionResult Create()
        {
            var model = new AccountDTO();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Infrastructure.Core.Constants.Roles.Admin)]
        public ActionResult Create(AccountDTO account)
        {
            if (!ModelState.IsValid)
                return View(account);

            AccountBL.Create(account, base._DB);

            return RedirectToAction("Index");
        }
    }
}