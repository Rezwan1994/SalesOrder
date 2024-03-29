﻿using SalesOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Domain.BusinessModel
{
    public class WindowModel
    {
        public int WindowId { get; set; }
        public string Name { get; set; }
        public int QuantityOfWindows { get; set; }
        public int TotalSubElements { get; set; }
        public int OrderId { get; set; }
        public List<SubElementModel> SubElements { get; set; }
    }
}

