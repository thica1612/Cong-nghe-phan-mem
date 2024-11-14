using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiFarm.WebApplication.Pages
{
    public class SignInModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public SignInModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage {  get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) {
                ErrorMessage = "Thông tin đăng nhập không hợp lệ";
                return Page();
            }

            var user = await _userManager.FindByNameAsync(Username) ?? await _userManager.FindByEmailAsync(Username);
            if (user == null)
            {
                ErrorMessage = "Tên người dùng hoặc mật khẩu không đúng";
                return Page();
            }

            var result = await _signInManager.PasswordSignInAsync(user, Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                ErrorMessage = "Tên người dùng hoặc mật khẩu không đúng";
                return Page();
            }
        }
    }
}
