using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using KoiFarm.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiFarm.WebApplication.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly IKoiUserService _service;

        public SignUpModel(IKoiUserService service)
        {
            _service = service;
        }

        [BindProperty]
        public KoiUser account { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (account.UserPassword != Request.Form["password2"])
                {
                    TempData["ErrorMessage"] = "Mật khẩu và xác nhận mật khẩu không khớp";
                    return Page();
                }
                var result = await _service.SignUpUser(account);
                if (result == true)
                {
                    TempData["SuccessMessage"] = "Đăng ký thành công";
                    return RedirectToPage("/SignIn");
                }
                else
                {
                    TempData["ErrorMessage"] = "Tên đăng nhập hoặc Email đã tồn tại";
                    return Page(); 
                }
            }
            return Page();
        }
    }
}
