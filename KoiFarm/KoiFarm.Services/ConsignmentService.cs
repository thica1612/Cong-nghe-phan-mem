using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarm.Repositories;
using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using KoiFarm.Services.Interfaces;

namespace KoiFarm.Services
{
    public class ConsignmentService : IConsignmentService
    {
        private readonly IConsignmentRepository _repository;
        public ConsignmentService(IConsignmentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Consignment>> GetAllConsignments()
        {
            return _repository.GetAllConsignments();
        }

        public Task<List<Consignment>> GetConsignmentsByType(int consignmentType)
        {
            return _repository.GetConsignmentsByType(consignmentType);
        }

        public Task<Consignment> GetConsignmentById(int consignmentId)
        {
            return _repository.GetConsignmentById(consignmentId);
        }

        public Task<bool> AddConsignment(Consignment consignment)
        {
            return _repository.AddConsignment(consignment);
        }

        public Task<bool> UpdateConsignment(Consignment consignment)
        {
            return _repository.UpdateConsignment(consignment);
        }

        public Task<bool> DeleteConsignment(int consignmentId)
        {
            return _repository.DeleteConsignment(consignmentId);
        }
    }
}


