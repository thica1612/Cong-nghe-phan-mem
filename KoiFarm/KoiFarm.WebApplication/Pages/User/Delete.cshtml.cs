using KoiFarm.Services.Interfaces;
using KoiFarm.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiFarm.WebApplication.Pages.User
{
    public class DeleteModel : PageModel
    {
        private readonly IKoiUserService _userService;

        public DeleteModel(IKoiUserService userService)
        {
            _userService = userService;
        }

        public KoiUser User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _userService.GetKoiUserById(id);
            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            bool result = _userService.DelKoiUser(User);
            if (result)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                // Xử lý khi cập nhật thất bại, có thể hiển thị lại trang với thông báo lỗi
                ModelState.AddModelError(string.Empty, "Cập nhật người dùng thất bại.");
                return Page();
            }

        }
    }
}
