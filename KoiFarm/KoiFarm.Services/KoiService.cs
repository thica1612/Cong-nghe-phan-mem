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
    public class KoiService:IKoiService
    {
        private readonly IKoiRepository _repository;

        public KoiService(IKoiRepository repository) {
            _repository = repository;
        }

        public bool AddKoi(Koi koi)
        {
           return _repository.AddKoi(koi);
        }

        public bool DeleteKoi(Koi koi)
        {
            return _repository.DeleteKoi(koi);
        }

        public bool DelKoi(string KoiID)
        {
            return _repository.DelKoi(KoiID);
        }

        public Task<Koi> GetKoiById(string KoiID)
        {
            return _repository.GetKoiById(KoiID);
        }

        public Task<List<Koi>> KoiSales()
        {
            return _repository.GetAllKoi();
        }

        public bool UpdateKoi(Koi koi)
        {
            return _repository.UpdateKoi(koi);
        }
    }
}
