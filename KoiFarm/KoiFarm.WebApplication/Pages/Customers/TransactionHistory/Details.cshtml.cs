﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.WebApplication.Pages.Customers.TransactionHistory
{
    public class DetailsModel : PageModel
    {
        private readonly KoiFarm.Repositories.Entities.KoiFarmContext _context;

        public DetailsModel(KoiFarm.Repositories.Entities.KoiFarmContext context)
        {
            _context = context;
        }

        public KoiFarm.Repositories.Entities.TransactionHistory TransactionHistory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionhistory = await _context.TransactionHistories.FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transactionhistory == null)
            {
                return NotFound();
            }
            else
            {
                TransactionHistory = transactionhistory;
            }
            return Page();
        }
    }
}
