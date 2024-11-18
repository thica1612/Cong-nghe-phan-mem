// Models/ApplicationUser.cs
using Microsoft.AspNetCore.Identity;

namespace KoiFarm.WebApplication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        // Thêm các thuộc tính khác nếu cần
    }
}


