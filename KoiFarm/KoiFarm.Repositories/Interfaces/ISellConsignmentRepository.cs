using System.Threading.Tasks;
using System.Collections.Generic;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.Repositories.Interfaces
{
    public interface ISellConsignmentRepository
    {
        Task<List<SellConsignment>> GetAllAsync();
        Task<SellConsignment> GetByIdAsync(int id);
        Task AddAsync(SellConsignment sellConsignment);
        Task UpdateAsync(SellConsignment sellConsignment);
        Task DeleteAsync(int id);
    }
}
