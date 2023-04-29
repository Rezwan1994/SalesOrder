using SalesOrder.Domain.BusinessModel;
using SalesOrder.Domain.Entities;
using SalesOrder.Repository;
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
    public class WindowService : BaseService<Window>,IWindowService
    {
        private readonly IRepository<Window> _windowRepository;
        private readonly IWindowRepository _orderExtRepository;
        private readonly IUnitOfWork _unitOfWork;
        public WindowService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _windowRepository = unitOfWork.Repository<Window>();

        }

        public List<Window> GetWindowsByOrderId(int orderId)
        {
            var qry = string.Format("Select * from Windows where OrderId = {0}", orderId);
            return _windowRepository.Query(qry).ToList();
        }
    }
}
