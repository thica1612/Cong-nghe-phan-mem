
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

        [BindProperty]
        public string UserNameorEmail { get; set; }

        [BindProperty]
        public string UserPassword { get; set; }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(string userNameorEmail, string userPassword)
        {
            if (string.IsNullOrEmpty(UserNameorEmail) || string.IsNullOrEmpty(UserPassword))
            {
                TempData["ErrorMessage"] = "Tên đăng nhập hoặc mật khẩu không được để trống.";
                return Page();
            }
            var user = await _service.AuthenUser(userNameorEmail, userPassword);
            if (user == true)
            {
                HttpContext.Session.SetString("Username", userNameorEmail);
                TempData["SuccessMessage"] = "Đăng nhập thành công";
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
