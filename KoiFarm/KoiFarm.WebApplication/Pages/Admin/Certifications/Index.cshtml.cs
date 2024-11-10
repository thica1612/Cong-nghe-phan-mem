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
    public class IndexModel : PageModel
    {
        private readonly ICertificationService _service;

        public IndexModel(ICertificationService service)
        {
            _service = service;
        }

        public IList<Certification> Certification { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Certification = await _service.Certifications();
        }
    }
}
