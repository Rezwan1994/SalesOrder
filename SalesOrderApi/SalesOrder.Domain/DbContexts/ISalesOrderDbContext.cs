using Microsoft.EntityFrameworkCore;
using SalesOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Domain.DbContexts
{
    public interface ISalesOrderDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Window> Windows { get; set; }
        DbSet<SubElement> SubElements { get; set; }
    }
}
