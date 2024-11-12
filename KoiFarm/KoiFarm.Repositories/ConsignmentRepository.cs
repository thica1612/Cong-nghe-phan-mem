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
    public class ConsignmentRepository : IConsignmentRepository
    {
        private readonly KoiFarmContext _context;
        public ConsignmentRepository(KoiFarmContext context)
        {
            _context = context;
        }
        public async Task<List<Consignment>> GetAllConsignments()
        {
            return await _context.Consignments.ToListAsync();
        }

        public async Task<List<Consignment>> GetConsignmentsByType(int consignmentType)
        {
            return await _context.Consignments
                                 .Where(c => c.ConsignmentType == consignmentType.ToString())
                                 .ToListAsync();
        }
        public async Task<Consignment> GetConsignmentById(int consignmentId)
        {
            return await _context.Consignments.FindAsync(consignmentId);
        }

        public async Task<bool> AddConsignment(Consignment consignment)
        {
            _context.Consignments.Add(consignment);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateConsignment(Consignment consignment)
        {
            _context.Consignments.Update(consignment);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteConsignment(int consignmentId)
        {
            var consignment = await _context.Consignments.FindAsync(consignmentId);
            if (consignment == null)
            {
                return false;
            }
            _context.Consignments.Remove(consignment);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}


