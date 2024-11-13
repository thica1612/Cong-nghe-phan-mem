using KoiFarm.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarm.Services.Interfaces
{
    public interface IDashboardDataService
    {
        Task<List<DashboardDatum>> GetAllReports();
        Boolean DelReport(string reportId);
        Boolean DelReport(DashboardDatum report);
        Boolean AddReport(DashboardDatum report);
        Boolean UpReport(DashboardDatum report);
        Task<DashboardDatum> GetReportById(string reportId);
    }
}
