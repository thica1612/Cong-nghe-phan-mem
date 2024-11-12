using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.WebApplication.Pages.Customers.OrderDetail
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
        ViewData["KoiId"] = new SelectList(_context.Kois, "KoiId", "KoiId");
        ViewData["OrderId"] = new SelectList(_context.KoiOrders, "OrderId", "CustomerId");
            return Page();
        }

        [BindProperty]
        public KoiFarm.Repositories.Entities.OrderDetail OrderDetail { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrderDetails.Add(OrderDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
