using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;
using KoiFarm.Services.Interfaces;

namespace KoiFarm.WebApplication.Pages.KoiSales
{
    public class IndexModel : PageModel
    {
        private readonly IKoiSaleService _service;

        public IndexModel(IKoiSaleService service)
        {
            _service = service; 
        }

        public IList<KoiSale> KoiSale { get;set; } = default!;

        public async Task OnGetAsync()
        {
            KoiSale = await _service.KoiSales();
        }
    }
}
