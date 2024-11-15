
using KoiFarm.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiFarm.WebApplication.Pages
{
    public class SignInModel : PageModel
    {
        private readonly IKoiUserService _service;

        public SignInModel(IKoiUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(string userNameorEmail, string userPassword)
        {
            var user = await _service.AuthenUser(userNameorEmail, userPassword);
            if (user == true)
            {
                HttpContext.Session.SetString("Username", userNameorEmail);
                return RedirectToPage("/Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Tên đăng nhập hoặc mật khẩu không hợp lệ";
                return RedirectToPage("/Customer/SignIn");
            }
        }
    }
}
