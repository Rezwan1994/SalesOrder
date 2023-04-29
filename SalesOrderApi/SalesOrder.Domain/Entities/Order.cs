﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public ICollection<Window> Windows { get; set; }
    }
}
