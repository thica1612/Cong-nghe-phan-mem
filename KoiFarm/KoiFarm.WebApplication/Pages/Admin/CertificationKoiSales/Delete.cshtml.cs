using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;
using KoiFarm.Services.Interfaces;

namespace KoiFarm.WebApplication.Pages.CertificationKoiSales
{
    public class DeleteModel : PageModel
    {
        private readonly ICertificationKoiSaleService _service;

        public DeleteModel(ICertificationKoiSaleService service)
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

            var certificationkoisale = await _service.GetCertificationKoiSaleByID(CertificationKSID);

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

        public async Task<IActionResult> OnPostAsync(string CertificationKSID)
        {
            if (CertificationKSID == null)
            {
                return NotFound();
            }
            _service.DelCertificationKoiSale(CertificationKSID);

            return RedirectToPage("./Index");
        }
    }
}
