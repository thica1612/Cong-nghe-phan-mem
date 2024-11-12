using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.Repositories.Interfaces
{
    public interface IConsignmentRepository
    {
        Task<List<Consignment>> GetAllConsignments();
        Task<List<Consignment>> GetConsignmentsByType(int consignmentType); // Lấy theo loại ký gửi
        Task<Consignment> GetConsignmentById(int consignmentId);
        Task<bool> AddConsignment(Consignment consignment);
        Task<bool> UpdateConsignment(Consignment consignment);
        Task<bool> DeleteConsignment(int consignmentId);
    }
}


