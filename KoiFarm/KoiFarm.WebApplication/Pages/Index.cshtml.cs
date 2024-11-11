using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarm.Repositories.Entities;
using KoiFarm.Services.Interfaces;

namespace KoiFarm.WebApplication.Pages
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
