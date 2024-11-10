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
    public class CertificationRepository : ICertificationRepository
    {
        private readonly KoiFarmContext _context;

        public CertificationRepository(KoiFarmContext context) { 
            _context = context;
        }

        public bool AddCertification(Certification certification)
        {
            try
            {
                _context.Certifications.Add(certification);
                _context.SaveChanges();
                return true;    
            }
            catch(Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelCertification(string CertificationID)
        {
            try
            {
                var objDel = _context.Certifications.Where(p => p.CertificationId.Equals(CertificationID)).FirstOrDefault();
                if (objDel != null)
                {
                    _context.Certifications.Remove(objDel);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex) { throw new NotImplementedException(ex.ToString()); }
        }

        public bool DelCertification(Certification certification)
        {
            try
            {
                _context.Certifications.Remove(certification);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { throw new NotImplementedException(ex.ToString()); return false; }
        }

        public async Task<List<Certification>> GetAllCertification() { 
            return await _context.Certifications.ToListAsync();
        }

        public async Task<Certification> GetCertificationByID(string CertificationID)
        {
            return await _context.Certifications.Where(p => p.CertificationId.Equals(CertificationID)).FirstOrDefaultAsync();
        }

        public bool UpdCertification(Certification certification)
        {
            try
            {
                _context.Certifications.Update(certification);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }
    }
}
