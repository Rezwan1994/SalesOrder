using SalesOrder.Domain.BusinessModel;
using SalesOrder.Domain.Entities;
using SalesOrder.Repository.Implementation;
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
    public class SubElementService : BaseService<SubElement>,ISubElementService
    {
        private readonly IRepository<SubElement> _subElementRepository;
        private readonly ISubElementRepository _subElementExtRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SubElementService(IUnitOfWork unitOfWork, ISubElementRepository subElementExtRepository)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _subElementRepository = unitOfWork.Repository<SubElement>();
            _subElementExtRepository = subElementExtRepository;

        }
        public List<SubElementModel> GetSubElementByWindowId(int windowId)
        {
            return _subElementExtRepository.GetSubElementByWindowId(windowId);
        }
    }
}
