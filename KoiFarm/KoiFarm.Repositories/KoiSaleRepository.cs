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
    public class KoiSaleRepository:IKoiSaleRepository
    {
        private readonly KoiFarmContext _context;
        public KoiSaleRepository(KoiFarmContext context) {
            _context = context;
        }

        public bool AddKoiSale(KoiSale koisale)
        {
            try
            {
                _context.KoiSales.Add(koisale);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DeleteKoiSale(KoiSale koisale)
        {
            try
            {
                _context.KoiSales.Remove(koisale);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { throw new NotImplementedException(ex.ToString()); return false; }
        }

        public bool DelKoiSale(string KoiSaleID)
        {
            try
            {
                var objDel = _context.KoiSales.Where(p => p.KoiSaleId.Equals(KoiSaleID)).FirstOrDefault();
                if (objDel != null)
                {
                    _context.KoiSales.Remove(objDel);
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

        public async Task<List<KoiSale>> GetAllKoiSale()
        {
            return await _context.KoiSales.ToListAsync();
        }

        public async Task<KoiSale> GetKoiSaleById(string KoiSaleID)
        {
            return await _context.KoiSales.Where(p => p.KoiSaleId.Equals(KoiSaleID)).FirstOrDefaultAsync();
        }

        public bool UpdateKoiSale(KoiSale koisale)
        {
            try
            {
                _context.KoiSales.Update(koisale);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }
    }
}
