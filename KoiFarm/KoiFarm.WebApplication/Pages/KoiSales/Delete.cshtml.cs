using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.WebApplication.Pages.KoiSales
{
    public class DeleteModel : PageModel
    {
        private readonly KoiFarm.Repositories.Entities.KoiFarmContext _context;

        public DeleteModel(KoiFarm.Repositories.Entities.KoiFarmContext context)
        {
            _context = context;
        }

        [BindProperty]
        public KoiSale KoiSale { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koisale = await _context.KoiSales.FirstOrDefaultAsync(m => m.KoiSaleId == id);

            if (koisale == null)
            {
                return NotFound();
            }
            else
            {
                KoiSale = koisale;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koisale = await _context.KoiSales.FindAsync(id);
            if (koisale != null)
            {
                KoiSale = koisale;
                _context.KoiSales.Remove(KoiSale);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
