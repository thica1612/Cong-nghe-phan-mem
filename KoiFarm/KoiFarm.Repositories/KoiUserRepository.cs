﻿using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarm.Repositories
{
    public class KoiUserRepository : IKoiUserRepository
    {
        private readonly KoiFarmContext _context;
        private KoiFarmContext context;

        public KoiUserRepository(KoiFarmContext context)
        {
            _context = context; 
        }


        public bool AddKoiUser(KoiUser account)
        {
            try
            {
                _context.KoiUsers.Add(account);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool DelKoiUser(string Id)
        {
            try
            {
                var objDel = _context.KoiUsers.Where(p => p.UserId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _context.KoiUsers.Remove(objDel);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelKoiUser(KoiUser account)
        {
            try
            {
                _context.KoiUsers.Remove(account);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<KoiUser>> GetAllKoiUser()
        {
            return await _context.KoiUsers.ToListAsync();
        }

        public async Task<KoiUser> GetKoiUserById(string Id)
        {
            return await _context.KoiUsers.Where(p => p.UserId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpKoiUser(KoiUser account)
        {
            try
            {
                _context.KoiUsers.Update(account);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
