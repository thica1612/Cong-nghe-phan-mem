using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.WebApplication.Pages.Certifications
{
    public class DeleteModel : PageModel
    {
        private readonly KoiFarm.Repositories.Entities.KoiFarmContext _context;

        public DeleteModel(KoiFarm.Repositories.Entities.KoiFarmContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Certification Certification { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications.FirstOrDefaultAsync(m => m.CertificationId == id);

            if (certification == null)
            {
                return NotFound();
            }
            else
            {
                Certification = certification;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications.FindAsync(id);
            if (certification != null)
            {
                Certification = certification;
                _context.Certifications.Remove(Certification);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
