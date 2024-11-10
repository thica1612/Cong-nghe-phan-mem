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
    public class KoiSaleService : IKoiSaleService
    {
        private readonly IKoiSaleRepository _repository;
        public KoiSaleService(IKoiSaleRepository repository) { 
            _repository = repository;
        }

        public bool AddKoiSale(KoiSale koisale)
        {
            return _repository.AddKoiSale(koisale);
        }

        public bool DeleteKoiSale(KoiSale koisale)
        {
            return _repository .DeleteKoiSale(koisale);
        }

        public bool DelKoiSale(string KoiSaleID)
        {
            return _repository.DelKoiSale(KoiSaleID);
        }

        public Task<KoiSale> GetKoiSaleById(string KoiSaleID)
        {
            return _repository.GetKoiSaleById(KoiSaleID);
        }

        public Task<List<KoiSale>> KoiSales()
        {
            return _repository.GetAllKoiSale();
        }

        public bool UpdateKoiSale(KoiSale koisale)
        {
            return _repository.UpdateKoiSale(koisale);
        }
    }
}
