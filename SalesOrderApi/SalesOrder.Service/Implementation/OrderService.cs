using SalesOrder.Domain.BusinessModel;
using SalesOrder.Domain.Entities;
using SalesOrder.Repository.Interface;
using SalesOrder.Repository.UnitOfWork;
using SalesOrder.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Service.Implementation
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = unitOfWork.Repository<Order>();
        
        }

        public OrderModel GetOrderDetailsByOrderId(int orderId)
        {
        
            return null;
        }
    }
}
