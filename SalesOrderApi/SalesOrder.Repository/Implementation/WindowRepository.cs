using SalesOrder.Domain.BusinessModel;
using SalesOrder.Domain.DbContexts;
using SalesOrder.Domain.Entities;
using SalesOrder.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SalesOrder.Repository.Implementation
{
    public class WindowRepository : Repository<Window>, IWindowRepository
    {
        private readonly SalesOrderDbContext _context;
        public WindowRepository(SalesOrderDbContext context) : base(context)
        {
            _context = context;
        }
        public List<WindowModel> GetWindowsByOrderId(int orderId)
        {
            var qry = string.Format("Select WindowId,Name,QuantityOfWindows,TotalSubElements,OrderId from Windows where OrderId = {0}", orderId);
            try
            {
                _context.ExecSQL<WindowModel>(qry);
            }
            catch (Exception ex) { }
            return _context.ExecSQL<WindowModel>(qry);
        }
    }
}
