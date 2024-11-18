using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.WebApplication.Pages.Admin.Cart
{
    public class DeleteModel : PageModel
    {
        private readonly KoiFarm.Repositories.Entities.KoiFarmContext _context;

        public DeleteModel(KoiFarm.Repositories.Entities.KoiFarmContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koi = await _context.Kois.FindAsync(id);
            if (koi != null)
            {
                Koi = koi;
                _context.Kois.Remove(Koi);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
