using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using KoiFarm.Services.Interfaces;

namespace KoiFarm.Services
{
    public class CertificationKoiSaleService : ICertificationKoiSaleService
    {
        private readonly ICertificationKoiSaleRepository _repository;

        public CertificationKoiSaleService(ICertificationKoiSaleRepository repository) { 
            _repository = repository;
        }

        public bool AddCertificationKoiSale(CertificationKoiSale certificationKoiSale)
        {
            return _repository.AddCertificationKoiSale(certificationKoiSale);
        }

        public Task<List<CertificationKoiSale>> CertificationKoiSales() {
            return _repository.GetAllCertificationKoiSale();
        }

        public bool DelCertificationKoiSale(string CertificationKSID)
        {
            return _repository.DelCertificationKoiSale(CertificationKSID);
        }

        public bool DelCertificationKoiSale(CertificationKoiSale certificationKoiSale)
        {
            return _repository.DelCertificationKoiSale(certificationKoiSale);
        }

        public Task<CertificationKoiSale> GetCertificationKoiSaleByID(string CertificationKSID)
        {
            return _repository.GetCertificationKoiSaleByID(CertificationKSID);
        }

        public bool UpdCertificationKoiSale(CertificationKoiSale certificationKoiSale)
        {
            return _repository.UpdCertificationKoiSale(certificationKoiSale);
        }
    }
}
