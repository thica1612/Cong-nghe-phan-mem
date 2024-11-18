using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.Services.Interfaces
{
    public interface ISellConsignmentService
    {
        Task<List<SellConsignment>> GetAllAsync();
        Task<SellConsignment> GetByIdAsync(int id);
        Task<bool> AddAsync(SellConsignment sellConsignment, string certificateFilePath, string imageFilePath);
        Task<bool> UpdateAsync(SellConsignment sellConsignment);
        Task<bool> DeleteAsync(int id);
    }
}
