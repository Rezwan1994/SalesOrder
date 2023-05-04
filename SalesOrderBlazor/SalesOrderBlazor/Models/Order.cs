using System.ComponentModel.DataAnnotations;

namespace SalesOrderBlazor.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string State { get; set; }
        public List<Window> Windows { get; set; }
    }
}
