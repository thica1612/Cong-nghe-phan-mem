using KoiFarm.Repositories.Entities;
using KoiFarm.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiFarm.WebApplication.Pages
{
    public class SaleModel : PageModel
    {
        private readonly IKoiSaleService _service;

        public SaleModel(IKoiSaleService service)
        {
            _service = service;
        }

        public IList<KoiSale> KoiSale { get; set; }
        public async Task OnGetAsync()
        {
            KoiSale = await _service.KoiSales();
        }

    }
}
