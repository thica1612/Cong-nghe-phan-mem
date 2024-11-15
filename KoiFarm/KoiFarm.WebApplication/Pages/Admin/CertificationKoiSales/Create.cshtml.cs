using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarm.Repositories.Entities;
using KoiFarm.Services.Interfaces;

namespace KoiFarm.WebApplication.Pages.CertificationKoiSales
{
    public class CreateModel : PageModel
    {
        private readonly ICertificationKoiSaleService _service;

        public CreateModel(ICertificationKoiSaleService service)
        {
            _service = service;
        }

        public IActionResult OnGet(string id)
        {

            if (string.IsNullOrEmpty(id))
            {
                ModelState.AddModelError("", "CertificationKSID is required.");
                return Page();
            }
            ViewData["KoiSaleId"] = new SelectList((System.Collections.IEnumerable)_service.GetCertificationKoiSaleByID(id), "KoiSaleId", "KoiSaleId");
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

            _service.AddCertificationKoiSale(CertificationKoiSale);
            return RedirectToPage("./Index");
        }
    }
}
