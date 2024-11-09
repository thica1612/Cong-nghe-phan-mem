using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.WebApplication.Pages.Kois
{
    public class DetailsModel : PageModel
    {
        private readonly KoiFarm.Repositories.Entities.KoiFarmContext _context;

        public DetailsModel(KoiFarm.Repositories.Entities.KoiFarmContext context)
        {
            _context = context;
        }

        public Koi Koi { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koi = await _context.Kois.FirstOrDefaultAsync(m => m.KoiId == id);
            if (koi == null)
            {
                return NotFound();
            }
            else
            {
                Koi = koi;
            }
            return Page();
        }
    }
}
