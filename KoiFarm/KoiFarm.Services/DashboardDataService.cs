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
    public class DashboardDataService : IDashboardDataService
    {
        private readonly IDashboardDataRepository _repository;
        public DashboardDataService(IDashboardDataRepository repository)
        {
            _repository = repository;
        }
        public bool AddReport(DashboardDatum report)
        {
            return _repository.AddReport(report);
        }

        public bool DelReport(string reportId)
        {
            return _repository.DelReport(reportId);
        }

        public bool DelReport(DashboardDatum report)
        {
            return _repository.DelReport(report);
        }

        public Task<List<DashboardDatum>> GetAllReports()
        {
            return _repository.GetAllReports();
        }

        public Task<DashboardDatum> GetReportById(string reportId)
        {
            return _repository.GetReportById(reportId);
        }

        public bool UpReport(DashboardDatum report)
        {
            return _repository.UpReport(report);
        }
    }
}
