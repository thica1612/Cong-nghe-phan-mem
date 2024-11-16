using KoiFarm.Repositories.Entities;
using KoiFarm.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace KoiFarm.WebApplication.Pages.Admin.User
{
    public class CreateModel : PageModel
    {
        private readonly IKoiUserService _userService;

        public CreateModel(IKoiUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public KoiUser User { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool result = await _userService.SignUpUser(User);
            if (result)
            {
                // Chuyển hướng về trang Index sau khi lưu thành công
                return RedirectToPage("./Index");
            }
            else
            {
                // Xử lý khi thêm người dùng thất bại
                ModelState.AddModelError(string.Empty, "Không thể thêm người dùng.");
                return Page();
            }
        }
    }
}