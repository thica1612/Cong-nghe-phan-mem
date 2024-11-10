using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;
using KoiFarm.Services.Interfaces;

namespace KoiFarm.WebApplication.Pages.CertificationKoiSales
{
    public class EditModel : PageModel
    {
        private readonly ICertificationKoiSaleService _service;

        public EditModel(ICertificationKoiSaleService service)
        {
            _service = service;
        }

        [BindProperty]
        public CertificationKoiSale CertificationKoiSale { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string CertificationKSID)
        {
            if (CertificationKSID == null)
            {
                return NotFound();
            }

            var certificationkoisale =  await _service.GetCertificationKoiSaleByID(CertificationKSID);
            if (certificationkoisale == null)
            {
                return NotFound();
            }
            CertificationKoiSale = certificationkoisale;
            ViewData["KoiSaleId"] = new SelectList((System.Collections.IEnumerable)_service.GetCertificationKoiSaleByID(CertificationKSID), "KoiSaleId", "KoiSaleId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _service.UpdCertificationKoiSale(CertificationKoiSale);
            return RedirectToPage("./Index");
        }
    }
}
