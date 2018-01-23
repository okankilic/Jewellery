using Jewellery.Data.Common.Models;
using Jewellery.Data.JewelleryDBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.Data.Common.Mappers
{
    public static class OrderHistoryMapper
    {
        public static OrderHistory MapToEntity(OrderHistoryDTO orderHistory)
        {
            return new OrderHistory()
            {
                HID = orderHistory.HID,
                OrderId = orderHistory.OrderId,
                AccountId = orderHistory.AccountId,
                ProductId = orderHistory.ProductId,
                Price = orderHistory.Price,
                Quantity = orderHistory.Quantity,
                OrderState = orderHistory.OrderState,
                ResponsibleAccountId = orderHistory.ResponsibleAccountId,
                Remarks = orderHistory.Remarks,
                UpdateTime = DateTime.Now
            };
        }
    }
}
