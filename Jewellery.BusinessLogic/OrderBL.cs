using Jewellery.Data.Common.Mappers;
using Jewellery.Data.Common.Models;
using Jewellery.Data.JewelleryDBEntities;
using Jewellery.Infrastructure.Core.Constants;
using Jewellery.Infrastructure.Core.Enums;
using Jewellery.Infrastructure.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.BusinessLogic
{
    public static class OrderBL
    {
        public static int Create(OrderDTO order, JewelleryDBEntities db)
        {
            var newOrder = OrderMapper.MapToEntity(order);

            newOrder.OrderTime = DateTime.Now;
            newOrder.UpdateTime = DateTime.Now;

            db.Order.Add(newOrder);

            db.SaveChanges();

            return newOrder.Id;
        }

        public static void Update(int id, OrderDTO order, JewelleryDBEntities db)
        {
            throw new NotImplementedException();
        }

        public static void Delete(int id, JewelleryDBEntities db)
        {
            throw new NotImplementedException();
        }

        public static OrderDTO Get(int id, JewelleryDBEntities db)
        {
            var order = db.Order.Single(q => q.Id == id);

            return OrderMapper.MapToDTO(order);
        }
        
        public static IEnumerable<OrderDTO> GetList(JewelleryDBEntities db)
        {
            return db.Order.ToList().Select(q => OrderMapper.MapToDTO(q));
        }

        public static void ChangeState(int id, int? responsibleAccountId, JewelleryDBEntities db)
        {
            var order = db.Order.Single(q => q.Id == id);

            if(order.OrderState == OrderStates.READY.ToString() || order.OrderState == OrderStates.CANCELLED.ToString())
                throw new BusinessException("Bu sipariş zaten hazırlanmıştır. Sipariş: {0}", order.Id);

            var orderState = (OrderStates)Enum.Parse(typeof(OrderStates), order.OrderState);
            var nexState = orderState;

            AccountDTO responsibleAccount = null;

            switch (orderState)
            {
                case OrderStates.WAITING:
                case OrderStates.BOILER:
                case OrderStates.STONECUTTER:
                case OrderStates.POLISHER:
                    {
                        if (responsibleAccountId != null)
                        {
                            responsibleAccount = AccountBL.TryGet(responsibleAccountId.Value, db);
                            if (responsibleAccount == null)
                                throw new BusinessException("Yönlendirilecek hesap bilgisi bulunamadı.");
                        }
                    }
                    break;
            }

            switch (orderState)
            {
                case OrderStates.WAITING:
                    {
                        if (responsibleAccount.Role != Roles.Boiler)
                            throw new BusinessException("Sipariş bu hesaba atanamaz.");

                        nexState = OrderStates.BOILER;
                    }
                    break;

                case OrderStates.BOILER:
                    {
                        if(responsibleAccount == null)
                            nexState = OrderStates.STONECUTTER;
                        else
                        {
                            if (responsibleAccount.Role != Roles.StoneCutter)
                                throw new BusinessException("Sipariş bu hesaba atanamaz.");
                        }
                    }
                    break;

                case OrderStates.STONECUTTER:
                    {
                        if(responsibleAccount == null)
                            nexState = OrderStates.POLISHER;
                        else
                        {
                            if (responsibleAccount.Role != Roles.StoneCutter)
                                throw new BusinessException("Sipariş bu hesaba atanamaz.");
                        }
                    }
                    break;

                case OrderStates.POLISHER:
                    {
                        if(responsibleAccount == null)
                            nexState = OrderStates.READY;
                        else
                        {
                            if (responsibleAccount.Role != Roles.Polisher)
                                throw new BusinessException("Sipariş bu hesaba atanamaz.");
                        }
                    }
                    break;
            }

            using (var ts = db.Database.BeginTransaction())
            {
                try
                {
                    var orderHistory = OrderMapper.MapToHistory(order);

                    orderHistory.UpdateTime = DateTime.Now;

                    OrderHistoryBL.Create(orderHistory, db);

                    order.ResponsibleAccountId = responsibleAccountId;
                    order.OrderState = nexState.ToString();
                    order.UpdateTime = DateTime.Now;

                    db.SaveChanges();

                    ts.Commit();
                }
                catch (Exception)
                {
                    ts.Rollback();
                    throw;
                }
            }
        }

        public static void Cancel(int id, JewelleryDBEntities db)
        {
            var order = db.Order.Single(q => q.Id == id);

            if (order.OrderState != OrderStates.WAITING.ToString())
                throw new BusinessException("Bu sipariş iptal edilemez. Sipariş: {0}", order.Id);

            using (var ts = db.Database.BeginTransaction())
            {
                try
                {
                    var orderHistory = OrderMapper.MapToHistory(order);

                    orderHistory.UpdateTime = DateTime.Now;

                    OrderHistoryBL.Create(orderHistory, db);

                    order.OrderState = OrderStates.CANCELLED.ToString();

                    db.SaveChanges();

                    ts.Commit();
                }
                catch (Exception)
                {
                    ts.Rollback();
                    throw;
                }
            }
            
        }
    }
}
