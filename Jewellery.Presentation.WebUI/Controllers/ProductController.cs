using Jewellery.BusinessLogic;
using Jewellery.Data.Common.Models;
using Jewellery.Presentation.WebUI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jewellery.Presentation.WebUI.Controllers
{
    public class ProductController : CustomControllerBase
    {
        // GET: Product
        [Authorize(Roles = Infrastructure.Core.Constants.Roles.AdminOrCustomer)]
        public ActionResult Index()
        {
            var model = ProductBL.GetList(base._DB);

            return View(model);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        [Authorize(Roles = Infrastructure.Core.Constants.Roles.Admin)]
        public ActionResult Create()
        {
            var model = new ProductDTO();

            return View(model);
        }

        // POST: Product/Create
        [HttpPost]
        [Authorize(Roles = Infrastructure.Core.Constants.Roles.Admin)]
        public ActionResult Create(ProductDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);

            ProductBL.Create(model, base._DB);

            return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
    }
}
