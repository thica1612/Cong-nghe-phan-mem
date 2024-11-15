using KoiFarm.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarm.Services.Interfaces
{
    public interface IKoiUserService
    {
        Task<List<KoiUser>> KoiUsers();
        Boolean DelKoiUser(string Id);
        Boolean DelKoiUser(KoiUser account);
        Boolean AddKoiUser(KoiUser account);
        Boolean UpKoiUser(KoiUser account);
        Task<KoiUser> GetKoiUserById(string Id);
        Task<bool> AuthenUser(string userNameorEmail, string userPassword);
        Task<bool> SignUpUser(KoiUser account);
    }
}
