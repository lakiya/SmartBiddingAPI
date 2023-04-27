using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBiddingAPIV1.Models;
using SmartBiddingBLL.Services;
using SmartBiddingBLL.Services.Interface;
using SmartBiddingDLL.Entities;

namespace SmartBiddingAPIV1.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly IAdsService _adsService;
        public AdsController(IAdsService adsService)
        {
            this._adsService = adsService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var products = _adsService.GetAds();

            return Ok(new GenericModel<List<Ads>>
            {
                Data = products
            });
        }

        [HttpPost]
        public IActionResult Create([FromBody] Ads product)
        {
            var products = _adsService.Create(product);
            return Ok(new GenericModel<string>
            {
                Data = products
            });
        }
        [HttpPatch]
        public IActionResult Update([FromBody] Ads add)
        {
            var returnVal = _adsService.Update(add);
            return Ok(new GenericModel<string>
            {
                Data = returnVal
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetAddById(Guid id)
        {
            try
            {
                var products = _adsService.GetAddById((id));

                return Ok(new GenericModel<Ads>
                {
                    Data = products
                });
            }
            catch (Exception e)
            {

                throw;
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Ads add)
        {
            try
            {
                _adsService.Delete((add));

                return Ok(new GenericModel<Ads>
                {
                    Data = null
                });
            }
            catch (Exception e)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> UploadImageAsync(IFormFile file, Guid id)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("File not found.");
                }

                // Define the path where the file will be saved
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", file.FileName);

                // Save the file to the path
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                
                // Return a success response
                return Ok($"File {file.FileName} was uploaded successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetAddByUserId(Guid userId)
        {
            try
            {
                var products = _adsService.GetAddByUserId((userId));

                return Ok(new GenericModel<List<Ads>>
                {
                    Data = products
                });
            }
            catch (Exception e)
            {

                throw;
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetBiddingAddByUserId(Guid userId)
        {
            try
            {
                var products = _adsService.GetBiddingAddByUserId((userId));

                return Ok(new GenericModel<List<BidOrder>>
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
