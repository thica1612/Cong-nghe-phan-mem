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
    public class CertificationRepository : ICertificationRepository
    {
        private readonly KoiFarmContext _context;

        public CertificationRepository(KoiFarmContext context) { 
            _context = context;
        }

        public async Task<List<Certification>> GetAllCertification() { 
            return await _context.Certifications.ToListAsync();
        }
    }
}
