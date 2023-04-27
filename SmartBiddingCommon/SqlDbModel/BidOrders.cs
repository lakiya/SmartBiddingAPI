using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBiddingCommon.SqlDbModel
{
    public class BidOrders
    {
        [Key]
        public Guid BidOrderId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        public DateTime BidStartTime { get; set; }
        public DateTime BidEndTime { get; set; }
        public int BidChairsAllowed { get; set; }
        public decimal IncrimentPricePerBid { get; set; }
        [Required]
        public decimal BasePrice { get; set; }
        public virtual Product Product { get; set; }
    }
}
