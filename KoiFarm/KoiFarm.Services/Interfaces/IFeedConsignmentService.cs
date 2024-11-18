using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.Services.Interfaces
{
    public interface IFeedConsignmentService
    {
        Task<List<FeedConsignment>> GetAllAsync();
        Task<FeedConsignment> GetByIdAsync(int id);
        Task<bool> AddAsync(FeedConsignment feedConsignment, string certificateFilePath, string imageFilePath);
        Task<bool> UpdateAsync(FeedConsignment feedConsignment);
        Task<bool> DeleteAsync(int id);
    }
}
