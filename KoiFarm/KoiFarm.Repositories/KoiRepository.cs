using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace KoiFarm.Repositories
{
    public class KoiRepository:IKoiRepository
    {
        private readonly KoiFarmContext _context;
        public KoiRepository(KoiFarmContext context) { 
            _context = context;
        }

        public bool AddKoi(Koi koi)
        {
            try
            {
                _context.Kois.Add(koi);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DeleteKoi(Koi koi)
        {
            try
            {
                _context.Kois.Remove(koi);
                _context.SaveChanges();
                return true;
            } catch(Exception ex) { throw new NotImplementedException(ex.ToString()); return false; }
        }

        public bool DelKoi(string KoiID)
        {
            try
            {
                var objDel= _context.Kois.Where(p=>p.KoiId.Equals(KoiID)).FirstOrDefault();
                if (objDel != null)
                {
                    _context.Kois.Remove(objDel);
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

        public async Task<List<Koi>> GetAllKoi()
        {
            return await _context.Kois.ToListAsync();  
        }

        public Task<Koi> GetKoiById(string KoiID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateKoi(Koi koi)
        {
            throw new NotImplementedException();
        }
    }
}
