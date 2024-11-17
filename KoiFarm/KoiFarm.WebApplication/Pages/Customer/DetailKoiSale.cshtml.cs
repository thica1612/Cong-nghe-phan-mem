using KoiFarm.Repositories.Entities;
using KoiFarm.Services;
using KoiFarm.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiFarm.WebApplication.Pages.Customer
{
    public class DetailKoiSaleModel : PageModel
    {
        private readonly IKoiSaleService _service;
        private readonly IOrderService _orderService;


        public DetailKoiSaleModel(IKoiSaleService service, IOrderService orderService)
        {
            _service = service;
            _orderService = orderService;
        }

        public KoiSale Koi {  get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koi = await _service.GetKoiSaleById(id);
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
            Console.WriteLine($"\nSession: {userIdstr}");
            if (userIdstr == null)
            {
                return Redirect("/Customer/SignIn");
            }

            var userId = Guid.Parse(userIdstr);

            await _orderService.AddToOrderAsync(userId, koiId, quantity);

            return RedirectToPage("/Customer/Cart");

        }
    }
}
