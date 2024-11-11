using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarm.Repositories.Entities;
using KoiFarm.Services.Interfaces;
using KoiFarm.Services;

namespace KoiFarm.WebApplication.Pages.Kois
{
    public class CreateModel : PageModel
    {
        private readonly IKoiService _service;

        public CreateModel(IKoiService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Koi Koi { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                bool result = _service.AddKoi(Koi);
                if (result)
                {
                    return RedirectToPage("./Index"); 
                }
                else
                {
                    ModelState.AddModelError("", "Không thể thêm cá Koi. Vui lòng thử lại.");
                    return Page();
                }
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi không xác định. Vui lòng thử lại.");
                return Page();
            }
        }
    }
}
