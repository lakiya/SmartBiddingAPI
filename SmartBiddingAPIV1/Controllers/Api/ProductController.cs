using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBiddingAPIV1.Models;
using SmartBiddingBLL.Services;
using SmartBiddingBLL.Services.Interface;
using SmartBiddingDLL.Entities;

namespace SmartBiddingAPIV1.Controllers.Api
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetProducts();

            return Ok(new GenericModel<List<Product>>
            {
                Data = products
            });
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            var products = _productService.Create(product);
            return Ok(new GenericModel<string>
            {
                Data = products
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            try
            {
                var products = _productService.GetProductByIdWithTables((id));

                return Ok(new GenericModel<Product>
                {
                    Data = products
                });
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
