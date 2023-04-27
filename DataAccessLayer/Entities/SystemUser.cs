using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBiddingDLL.Entities
{
    public class SystemUser:EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get;set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsVerified { get; set; }
    }
}
