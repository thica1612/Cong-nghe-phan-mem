using KoiFarm.Repositories.Entities;
using KoiFarm.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiFarm.WebApplication.Pages.Customer
{
    public class DetailKoisModel : PageModel
    {
        private readonly IKoiService _service;
        private readonly IOrderService _orderService;


        public DetailKoisModel(IKoiService service, IOrderService orderService)
        {
            _service = service;
            _orderService = orderService;
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

        public async Task<IActionResult> OnPostCartAsync(string koiId, int quantity)
        {
            var userIdstr = HttpContext.Session.GetString("CustomerId");
            if (userIdstr == null)
            {
                return Redirect("/Customer/Login");
            }

            var userId = Guid.Parse(userIdstr);

            await _orderService.AddToOrderAsync(userId, koiId, quantity);
            return Page();
        }
    }
}
