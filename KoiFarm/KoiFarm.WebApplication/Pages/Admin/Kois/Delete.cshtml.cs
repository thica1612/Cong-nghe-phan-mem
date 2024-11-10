using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;
using KoiFarm.Services.Interfaces;

namespace KoiFarm.WebApplication.Pages.Kois
{
    public class DeleteModel : PageModel
    {
        private readonly IKoiService _service;

        public DeleteModel(IKoiService service)
        {
            _service = service;
        }

        [BindProperty]
        public Koi Koi { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var koi = await 
                _service.GetKoiById(id);

            if (koi == null)
            {
                return NotFound();
            }
            else
            {
                Koi = koi;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koi = await _service.GetKoiById(id);
            if (koi != null)
            {
                Koi = koi;
                _service.DelKoi(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
