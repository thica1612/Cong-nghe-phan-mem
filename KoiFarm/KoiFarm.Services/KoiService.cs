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
           return _repository.AddKoi();
        }

        public bool DeleteKoi(Koi koi)
        {
            throw new NotImplementedException();
        }

        public bool DelKoi(string KoiID)
        {
            throw new NotImplementedException();
        }

        public Task<Koi> GetKoiById(string KoiID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Koi>> Kois()
        {
            return _repository.GetAllKoi();
        }

        public bool UpdateKoi(Koi koi)
        {
            throw new NotImplementedException();
        }
    }
}
