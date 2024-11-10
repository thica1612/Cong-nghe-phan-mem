using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;
namespace KoiFarm.Repositories.Interfaces
{
    public interface IKoiSaleRepository
    {
        Task<List<KoiSale>> GetAllKoiSale();
        Boolean DelKoiSale(String KoiSaleID);
        Boolean DeleteKoiSale(KoiSale koisale);
        Boolean AddKoiSale(KoiSale koisale);
        Boolean UpdateKoiSale(KoiSale koisale);
        Task<KoiSale> GetKoiSaleById(String KoiSaleID);
    }
}
