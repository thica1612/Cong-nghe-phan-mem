using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.Services.Interfaces
{
    public interface ICertificationService
    {
        Task<List<Certification>> Certifications();
    }
}
