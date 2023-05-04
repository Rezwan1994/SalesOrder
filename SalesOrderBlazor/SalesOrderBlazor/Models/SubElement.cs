using System.ComponentModel.DataAnnotations;

namespace SalesOrderBlazor.Models
{
    public class SubElement
    {
        [Required]
        public int SubElementId { get; set; }
        [Required]
        public string Element { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
        public int WindowId { get; set; }
    }
}
