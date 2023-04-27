using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBiddingDLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBiddingBLL.Services.Interface
{
    public interface IAdsService
    {
        // Adding include tables generic interface
        public IAdsService With<T>();

        public List<Ads> GetAds();
        public Ads GetAddById(Guid id);
        public string Create(Ads add);
        public string Update(Ads add);
        public void Delete(Ads add);
        public void UploadImageAsync(IFormFile file, Guid id);
        public List<Ads> GetAddByUserId(Guid userId);
        public List<BidOrder> GetBiddingAddByUserId(Guid userId);
    }
}
