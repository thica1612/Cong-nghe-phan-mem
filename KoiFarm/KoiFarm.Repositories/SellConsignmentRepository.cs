using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;

namespace KoiFarm.Repositories
{
    public class SellConsignmentRepository : ISellConsignmentRepository
    {
        private readonly ApplicationDbContext _context;

        public SellConsignmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SellConsignment>> GetAllAsync()
        {
            return await _context.SellConsignments.ToListAsync();
        }

        public async Task<SellConsignment> GetByIdAsync(int id)
        {
            return await _context.SellConsignments.FindAsync(id);
        }

        public async Task AddAsync(SellConsignment sellConsignment)
        {
            await _context.SellConsignments.AddAsync(sellConsignment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SellConsignment sellConsignment)
        {
            _context.SellConsignments.Update(sellConsignment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var consignment = await _context.SellConsignments.FindAsync(id);
            if (consignment != null)
            {
                _context.SellConsignments.Remove(consignment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
