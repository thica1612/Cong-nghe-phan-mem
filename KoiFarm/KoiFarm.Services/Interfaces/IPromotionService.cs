using KoiFarm.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarm.Services.Interfaces
{
    public interface IPromotionService
    {
        Task<List<Promotion>> GetAllPromotions();
        Task<Promotion> GetPromotionById(int id);
        Task<bool> AddPromotion(Promotion promotion);
        Task<bool> UpdatePromotion(Promotion promotion);
        Task<bool> DeletePromotion(int id);
    }
}
