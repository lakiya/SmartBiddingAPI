using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBiddingCommon.SqlDbModel
{
    public partial class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        public Guid ProductCategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal ActualPrice { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
