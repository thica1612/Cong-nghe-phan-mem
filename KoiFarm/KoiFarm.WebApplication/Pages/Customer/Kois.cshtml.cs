using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFarm.Services;
using KoiFarm.Repositories.Entities;
using KoiFarm.Services.Interfaces;

namespace KoiFarm.WebApplication.Pages
{
    public class KoisModel : PageModel
    {
        private readonly IKoiService _service;

        public KoisModel(IKoiService service)
        {
            _service = service;
        }

        public Koi Koiss { get; set; }

        public IList<Koi> Koi { get; set; }
        public async Task OnGetAsync()
        {
            Koi = await _service.KoiSales();
        }

        
        public IActionResult Kois(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return RedirectToPage("/Index");
            }
            var koi = _service.GetKoiByName(searchTerm);
            if (koi != null) {
                return RedirectToAction("DetailKois", "Customer",new {id = Koiss.KoiId});
            }
            else
            {
                TempData["Message"] = "Không tìm thấy sản phẩm";
            }
            return Page();
        }
    }
}
