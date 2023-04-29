using SalesOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Service.Interface
{
    public interface ISubElementService : IBaseService<SubElement>
    {
        public List<SubElement> GetSubElementByWindowId(int windowId);
    }
}
