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

        public async Task<IActionResult> OnGetAsync(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var certificationkoisale = await _service.GetCertificationKoiSaleByID(id);

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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _service.DelCertificationKoiSale(id);

            return RedirectToPage("./Index");
        }

       
    }
}
