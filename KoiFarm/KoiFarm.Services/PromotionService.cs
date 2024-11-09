using KoiFarm.Repositories;
using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using KoiFarm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarm.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _repository;

        public PromotionService(IPromotionRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Promotion>> GetAllPromotions() => _repository.GetAllPromotions();
        public Task<Promotion> GetPromotionById(int id) => _repository.GetPromotionById(id);
        public Task<bool> AddPromotion(Promotion promotion) => _repository.AddPromotion(promotion);
        public Task<bool> UpdatePromotion(Promotion promotion) => _repository.UpdatePromotion(promotion);
        public Task<bool> DeletePromotion(int id) => _repository.DeletePromotion(id);
    }
}