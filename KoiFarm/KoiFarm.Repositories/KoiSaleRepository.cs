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
    public class KoiSaleRepository:IKoiSaleRepository
    {
        private readonly KoiFarmContext _context;
        public KoiSaleRepository(KoiFarmContext context) {
            _context = context;
        }

        public async Task<List<KoiSale>> GetAllKoiSale()
        {
            return await _context.KoiSales.ToListAsync();
        }

    }
}
