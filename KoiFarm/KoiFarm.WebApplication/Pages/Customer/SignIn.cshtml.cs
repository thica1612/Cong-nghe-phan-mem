
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

            HttpContext.Session.Remove("Username");
            int failedAttempts = HttpContext.Session.GetInt32("FailedLoginAttempts") ?? 0;


            if (string.IsNullOrEmpty(userNameorEmail) || string.IsNullOrEmpty(userPassword))
            {
                return Page();
            }

            var user = await _service.AuthenUser(userNameorEmail, userPassword);

            if (user) 
            {
                HttpContext.Session.SetString("Username", userNameorEmail);
                return RedirectToPage("/Index");
            }
            else
            {
                // Đăng nhập thất bại, tăng số lần đăng nhập sai
                failedAttempts++;
                HttpContext.Session.SetInt32("FailedLoginAttempts", failedAttempts);

              
                // Lỗi đăng nhập
                TempData["ErrorMessage"] = "Tên đăng nhập hoặc mật khẩu không hợp lệ";
                return RedirectToPage("/Customer/SignIn");
            }
        }
    }
}
