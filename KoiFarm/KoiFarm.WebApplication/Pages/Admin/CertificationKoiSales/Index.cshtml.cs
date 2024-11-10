using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;
using KoiFarm.Services.Interfaces;

namespace KoiFarm.WebApplication.Pages.CertificationKoiSales
{
    public class IndexModel : PageModel
    {
        private readonly ICertificationKoiSaleService _service;

        public IndexModel(ICertificationKoiSaleService service)
        {
            _service = service;
        }

        public IList<CertificationKoiSale> CertificationKoiSale { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CertificationKoiSale = await _service.CertificationKoiSales();
        }
    }
}
