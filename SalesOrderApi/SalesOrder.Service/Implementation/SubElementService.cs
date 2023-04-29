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
    public class SubElementService : BaseService<SubElement>,ISubElementService
    {
        private readonly IRepository<SubElement> _subElementRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SubElementService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _subElementRepository = unitOfWork.Repository<SubElement>();

        }

        public List<SubElement> GetSubElementByWindowId(int windowId)
        {
            var qry = string.Format("Select * from SubElements where WindowId = {0}", windowId);
            return _subElementRepository.Query(qry).ToList();
        }
    }
}
