using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using KoiFarm.Services.Interfaces;

namespace KoiFarm.Services
{
    public class FeedConsignmentService : IFeedConsignmentService
    {
        private readonly IFeedConsignmentRepository _repository;

        public FeedConsignmentService(IFeedConsignmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FeedConsignment>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<FeedConsignment> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> AddAsync(FeedConsignment feedConsignment, string certificateFilePath, string imageFilePath)
        {
            if (feedConsignment == null) return false;

            feedConsignment.CreatedDate = DateTime.Now;
            feedConsignment.Certificate = certificateFilePath;
            feedConsignment.Image = imageFilePath;

            await _repository.AddAsync(feedConsignment);
            return true;
        }

        public async Task<bool> UpdateAsync(FeedConsignment feedConsignment)
        {
            if (feedConsignment == null) return false;

            await _repository.UpdateAsync(feedConsignment);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
