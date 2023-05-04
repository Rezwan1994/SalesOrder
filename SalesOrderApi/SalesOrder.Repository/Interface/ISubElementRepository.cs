using SalesOrder.Domain.BusinessModel;
using SalesOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Repository.Interface
{
    public interface ISubElementRepository : IRepository<SubElement>
    {
        public List<SubElementModel> GetSubElementByWindowId(int windowId);
    }
}
