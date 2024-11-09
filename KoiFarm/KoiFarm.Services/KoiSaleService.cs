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

        public Task<List<KoiSale>> KoiSales()
        {
            return _repository.GetAllKoiSale();
        }
    }
}
