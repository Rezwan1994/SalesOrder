using SalesOrder.Domain.BusinessModel;
using SalesOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Repository.Interface
{
    public interface IOrderRepository:IRepository<Order>
    {
        public Order GetOrderDetailsByOrderId(int orderId);
    }
}
