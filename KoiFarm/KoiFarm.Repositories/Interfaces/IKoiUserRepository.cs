using KoiFarm.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarm.Repositories.Interfaces
{
    public interface IKoiUserRepository
    {
        Task<List<KoiUser>> GetAllKoiUser();
        Boolean DelKoiUser(int Id);
        Boolean DelKoiUser(KoiUser account);
        Boolean AddKoiUser(KoiUser account);
        Boolean UpKoiUser(KoiUser account);
        Task<KoiUser> GetKoiUserById(int Id);
    }
}
