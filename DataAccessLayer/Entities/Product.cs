using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBiddingDLL.Entities
{
    public class Product : EntityBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal ActualPrice { get; set; }
        public string ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
