using KoiFarm.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarm.Repositories.Interfaces
{
    public interface IKoiUserRepository
    {
        Task<List<KoiUser>> GetAllKoiUser();
        Boolean DelKoiUser(Guid Id);
        Boolean DelKoiUser(KoiUser account);
        Boolean AddKoiUser(KoiUser account);
        Boolean UpKoiUser(KoiUser account);
        Task<KoiUser> GetKoiUserById(Guid Id);
        Task<bool> AuthenUserAsync(string userNameorEmail, string userPassword);
        Task<bool> SignUpUserAsync(KoiUser account);
    }
}
