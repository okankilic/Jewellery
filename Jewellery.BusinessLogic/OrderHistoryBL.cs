using Jewellery.Data.Common.Mappers;
using Jewellery.Data.Common.Models;
using Jewellery.Data.JewelleryDBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.BusinessLogic
{
    public static class OrderHistoryBL
    {
        public static int Create(OrderHistoryDTO orderHistory, JewelleryDBEntities db)
        {
            var newOrderHistory = OrderHistoryMapper.MapToEntity(orderHistory);

            db.OrderHistory.Add(newOrderHistory);

            db.SaveChanges();

            return newOrderHistory.HID;
        }
    }
}
