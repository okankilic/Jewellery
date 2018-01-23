using Jewellery.BusinessLogic;
using Jewellery.Data.JewelleryDBEntities;
using Jewellery.Infrastructure.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jewellery.Presentation.WebUI.Helpers
{
    public static class SelectHelper
    {
        public static IEnumerable<SelectListItem> GetRoleList()
        {
            var roles = Infrastructure.Core.Constants.Roles.GetRoleList();

            return roles.Select(q => new SelectListItem()
            {
                Text = q,
                Value = q
            });
        }

        public static IEnumerable<SelectListItem> GetAccountList(string orderState)
        {
            var db = new JewelleryDBEntities();

            var accounts = AccountBL.GetList(db);

            var state = (OrderStates)Enum.Parse(typeof(OrderStates), orderState);

            string role = null;

            switch(state)
            {
                case OrderStates.WAITING:
                    role = Infrastructure.Core.Constants.Roles.Boiler;
                    break;

                case OrderStates.STONECUTTER:
                    role = Infrastructure.Core.Constants.Roles.StoneCutter;
                    break;

                case OrderStates.POLISHER:
                    role = Infrastructure.Core.Constants.Roles.Polisher;
                    break;
            }

            return accounts.Where(q => q.Role == role).Select(q => new SelectListItem()
            {
                Text = q.FullName,
                Value = q.Id.ToString()
            });
        }
    }
}