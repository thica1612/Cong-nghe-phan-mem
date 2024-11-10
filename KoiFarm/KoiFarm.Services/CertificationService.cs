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

        public bool AddCertification(Certification certification)
        {
            return _repository.AddCertification(certification);
        }

        public Task<List<Certification>> Certifications()
        {
            return _repository.GetAllCertification();
        }

        public bool DelCertification(string CertificationID)
        {
            return _repository.DelCertification(CertificationID);
        }

        public bool DelCertification(Certification certification)
        {
            return _repository.DelCertification(certification);
        }

        public Task<Certification> GetCertificationByID(string CertificationID)
        {
            return _repository.GetCertificationByID(CertificationID);
        }

        public bool UpdCertification(Certification certification)
        {
            return _repository.UpdCertification(certification);
        }
    }
}
