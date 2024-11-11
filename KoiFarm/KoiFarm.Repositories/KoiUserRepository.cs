using KoiFarm.Repositories.Entities;
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
        private readonly KoiFarmContext _dbContext;
        private KoiFarmContext dbContext;

        public KoiUserRepository(KoiFarmContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        public bool AddKoiUser(KoiUser account)
        {
            try
            {
                _dbContext.KoiUsers.Add(account);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool DelKoiUser(int Id)
        {
            try
            {
                var objDel = _dbContext.KoiUsers.Where(p => p.UserId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.KoiUsers.Remove(objDel);
                    _dbContext.SaveChanges();
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
                _dbContext.KoiUsers.Remove(account);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<KoiUser>> GetAllKoiUser()
        {
            return await _dbContext.KoiUsers.ToListAsync();
        }

        public async Task<KoiUser> GetKoiUserById(int Id)
        {
            return await _dbContext.KoiUsers.Where(p => p.UserId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpKoiUser(KoiUser account)
        {
            try
            {
                _dbContext.KoiUsers.Update(account);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
