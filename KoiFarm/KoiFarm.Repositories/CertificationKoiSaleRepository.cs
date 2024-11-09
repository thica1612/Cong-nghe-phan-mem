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
    public class CertificationKoiSaleRepository : ICertificationKoiSaleRepository
    {
        private readonly KoiFarmContext _context;

        public CertificationKoiSaleRepository(KoiFarmContext context) { 
            _context = context;
        }

        public bool AddCertificationKoiSale(CertificationKoiSale certificationKoiSale)
        {
            try
            {
                _context.CertificationKoiSales.Add(certificationKoiSale);
                _context.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelCertificationKoiSale(string CertificationKSID)
        {
            try
            {
                var objDel = _context.CertificationKoiSales.Where(p=>p.CertificationKsid.Equals(CertificationKSID)).FirstOrDefault();
                if (objDel != null)
                {
                    _context.CertificationKoiSales.Remove(objDel);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex) { throw new NotImplementedException(ex.ToString()); }
        }

        public bool DelCertificationKoiSale(CertificationKoiSale certificationKoiSale)
        {
            try
            {
                _context.CertificationKoiSales.Remove(certificationKoiSale);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { throw new NotImplementedException(ex.ToString()); return false; }
        }

        public async Task<List<CertificationKoiSale>> GetAllCertificationKoiSale()
        {
            return await _context.CertificationKoiSales.ToListAsync();
        }

        public async Task<CertificationKoiSale> GetCertificationKoiSaleByID(string CertificationKSID)
        {
            return await _context.CertificationKoiSales.Where(p => p.CertificationKsid.Equals(CertificationKSID)).FirstOrDefaultAsync();
        }

        public bool UpdCertificationKoiSale(CertificationKoiSale certificationKoiSale)
        {
            try {
                _context.CertificationKoiSales.Update(certificationKoiSale); 
                _context.SaveChanges();
                return true;
            } catch (Exception ex) { return false; }
        }
    }
}
