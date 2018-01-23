using Jewellery.BusinessLogic;
using Jewellery.Data.Common.Models;
using Jewellery.Data.JewelleryDBEntities;
using Jewellery.Presentation.WebApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jewellery.Presentation.WebApi.Controllers
{
    public class AccountController : CustomApiControllerBase
    {
        [HttpPost]
        public int Create([FromBody]AccountDTO account)
        {
            return AccountBL.Create(account, base._DB);
        }

        [HttpPost]
        public string Login([FromBody]AccountDTO account)
        {
            return AccountBL.Login(account.MobilePhone, account.Password, base._DB);
        }

        [HttpGet]
        public AccountDTO GetByTokenString(string tokenString)
        {
            return AccountBL.GetByTokenString(tokenString, base._DB);
        }
    }
}
