namespace SalesOrderBlazor.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public List<Window> Windows { get; set; }
    }
}
