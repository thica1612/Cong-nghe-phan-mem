using KoiFarm.Repositories.Entities;
using KoiFarm.Services;
using KoiFarm.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiFarm.WebApplication.Pages
{
    public class CartModel : PageModel
    {
        private readonly IOrderService _service;

        public CartModel(IOrderService service)
        {
            _service = service;
        }

        public KoiOrder CurrentOrder { get; set; } = null!;


        public async Task<IActionResult> OnGetCartAsync()
        {
            var userIdstr = HttpContext.Session.GetString("CustomerId");
            if (userIdstr == null)
            {
                return Redirect("/Customer/Login");
            }

            var userId = Guid.Parse(userIdstr);

            await _service.GetCurrentOrderAsync(userId);
            return Page();
        }
        
    }
}
