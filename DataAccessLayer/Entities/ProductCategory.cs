﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBiddingDLL.Entities
{
    public class ProductCategory: EntityBase
    {
        public string? Description { get; set; }
        //public virtual ICollection<Product> Products { get; set; }
    }
}
