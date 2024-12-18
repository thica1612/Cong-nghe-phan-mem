﻿using KoiFarm.Repositories;
using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using KoiFarm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarm.Services
{
    public class KoiUserService : IKoiUserService
    {
        private readonly IKoiUserRepository _repository;
        public KoiUserService(IKoiUserRepository repository)
        {
            _repository = repository;
        }
        public bool AddKoiUser(KoiUser account)
        {
            return _repository.AddKoiUser(account);
        }

        public Task<KoiUser?> AuthenUser(string userNameorEmail, string userPassword)
        {
            return _repository.AuthenUserAsync(userNameorEmail, userPassword);
        }

        public bool DelKoiUser(Guid Id)
        {
            return _repository.DelKoiUser(Id);
        }

        public bool DelKoiUser(KoiUser account)
        {
            return _repository.DelKoiUser(account);
        }

        public Task<KoiUser> GetKoiUserById(Guid Id)
        {
            return _repository.GetKoiUserById(Id);
        }

        public Task<List<KoiUser>> KoiUsers()
        {
            return _repository.GetAllKoiUser();
        }

        public Task<bool> SignUpUser(KoiUser account)
        {
            return _repository.SignUpUserAsync(account);
        }

        public bool UpKoiUser(KoiUser account)
        {
            return _repository.UpKoiUser(account);
        }
    }
}
