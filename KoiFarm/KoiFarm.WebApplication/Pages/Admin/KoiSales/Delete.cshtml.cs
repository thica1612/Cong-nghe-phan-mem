using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;
using KoiFarm.Services.Interfaces;

namespace KoiFarm.WebApplication.Pages.KoiSales
{
    public class DeleteModel : PageModel
    {

        private readonly IKoiSaleService _service;
        public DeleteModel(IKoiSaleService service)
        {
            _service=service;
        }

        [BindProperty]
        public KoiSale KoiSale { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koisale = await _service.GetKoiSaleById( id);

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

            _service.DelKoiSale( id);
           

            return RedirectToPage("./Index");
        }
    }
}
