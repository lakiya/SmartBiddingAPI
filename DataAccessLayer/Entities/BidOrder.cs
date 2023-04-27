using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBiddingDLL.Entities
{
    public class BidOrder:EntityBase
    {
        public string ProductId { get; set; }
        public DateTime BidStartTime { get; set; }
        public DateTime BidEndTime { get; set; }
        public int BidChairsAllowed { get; set; }
        public decimal IncrimentPricePerBid { get; set; }
        public decimal BasePrice { get; set; }
        public virtual Product Product { get; set; }
    }
}
