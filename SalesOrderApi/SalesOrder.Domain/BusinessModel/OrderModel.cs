using SalesOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Domain.BusinessModel
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public List<Window> Windows { get; set; }
    }
}
