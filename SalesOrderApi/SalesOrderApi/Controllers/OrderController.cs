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
        public async Task<ActionResult<bool>> CreateOrder(OrderModel orderModel)
        {
            try
            {
                if (orderModel != null)
                {
                    Order order = new Order();
                    order.Name = orderModel.Name;
                    order.State = orderModel.State;
                    order.Windows= new List<Window>();
                   
                    foreach (var item in orderModel.Windows)
                    {
                        List<SubElement> subElemetList = new List<SubElement>(); 
                        if (item.SubElements != null && item.SubElements.Count >0)
                        {
                            foreach(var subElement in item.SubElements)
                            {
                                subElemetList.Add(new SubElement() { 
                                    Element = subElement.Element,
                                    Type = subElement.Type,
                                    Height = subElement.Height, 
                                    Width = subElement.Width 
                                });
                            }
                        }
                        order.Windows.Add(new Window { 
                            Name = item.Name, 
                            QuantityOfWindows = item.QuantityOfWindows,
                            TotalSubElements = item.TotalSubElements ,
                            SubElements = subElemetList
                        });
                    }
                    
                    await _orderService.InsertAsync(order);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        [HttpPost("editOrder")]
        public async Task<ActionResult<bool>> EditOrder(OrderModel orderModel)
        {
            try
            {
                if (orderModel != null)
                {
                    Order order = new Order();
                    order.OrderId = orderModel.OrderId;
                    order.Name = orderModel.Name;
                    order.State = orderModel.State;
                    order.Windows = new List<Window>();

                    foreach (var item in orderModel.Windows)
                    {
                        List<SubElement> subElemetList = new List<SubElement>();
                        if (item.SubElements != null && item.SubElements.Count > 0)
                        {
                            foreach (var subElement in item.SubElements)
                            {
                                subElemetList.Add(new SubElement()
                                {
                                    SubElementId = subElement.SubElementId,
                                    Element = subElement.Element,
                                    Type = subElement.Type,
                                    Height = subElement.Height,
                                    Width = subElement.Width,
                                    WindowId = subElement.WindowId,
                                });
                            }
                        }
                        order.Windows.Add(new Window
                        {
                            WindowId = item.WindowId,
                            OrderId= orderModel.OrderId,
                            Name = item.Name,
                            QuantityOfWindows = item.QuantityOfWindows,
                            TotalSubElements = item.TotalSubElements,
                            SubElements = subElemetList
                        });
                    }

                    await _orderService.UpdateAsync(order);
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
        [HttpGet("getOrderDetails/{id}")]
        public async Task<Order> GetOrderDetailsByOrderId(int id)
        {
            var order = _orderService.GetOrderDetailsByOrderId(id);
            return order;
        }
        [HttpDelete("deleteOrder/{id}")]
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

        [HttpDelete("deleteWindow/{id}")]
        public async Task<ActionResult<bool>> DeleteWindow(int id)
        {
            bool result = false;
            try
            {
                await _windowService.DeleteAsync(id);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        [HttpDelete("deleteSubElement/{id}")]
        public async Task<ActionResult<bool>> DeleteSubElement(int id)
        {
            bool result = false;
            try
            {
                await _subElementService.DeleteAsync(id);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
