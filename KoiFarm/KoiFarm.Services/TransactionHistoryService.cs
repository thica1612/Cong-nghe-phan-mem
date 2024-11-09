using KoiFarm.Repositories;
using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using KoiFarm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarm.Services
{
    public class TransactionHistoryService : ITransactionHistoryService
    {
        private readonly ITransactionHistoryRepository _repository;

        public TransactionHistoryService(ITransactionHistoryRepository repository)
        {
            _repository = repository;
        }

        public Task<List<TransactionHistory>> GetAllTransactions() => _repository.GetAllTransactions();
        public Task<TransactionHistory> GetTransactionById(int id) => _repository.GetTransactionById(id);
        public Task<bool> AddTransaction(TransactionHistory transaction) => _repository.AddTransaction(transaction);
    }
}
