using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBiddingCommon.SqlDbModel
{
    public class SystemUser
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime DOB { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsVerified { get; set; }
    }
}
