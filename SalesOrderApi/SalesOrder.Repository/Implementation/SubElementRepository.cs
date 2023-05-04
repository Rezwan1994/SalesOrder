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
    public class SubElementRepository : Repository<SubElement>, ISubElementRepository
    {
        private readonly SalesOrderDbContext _context;
        public SubElementRepository(SalesOrderDbContext context) : base(context)
        {
            _context = context;
        }
        public List<SubElementModel> GetSubElementByWindowId(int windowId)
        {
            var qry = string.Format("Select SubElementId,Element,Type,Width,Height,WindowId from SubElements where WindowId = {0}", windowId);
            return _context.ExecSQL<SubElementModel>(qry);
        }
    }
}
