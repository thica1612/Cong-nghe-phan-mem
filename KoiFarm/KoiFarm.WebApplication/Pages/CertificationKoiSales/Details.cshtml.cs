using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.WebApplication.Pages.CertificationKoiSales
{
    public class DetailsModel : PageModel
    {
        private readonly KoiFarm.Repositories.Entities.KoiFarmContext _context;

        public DetailsModel(KoiFarm.Repositories.Entities.KoiFarmContext context)
        {
            _context = context;
        }

        public CertificationKoiSale CertificationKoiSale { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificationkoisale = await _context.CertificationKoiSales.FirstOrDefaultAsync(m => m.CertificationKsid == id);
            if (certificationkoisale == null)
            {
                return NotFound();
            }
            else
            {
                CertificationKoiSale = certificationkoisale;
            }
            return Page();
        }
    }
}
