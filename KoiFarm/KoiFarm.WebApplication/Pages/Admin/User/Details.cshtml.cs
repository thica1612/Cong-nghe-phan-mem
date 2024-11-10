using KoiFarm.Services.Interfaces;
using KoiFarm.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiFarm.WebApplication.Pages.User
{
    public class DetailsModel : PageModel
    {
        private readonly IKoiUserService _userService;

        public DetailsModel(IKoiUserService userService)
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
    }
}
