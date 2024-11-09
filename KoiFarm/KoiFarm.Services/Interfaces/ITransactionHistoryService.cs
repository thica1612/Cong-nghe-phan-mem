using KoiFarm.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarm.Services.Interfaces
{
    public interface ITransactionHistoryService
    {
        Task<List<TransactionHistory>> GetAllTransactions();
        Task<TransactionHistory> GetTransactionById(int id);
        Task<bool> AddTransaction(TransactionHistory transaction);
    }
}
