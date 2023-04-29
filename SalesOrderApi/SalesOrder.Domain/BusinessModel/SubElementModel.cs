using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Domain.BusinessModel
{
    public class SubElementModel
    {
        public int SubElementId { get; set; }
        public string Element { get; set; }
        public string Type { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public int WindowId { get; set; }
    }
}
