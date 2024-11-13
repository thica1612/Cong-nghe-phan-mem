using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.WebApplication.Pages.Admin.DashboardData
{
    public class DeleteModel : PageModel
    {
        private readonly KoiFarm.Repositories.Entities.KoiFarmContext _context;

        public DeleteModel(KoiFarm.Repositories.Entities.KoiFarmContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DashboardDatum DashboardDatum { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dashboarddatum = await _context.DashboardData.FirstOrDefaultAsync(m => m.ReportId == id);

            if (dashboarddatum == null)
            {
                return NotFound();
            }
            else
            {
                DashboardDatum = dashboarddatum;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dashboarddatum = await _context.DashboardData.FindAsync(id);
            if (dashboarddatum != null)
            {
                DashboardDatum = dashboarddatum;
                _context.DashboardData.Remove(DashboardDatum);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
