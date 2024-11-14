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

        public IList<Koi> Koi { get; set; }
        public async Task OnGetAsync()
        {
            Koi = await _service.KoiSales();
        }
    }
}
