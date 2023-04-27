using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBiddingCommon.SqlDbModel
{
    public partial class ProductCategory
    {
        [Key]
        public Guid ProductCategoryId { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
