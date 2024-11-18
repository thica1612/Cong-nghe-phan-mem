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
        private readonly IOrderDetailService _orderDetailService;

        public CartModel(IOrderService service, IOrderDetailService orderDetailService)
        {
            _service = service;
            _orderDetailService = orderDetailService;
        }

        public KoiOrder CurrentOrder { get; set; } = null!;
        public List<OrderDetail> CartItems { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var userIdstr = HttpContext.Session.GetString("CustomerId");
            if (userIdstr != null)
            {

                var userId = Guid.Parse(userIdstr);

                var order = await _service.GetCurrentOrderAsync(userId);

                if (order != null)
                {
                    CurrentOrder = order;
                    CartItems = await _orderDetailService.GetAllOrderByUser(order.OrderId);
                }
            }
        }

        public IActionResult OnPostRemove(int orderDetailId)
        {

            var orderDetail = _orderDetailService.GetOrderDetailById(orderDetailId);
            if (orderDetail != null)
            {
                _orderDetailService.DelOrderDetail(orderDetailId);
            }
            if (CurrentOrder != null)
            {
                if (orderDetail == null)
                {
                    return Page();
                }
            }
            return RedirectToPage();
        }

        public IActionResult OnPostPayment()
        {
            return RedirectToPage("/Index");
        }
    }
}
