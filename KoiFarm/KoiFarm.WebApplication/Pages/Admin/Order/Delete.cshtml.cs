using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.WebApplication.Pages.Customers.Order
{
    public class DeleteModel : PageModel
    {
        private readonly KoiFarm.Repositories.Entities.KoiFarmContext _context;

        public DeleteModel(KoiFarm.Repositories.Entities.KoiFarmContext context)
        {
            _context = context;
        }

        [BindProperty]
        public KoiOrder KoiOrder { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koiorder = await _context.KoiOrders.FirstOrDefaultAsync(m => m.OrderId == id);

            if (koiorder == null)
            {
                return NotFound();
            }
            else
            {
                KoiOrder = koiorder;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koiorder = await _context.KoiOrders.FindAsync(id);
            if (koiorder != null)
            {
                KoiOrder = koiorder;
                _context.KoiOrders.Remove(KoiOrder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
