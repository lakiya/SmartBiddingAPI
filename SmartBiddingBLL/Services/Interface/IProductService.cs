//using SmartBiddingCommon.SqlDbModel;
using SmartBiddingDLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SmartBiddingBLL.Services.Interface
{
    public interface IProductService
    {
        // Adding include tables generic interface
        public IProductService With<T>();

        public List<Product> GetProducts();
        public Product GetProductById(Guid id);
        public string Create(Product product);
        public void Update(Product product);
        public void Delete(Product product);
        public Product GetProductByIdWithTables(Guid id);
    }
}
