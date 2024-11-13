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
        private readonly IKoiSaleService _koiSaleService;

        public EditModel(ICertificationKoiSaleService service)
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

            var certificationkoisale =  await _service.GetCertificationKoiSaleByID(id);
            if (certificationkoisale == null)
            {
                return NotFound();
            }
            CertificationKoiSale = certificationkoisale;
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

            var isUpdated = _service.UpdCertificationKoiSale(CertificationKoiSale);

            if (!isUpdated)
            {
                ModelState.AddModelError(string.Empty, "Chỉnh sửa không thành công");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
