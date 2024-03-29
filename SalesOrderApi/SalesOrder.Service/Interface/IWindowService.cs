﻿using SalesOrder.Domain.BusinessModel;
using SalesOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Service.Interface
{
    public interface IWindowService : IBaseService<Window>
    {
        public List<WindowModel> GetWindowsByOrderId(int orderId);
    }
}
