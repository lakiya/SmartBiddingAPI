using SmartBiddingBLL.Services.Interface;
using SmartBiddingDLL.Entities;
//using SmartBiddingCommon.SqlDbModel;
using SmartBiddingDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBiddingBLL.Services
{
    public class ProductService : IProductService
    {
        private readonly ICommonRepository _commonRepository;
        public ProductService(ICommonRepository commonRepository)
        {
            this._commonRepository = commonRepository;
        }
        public string Create(Product product)
        {
            return _commonRepository.Add(product).Id;
        }

        public void Delete(Product product)
        {
            _commonRepository.Remove(product);
        }

        public Product GetProductByIdWithTables(Guid id)
        {
            return _commonRepository.GetAll<Product>(new string[] { "ProductCategory" }).Where(x=>x.Id == id.ToString()).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            return _commonRepository.GetAll<Product>(new string[] { "ProductCategory" }).ToList();
        }

        public void Update(Product product)
        {
            _commonRepository.Update(product);
        }

        public IProductService With<T>()
        {
            throw new NotImplementedException();
        }

        Product IProductService.GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
