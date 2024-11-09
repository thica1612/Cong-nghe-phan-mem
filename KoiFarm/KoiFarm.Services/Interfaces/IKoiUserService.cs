﻿using KoiFarm.Repositories.Entities;
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
        Boolean DelKoiUser(int Id);
        Boolean DelKoiUser(KoiUser account);
        Boolean AddKoiUser(KoiUser account);
        Boolean UpKoiUser(KoiUser account);
        Task<KoiUser> GetKoiUserById(int Id);
    }
}