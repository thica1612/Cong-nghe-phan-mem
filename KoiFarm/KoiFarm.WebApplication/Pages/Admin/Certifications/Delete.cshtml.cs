using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;
using KoiFarm.Services.Interfaces;

namespace KoiFarm.WebApplication.Pages.Certifications
{
    public class DeleteModel : PageModel
    {
        private readonly ICertificationService _service;

        public DeleteModel(ICertificationService service)
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
            else
            {
                Certification = certification;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string CertificationID)
        {
            if (CertificationID == null)
            {
                return NotFound();
            }
            _service.DelCertification(Certification);


            return RedirectToPage("./Index");
        }
    }
}
