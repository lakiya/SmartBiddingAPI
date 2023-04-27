using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBiddingCommon.SqlDbModel
{
    public class BidderBidRegistration
    {
        [Key]
        public Guid BidderRegistrationId { get; set; }
        [Required]
        public string SystemUserId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }
        public Guid BidOrderId { get; set; }
        public virtual SystemUser SystemUser { get; set; }
        public virtual BidOrders BidOrder { get; set; }
    }
}
