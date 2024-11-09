using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.WebApplication.Pages.KoiSales
{
    public class EditModel : PageModel
    {
        private readonly KoiFarm.Repositories.Entities.KoiFarmContext _context;

        public EditModel(KoiFarm.Repositories.Entities.KoiFarmContext context)
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

            var koisale =  await _context.KoiSales.FirstOrDefaultAsync(m => m.KoiSaleId == id);
            if (koisale == null)
            {
                return NotFound();
            }
            KoiSale = koisale;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(KoiSale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KoiSaleExists(KoiSale.KoiSaleId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool KoiSaleExists(string id)
        {
            return _context.KoiSales.Any(e => e.KoiSaleId == id);
        }
    }
}
