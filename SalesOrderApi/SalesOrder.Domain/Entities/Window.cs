using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Domain.Entities
{
    public class Window
    {
        [Key]
        public int WindowId { get; set; }
        public string Name { get; set; }
        public string QuantityOfWindows { get; set; }
        public string TotalSubElements { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public ICollection<SubElement> SubElements { get; set; }
    }
}
