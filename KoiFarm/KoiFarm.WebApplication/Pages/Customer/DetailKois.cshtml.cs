using KoiFarm.Repositories.Entities;
using KoiFarm.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiFarm.WebApplication.Pages.Customer
{
    public class DetailKoisModel : PageModel
    {
        private readonly IKoiService _service;

        public DetailKoisModel(IKoiService service)
        {
            _service = service;
        }
        public Koi Koi { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koi = await _service.GetKoiById(id);
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
    }
}
