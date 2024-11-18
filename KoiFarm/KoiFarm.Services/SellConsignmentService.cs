using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using KoiFarm.Services.Interfaces;

namespace KoiFarm.Services
{
    public class SellConsignmentService : ISellConsignmentService
    {
        private readonly ISellConsignmentRepository _repository;

        public SellConsignmentService(ISellConsignmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SellConsignment>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<SellConsignment> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> AddAsync(SellConsignment sellConsignment, string certificateFilePath, string imageFilePath)
        {
            if (sellConsignment == null) return false;

            sellConsignment.CreatedDate = DateTime.Now;
            sellConsignment.Certificate = certificateFilePath;
            sellConsignment.Image = imageFilePath;

            await _repository.AddAsync(sellConsignment);
            return true;
        }

        public async Task<bool> UpdateAsync(SellConsignment sellConsignment)
        {
            if (sellConsignment == null) return false;

            await _repository.UpdateAsync(sellConsignment);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
