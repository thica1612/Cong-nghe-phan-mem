using KoiFarm.Repositories.Entities;
using KoiFarm.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiFarm.WebApplication.Pages.Customer
{
    public class ProfileModel : PageModel
    {
        private readonly IKoiUserService _userService;

        public ProfileModel(IKoiUserService userService)
        {
            _userService = userService;
        }

        public KoiUser User { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            User = await _userService.GetKoiUserById(id);
            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}