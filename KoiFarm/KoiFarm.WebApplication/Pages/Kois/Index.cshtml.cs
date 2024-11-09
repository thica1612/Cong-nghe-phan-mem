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
    public class IndexModel : PageModel
    {
        private readonly IKoiService _service;

        public IndexModel(IKoiService service)
        {
            _service = service;
        }

        public IList<Koi> Koi { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Koi = await _service.Kois();
        }
    }
}
