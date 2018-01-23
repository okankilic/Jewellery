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
    public class OrderController : CustomApiControllerBase
    {
        //// GET: api/Order
        //public IEnumerable<OrderDTO> Get()
        //{
        //    return OrderBL.GetList(base._DB);
        //}

        // GET: api/Order/5
        public OrderDTO Get(int id)
        {
            return OrderBL.Get(id, base._DB);
        }

        // POST: api/Order
        public int Post([FromBody]OrderDTO order)
        {
            return OrderBL.Create(order, base._DB);
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]OrderDTO order)
        {
            OrderBL.Update(id, order, base._DB);
        }

        // DELETE: api/Order/5
        public void Delete(int id)
        {
            OrderBL.Delete(id, base._DB);
        }
    }
}
