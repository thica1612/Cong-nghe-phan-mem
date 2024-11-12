using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.WebApplication.Pages.Customers.TransactionHistory
{
    public class IndexModel : PageModel
    {
        private readonly KoiFarm.Repositories.Entities.KoiFarmContext _context;

        public IndexModel(KoiFarm.Repositories.Entities.KoiFarmContext context)
        {
            _context = context;
        }

        public IList<KoiFarm.Repositories.Entities.TransactionHistory> TransactionHistory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TransactionHistory = await _context.TransactionHistories
                .Include(t => t.Customer).ToListAsync();
        }
    }
}
