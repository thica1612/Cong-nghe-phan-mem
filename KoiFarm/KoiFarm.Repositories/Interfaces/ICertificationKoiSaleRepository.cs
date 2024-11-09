using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.Repositories.Interfaces
{
    public interface ICertificationKoiSaleRepository
    {
        Task<List<CertificationKoiSale>> GetAllCertificationKoiSale();
        Boolean DelCertificationKoiSale(string CertificationKSID);
        Boolean DelCertificationKoiSale(CertificationKoiSale certificationKoiSale);
        Boolean AddCertificationKoiSale(CertificationKoiSale certificationKoiSale);
        Boolean UpdCertificationKoiSale(CertificationKoiSale certificationKoiSale);
        Task<CertificationKoiSale> GetCertificationKoiSaleByID(string CertificationKSID);
    }
}
