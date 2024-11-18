using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;

namespace KoiFarm.Repositories
{
    public class FeedConsignmentRepository : IFeedConsignmentRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedConsignmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<FeedConsignment>> GetAllAsync()
        {
            return await _context.FeedConsignments.ToListAsync();
        }

        public async Task<FeedConsignment> GetByIdAsync(int id)
        {
            return await _context.FeedConsignments.FindAsync(id);
        }

        public async Task AddAsync(FeedConsignment feedConsignment)
        {
            await _context.FeedConsignments.AddAsync(feedConsignment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FeedConsignment feedConsignment)
        {
            _context.FeedConsignments.Update(feedConsignment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var consignment = await _context.FeedConsignments.FindAsync(id);
            if (consignment != null)
            {
                _context.FeedConsignments.Remove(consignment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
