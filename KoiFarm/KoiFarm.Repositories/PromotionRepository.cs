using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarm.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly KoiFarmContext _dbContext;

        public PromotionRepository(KoiFarmContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Promotion>> GetAllPromotions()
        {
            return await _dbContext.Promotions.ToListAsync();
        }

        public async Task<Promotion> GetPromotionById(int id)
        {
            return await _dbContext.Promotions.FindAsync(id);
        }

        public async Task<bool> AddPromotion(Promotion promotion)
        {
            await _dbContext.Promotions.AddAsync(promotion);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePromotion(Promotion promotion)
        {
            _dbContext.Promotions.Update(promotion);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePromotion(int id)
        {
            var promotion = await GetPromotionById(id);
            if (promotion == null) return false;

            _dbContext.Promotions.Remove(promotion);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
