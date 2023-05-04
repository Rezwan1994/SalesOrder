using System.ComponentModel.DataAnnotations;

namespace SalesOrderBlazor.Models
{
    public class Window
    {
        public int WindowId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int QuantityOfWindows { get; set; }
        public int TotalSubElements { get; set; }
        public int OrderId { get; set; }
        public List<SubElement> SubElements { get; set; }
    }
}
