using Jewellery.Data.Common.Models;
using Jewellery.Data.JewelleryDBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.Data.Common.Mappers
{
    public static class OrderMapper
    {
        public static Order MapToEntity(OrderDTO order)
        {
            return new Order()
            {
                Id = order.Id,
                AccountId = order.AccountId,
                ProductId = order.ProductId,
                OrderTime = order.OrderTime,
                Price = order.Price,
                Quantity = order.Quantity,
                OrderState = order.OrderState,
                ResponsibleAccountId = order.ResponsibleAccountId,
                Remarks = order.Remarks,
                UpdateTime = order.UpdateTime
            };
        }

        public static OrderDTO MapToDTO(Order order)
        {
            return new OrderDTO()
            {
                Id = order.Id,
                AccountId = order.AccountId,
                AccountFullName = order.Account.FullName,
                ProductId = order.ProductId,
                ProductName = order.Product.Name,
                ProductDescription = order.Product.Description,
                Price = order.Price,
                OrderTime = order.OrderTime,
                Quantity = order.Quantity,
                ResponsibleAccountId = order.ResponsibleAccountId,
                ResponsibleAccountFullName = order.Account1?.FullName,
                OrderState = order.OrderState,
                Remarks = order.Remarks,
                UpdateTime = order.UpdateTime
            };
        }

        public static OrderHistoryDTO MapToHistory(Order order)
        {
            return new OrderHistoryDTO()
            {
                OrderId = order.Id,
                AccountId = order.AccountId,
                ProductId = order.ProductId,
                Price = order.Price,
                Quantity = order.Quantity,
                OrderState = order.OrderState,
                Remarks = order.Remarks,
                OrderTime = order.OrderTime,
                ResponsibleAccountId = order.ResponsibleAccountId,
                //UpdateTime = order.UpdateTime
            };
        }
    }
}
