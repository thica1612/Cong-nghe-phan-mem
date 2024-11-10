using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.Repositories.Interfaces
{
    public interface ICertificationRepository
    {
        Task<List<Certification>> GetAllCertification();
        Boolean DelCertification(string CertificationID);
        Boolean DelCertification(Certification certification);
        Boolean AddCertification(Certification certification);
        Boolean UpdCertification(Certification certification);
        Task<Certification> GetCertificationByID(string CertificationID);
    }
}
