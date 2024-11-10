using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;
namespace KoiFarm.Repositories.Interfaces
{
    public  interface IKoiRepository
    {
        Task<List<Koi>> GetAllKoi();
        Boolean DelKoi(String KoiID);
        Boolean DeleteKoi(Koi koi);
        Boolean AddKoi(Koi koi);
        Boolean UpdateKoi(Koi koi);
        Task<Koi> GetKoiById(String KoiID);
    
    }
}
