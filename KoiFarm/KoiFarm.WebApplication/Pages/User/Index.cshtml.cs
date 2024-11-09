using KoiFarm.Services.Interfaces;
using KoiFarm.Repositories.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarm.WebApplication.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly IKoiUserService _userService;

        public IndexModel(IKoiUserService userService)
        {
            _userService = userService;
        }

        public List<KoiUser> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _userService.KoiUsers();
        }
    }
}
