using Jewellery.Data.JewelleryDBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Jewellery.Presentation.WebApi.Base
{
    public abstract class CustomApiControllerBase: ApiController
    {
        protected JewelleryDBEntities _DB = new JewelleryDBEntities();
    }
}