using Jewellery.BusinessLogic;
using Jewellery.Data.Common.Models;
using Jewellery.Presentation.WebApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jewellery.Presentation.WebApi.Controllers
{
    public class ProductController : CustomApiControllerBase
    {
        // GET: api/Product
        public IEnumerable<ProductDTO> Get()
        {
            return ProductBL.GetList(base._DB);
        }

        // GET: api/Product/5
        public ProductDTO Get(int id)
        {
            return ProductBL.Get(id, base._DB);
        }

        // POST: api/Product
        public int Post([FromBody]ProductDTO product)
        {
            return ProductBL.Create(product, base._DB);
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]ProductDTO product)
        {
            ProductBL.Update(id, product, base._DB);
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
            ProductBL.Delete(id, base._DB);
        }
    }
}
