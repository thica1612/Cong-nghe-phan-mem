using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarm.Repositories
{
    public class TransactionHistoryRepository : ITransactionHistoryRepository
    {
        private readonly KoiFarmContext _dbContext;

        public TransactionHistoryRepository(KoiFarmContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TransactionHistory>> GetAllTransactions()
        {
            return await _dbContext.TransactionHistories.ToListAsync();
        }

        public async Task<TransactionHistory> GetTransactionById(int id)
        {
            return await _dbContext.TransactionHistories.FindAsync(id);
        }

        public async Task<bool> AddTransaction(TransactionHistory transaction)
        {
            try
            {
                await _dbContext.TransactionHistories.AddAsync(transaction);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
