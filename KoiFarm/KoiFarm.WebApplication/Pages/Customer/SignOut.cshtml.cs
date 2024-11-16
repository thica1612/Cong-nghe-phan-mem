using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiFarm.WebApplication.Pages.Customer
{
    public class SignOutModel : PageModel
    {
        public IActionResult OnPost()
        {

            HttpContext.Session.Remove("Username");

           
            return RedirectToPage("/Index");
        }
    }
}
