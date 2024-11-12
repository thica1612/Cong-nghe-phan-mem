using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.WebApplication.Pages.Customers.OrderDetail
{
    public class IndexModel : PageModel
    {
        private readonly KoiFarm.Repositories.Entities.KoiFarmContext _context;

        public IndexModel(KoiFarm.Repositories.Entities.KoiFarmContext context)
        {
            _context = context;
        }

        public IList<KoiFarm.Repositories.Entities.OrderDetail> OrderDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            OrderDetail = await _context.OrderDetails
                .Include(o => o.Koi)
                .Include(o => o.Order).ToListAsync();
        }
    }
}
