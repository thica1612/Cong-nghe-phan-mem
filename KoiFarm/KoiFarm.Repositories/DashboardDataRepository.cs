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
    public class DashboardDataRepository : IDashboardDataRepository
    {
        private readonly KoiFarmContext _context;

        public DashboardDataRepository(KoiFarmContext context)
        {
            _context = context;
        }
        public bool AddReport(DashboardDatum report)
        {
            try
            {
                _context.DashboardData.Add(report);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelReport(string reportId)
        {
            try
            {
                var objDel = _context.DashboardData.Where(p => p.ReportId.Equals(reportId)).FirstOrDefault();
                if (objDel != null)
                {
                    _context.DashboardData.Remove(objDel);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex) { throw new NotImplementedException(ex.ToString()); }
        }

        public bool DelReport(DashboardDatum report)
        {
            try
            {
                _context.DashboardData.Remove(report);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { throw new NotImplementedException(ex.ToString()); return false; }
        }

        public async Task<List<DashboardDatum>> GetAllReports()
        {
            return await _context.DashboardData.ToListAsync();
        }

        public async Task<DashboardDatum> GetReportById(string reportId)
        {
            return await _context.DashboardData.Where(p => p.ReportId.Equals(reportId)).FirstOrDefaultAsync();
        }

        public bool UpReport(DashboardDatum report)
        {
            try
            {
                _context.DashboardData.Update(report);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }
    }
}
