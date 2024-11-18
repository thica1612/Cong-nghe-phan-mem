using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.Repositories.Interfaces
{
    public interface IFeedConsignmentRepository
    {
        Task<List<FeedConsignment>> GetAllAsync();
        Task<FeedConsignment> GetByIdAsync(int id);
        Task AddAsync(FeedConsignment feedConsignment);
        Task UpdateAsync(FeedConsignment feedConsignment);
        Task DeleteAsync(int id);
    }
}
