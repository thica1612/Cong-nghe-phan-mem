using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
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

        public async Task<KoiUser?> AuthenUserAsync(string userNameorEmail, string userPassword)
        {
            var user = await _context.KoiUsers.Where(p => p.UserName.Equals(userNameorEmail) || p.Email.Equals(userNameorEmail)).FirstOrDefaultAsync();
            if (user != null && userPassword == user.UserPassword)
            {
                return user;
            }
            return null;
        }

        public bool DelKoiUser(Guid Id)
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

        public async Task<KoiUser> GetKoiUserById(Guid Id)
        {
            return await _context.KoiUsers.Where(p => p.UserId.Equals(Id)).FirstOrDefaultAsync();
        }


        public async Task<bool> SignUpUserAsync(KoiUser account)
        {
            var exist = _context.KoiUsers.Where(p => p.UserName == account.UserName || p.Email == account.Email).FirstOrDefault();
            if (exist != null)
            {
                return false;
            }
            account.UserId = Guid.NewGuid();
            account.DateJoined = DateTime.Now;

            Console.WriteLine($"UserName: {account.UserName}, Email: {account.Email}, Password: {account.UserPassword}");

            _context.KoiUsers.Add(account);
            await _context.SaveChangesAsync();
            return true;
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
