namespace SalesOrderBlazor.Models
{
    public class Window
    {
        public int WindowId { get; set; }
        public string Name { get; set; }
        public string QuantityOfWindows { get; set; }
        public string TotalSubElements { get; set; }
        public int OrderId { get; set; }
        public List<SubElement> SubElements { get; set; }
    }
}
