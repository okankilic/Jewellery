using Jewellery.BusinessLogic;
using Jewellery.Data.Common.Models;
using Jewellery.Infrastructure.Core.Constants;
using Jewellery.Infrastructure.Core.Enums;
using Jewellery.Presentation.WebUI.Base;
using Jewellery.Presentation.WebUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jewellery.Presentation.WebUI.Controllers
{
    public class OrderController : CustomControllerBase
    {
        // GET: Order
        public ActionResult Index()
        {
            var model = OrderBL.GetList(base._DB);

            if(User.IsInRole(Roles.Customer))
            {
                var tokenString = AuthenticationHelper.GetTokenString(HttpContext);
                var account = AccountBL.GetByTokenString(tokenString, base._DB);

                model = model.Where(q => q.AccountId == account.Id);
            }
            else if(User.IsInRole(Roles.Polisher) || User.IsInRole(Roles.StoneCutter) || User.IsInRole(Roles.Boiler))
            {
                var tokenString = AuthenticationHelper.GetTokenString(HttpContext);
                var account = AccountBL.GetByTokenString(tokenString, base._DB);

                model = model.Where(q => q.ResponsibleAccountId == account.Id);
            }

            return View(model);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        [Authorize(Roles = Roles.Customer)]
        public ActionResult Create(int productId)
        {
            var tokenString = AuthenticationHelper.GetTokenString(HttpContext);
            var account = AccountBL.GetByTokenString(tokenString, base._DB);
            var product = ProductBL.Get(productId, base._DB);

            var model = new OrderDTO()
            {
                AccountId = account.Id,
                ProductId = product.Id,
                ProductName = product.Name,
                ProductDescription = product.Description,
                Price = product.Price,
                OrderState = OrderStates.WAITING.ToString()
            };

            return View(model);
        }

        // POST: Order/Create
        [HttpPost]
        [Authorize(Roles = Roles.Customer)]
        public ActionResult Create(OrderDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);

            OrderBL.Create(model, base._DB);

            return RedirectToAction("Index", "Product");
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public ActionResult _Assign(int id)
        {
            var model = OrderBL.Get(id, base._DB);

            return PartialView(model);
        }

        [HttpGet]
        [Authorize(Roles = Roles.AdminOrCustomer)]
        public ActionResult Cancel(int id)
        {
            OrderBL.Cancel(id, base._DB);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = Roles.AdminAndStaff)]
        public ActionResult ChangeState(OrderDTO model)
        {
            OrderBL.ChangeState(model.Id, model.ResponsibleAccountId, base._DB);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = Roles.Staff)]
        public ActionResult Complete(int id)
        {
            OrderBL.ChangeState(id, null, base._DB);

            return RedirectToAction("Index");
        }
    }
}
