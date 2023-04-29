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
        public List<OrderModel> GetOrderDetailsByOrderId(int orderId)
        {

            //var order = _orderRe
            ////OrderModel model = new OrderModel();

            ////string rawQuery = @"select * from Students s
            ////                left join StudentClassMaps sm on sm.StudentId = s.StudentId
            ////                left join Classes c on c.ClassId = '{0}'";
            ////string sqlQuery = string.Format(rawQuery, classId);
            ////var orderList = _context.or
            ////var studentList = _context.ExecSQL<Student>(sqlQuery).ToList();

            return null;
        }
    }
}
