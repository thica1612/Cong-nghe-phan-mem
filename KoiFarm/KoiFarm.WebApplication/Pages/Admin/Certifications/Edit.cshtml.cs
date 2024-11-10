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

namespace KoiFarm.WebApplication.Pages.Certifications
{
    public class EditModel : PageModel
    {
        private readonly ICertificationService _service;

        public EditModel(ICertificationService service)
        {
            _service = service;
        }

        [BindProperty]
        public Certification Certification { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string CertificationID)
        {
            if (CertificationID == null)
            {
                return NotFound();
            }

            var certification = await _service.GetCertificationByID(CertificationID);
            if (certification == null)
            {
                return NotFound();
            }
            Certification = certification;
            ViewData["KoiId"] = new SelectList((System.Collections.IEnumerable)_service.GetCertificationByID(CertificationID), "KoiId", "KoiId");
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
            _service.UpdCertification(Certification);
            return RedirectToPage("./Index");
        }
    }
}
