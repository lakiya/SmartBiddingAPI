using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBiddingDLL.Entities
{
    public class BidderBidRegistration:EntityBase
    {
        public string SystemUserId { get;set; }
        public virtual SystemUser SystemUser { get;set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
