using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesOrder.Domain.BusinessModel;
using SalesOrder.Domain.Entities;
using SalesOrder.Service.Interface;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SalesOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        private IWindowService _windowService;
        private ISubElementService _subElementService;
        public OrderController(IOrderService orderService, IWindowService windowService, ISubElementService subElementService)
        {
            _orderService = orderService;
            _windowService = windowService;
            _subElementService = subElementService;
        }

        [HttpPost("createOrder")]
        public async Task<ActionResult<bool>> CreateOrder(Order order)
        {
            try
            {
                if (order != null)
                {
                    order.Name = "Testing";
                    order.State = "CAaa";
                    List<Window> windowList = new List<Window>();
                    Window win = new Window();
                    win.Name = "Testdd";
                    win.TotalSubElements = "3";
                    win.QuantityOfWindows = "4";
                    List<SubElement> subList = new List<SubElement>();
                    SubElement sub = new SubElement();
                    sub.Element = "Testsdfsdf";
                    sub.Height = "1sdf";
                    sub.Width = "1df";
                    sub.Type = "door";
                    subList.Add(sub);
                    win.SubElements = subList;
                    windowList.Add(win);
                    order.Windows = windowList;
                    
                    _orderService.InsertAsync(order);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        [HttpGet("getOrders")]
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _orderService.GetAsync(); 
        }
        [HttpGet("getOrderDetails")]
        public async Task<string> GetOrderDetailsByOrderId(int id)
        {
            OrderModel model = new OrderModel();
            var order = _orderService.FindAsync(id);
            model.OrderId = order.Result.OrderId;
            model.Name = order.Result.Name;
            List<Window> winList = new List<Window>();
            List<SubElement> subList = new List<SubElement>();
            if (order != null)
            {
                winList = _windowService.GetWindowsByOrderId(order.Result.OrderId);
             
                if(winList != null && winList.Count > 0)
                {
                    foreach (Window win in winList)
                    {
                        subList = _subElementService.GetSubElementByWindowId(win.WindowId);
                        win.SubElements = subList;
                    }
                 }
                model.Windows = winLis t;
            }
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };
            string result = JsonSerializer.Serialize(model, options);
            return result;
        }
        [HttpDelete("deleteOrder")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
             bool result = false;
            try
            {
                await _orderService.DeleteAsync(id);
                result = true;
            }
            catch(Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
