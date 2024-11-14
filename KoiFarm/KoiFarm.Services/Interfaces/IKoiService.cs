using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;
namespace KoiFarm.Services.Interfaces
{
    public interface IKoiService
    {
        Task<List<Koi>> KoiSales();
        Boolean DelKoi(String KoiID);
        Boolean DeleteKoi(Koi koi);
        Boolean AddKoi(Koi koi);
        Boolean UpdateKoi(Koi koi);
        Task<Koi> GetKoiById(String KoiID);
    }
}
