using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarm.Repositories.Entities;
using KoiFarm.Services.Interfaces;

namespace KoiFarm.WebApplication.Pages.Certifications
{
    public class CreateModel : PageModel
    {
        private readonly ICertificationService _service;

        public CreateModel(ICertificationService service)
        {
            _service = service;
        }

        public IActionResult OnGet(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ModelState.AddModelError("", "CertificationID is required.");
                return Page();
            }
            ViewData["KoiId"] = new SelectList((System.Collections.IEnumerable)_service.GetCertificationByID(id), "KoiId", "KoiId");
            return Page();
        }

        [BindProperty]
        public Certification Certification { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.AddCertification(Certification);
            return RedirectToPage("./Index");
        }
    }
}
