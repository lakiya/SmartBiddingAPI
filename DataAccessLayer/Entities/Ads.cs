using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBiddingDLL.Entities
{
    public class Ads : EntityBase
    {
        public string ProductId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserId { get;set; }
        public decimal Price { get; set; }
        public virtual Product Product { get; set; }
        public virtual SystemUser User { get; set; }
    }
}
