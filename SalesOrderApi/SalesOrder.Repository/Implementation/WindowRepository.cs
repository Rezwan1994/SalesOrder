using SalesOrder.Domain.BusinessModel;
using SalesOrder.Domain.DbContexts;
using SalesOrder.Domain.Entities;
using SalesOrder.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Repository.Implementation
{
    public class WindowRepository : Repository<Window>, IWindowRepository
    {
        private readonly SalesOrderDbContext _context;
        public WindowRepository(SalesOrderDbContext context) : base(context)
        {
            _context = context;
        }
      
    }
}
