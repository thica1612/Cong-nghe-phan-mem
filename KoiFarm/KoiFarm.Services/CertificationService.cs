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
    public class CertificationService : ICertificationService
    {
        private readonly ICertificationRepository _repository;

        public CertificationService(ICertificationRepository repository) {
            _repository = repository;
        }

        public Task<List<Certification>> Certifications()
        {
            return _repository.GetAllCertification();
        }
    }
}
