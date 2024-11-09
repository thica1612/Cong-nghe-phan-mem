using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.WebApplication.Pages.CertificationKoiSales
{
    public class CreateModel : PageModel
    {
        private readonly KoiFarm.Repositories.Entities.KoiFarmContext _context;

        public CreateModel(KoiFarm.Repositories.Entities.KoiFarmContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["KoiSaleId"] = new SelectList(_context.KoiSales, "KoiSaleId", "KoiSaleId");
            return Page();
        }

        [BindProperty]
        public CertificationKoiSale CertificationKoiSale { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CertificationKoiSales.Add(CertificationKoiSale);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
