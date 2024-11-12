using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiFarm.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly KoiFarmContext _context;

        public FeedbackRepository(KoiFarmContext context)
        {
            _context = context;
        }


        public async Task<bool> AddFeedback(Feedback feedback)
        {
            try
            {
                await _context.Feedbacks.AddAsync(feedback);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<List<Feedback>> GetAllFeedback()
        {
            return await _context.Feedbacks
                                 .Include(f => f.Customer)
                                 .Include(f => f.Koi)
                                 .ToListAsync();
        }


        public async Task<List<Feedback>> GetFeedbacksByUser(string customerId)
        {
            return await _context.Feedbacks
                                 .Where(f => f.CustomerId == customerId)
                                 .Include(f => f.Customer)
                                 .Include(f => f.Koi)
                                 .ToListAsync();
        }


        public async Task<bool> FeedbackExists(Feedback feedback)
        {
            return await _context.Feedbacks.AnyAsync(f =>
                f.CustomerId == feedback.CustomerId &&
                f.KoiId == feedback.KoiId &&
                f.Rating == feedback.Rating &&
                f.Comments == feedback.Comments);
        }
    }
}
