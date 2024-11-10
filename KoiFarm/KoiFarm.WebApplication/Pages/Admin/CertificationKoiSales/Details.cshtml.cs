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
    public class DetailsModel : PageModel
    {
        private readonly ICertificationKoiSaleService _service;

        public DetailsModel(ICertificationKoiSaleService service)
        {
            _service = service;
        }

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
    }
}
