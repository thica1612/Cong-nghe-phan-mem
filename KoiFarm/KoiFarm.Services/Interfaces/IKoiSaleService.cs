using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;
namespace KoiFarm.Services.Interfaces
{
    public interface IKoiSaleService
    {
        Task<List<KoiSale>> KoiSales();
        Boolean DelKoiSale(String KoiSaleID);
        Boolean DeleteKoiSale(KoiSale koisale);
        Boolean AddKoiSale(KoiSale koisale);
        Boolean UpdateKoiSale(KoiSale koisale);
        Task<KoiSale> GetKoiSaleById(String KoiSaleID);
    }
}
