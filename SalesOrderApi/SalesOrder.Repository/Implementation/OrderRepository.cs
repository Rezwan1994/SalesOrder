using Microsoft.EntityFrameworkCore;
using SalesOrder.Domain.BusinessModel;
using SalesOrder.Domain.DbContexts;
using SalesOrder.Domain.Entities;
using SalesOrder.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Repository.Implementation
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly SalesOrderDbContext _context;
        public OrderRepository(SalesOrderDbContext context) : base(context)
        {
            _context = context;
        }
        public Order GetOrderDetailsByOrderId(int orderId)
        {
            var orders = _context.Orders.Where(x => x.OrderId == orderId).Include(w => w.Windows).ThenInclude(s => s.SubElements).FirstOrDefault();

            return orders;
        }
    }
}
