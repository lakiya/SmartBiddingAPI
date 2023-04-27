using Microsoft.AspNetCore.Http;
using SmartBiddingBLL.Services.Interface;
using SmartBiddingCommon.SqlDbModel;
using SmartBiddingDLL.Entities;
using SmartBiddingDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBiddingBLL.Services
{
    public class AdsService : IAdsService
    {
        private readonly ICommonRepository _commonRepository;
        public AdsService(ICommonRepository commonRepository)
        {
            this._commonRepository = commonRepository;
        }
        public string Create(Ads add)
        {
            return _commonRepository.Add(add).Id;
        }

        public void Delete(Ads add)
        {
            _commonRepository.Remove(add);
        }

        public Ads GetAddById(Guid id)
        {
            return _commonRepository.GetAll<Ads>(new string[] { "Product" }).Where(x => x.Id == id.ToString()).FirstOrDefault();
        }

        public List<Ads> GetAddByUserId(Guid userId)
        {
            return _commonRepository.GetAll<Ads>(new string[] { "User" }).Where(x => x.UserId == userId.ToString()).ToList();
        }

        public List<Ads> GetAds()
        {
            return _commonRepository.GetAll<Ads>(new string[] { "Product" }).ToList();
        }

        public List<BidOrder> GetBiddingAddByUserId(Guid userId)
        {
            return _commonRepository.GetAll<BidOrder>(new string[] { "Product" }).ToList();
        }

        public string Update(Ads add)
        {
            return _commonRepository.Update(add).Id;
        }

        public void UploadImageAsync(IFormFile file, Guid id)
        {
            throw new NotImplementedException();
        }

        public IAdsService With<T>()
        {
            throw new NotImplementedException();
        }
    }
}
