using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;
using KoiFarm.WebApplication.Models;
using Microsoft.AspNetCore.Http;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.WebApplication.Pages
{
    public class SellConsignModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public SellConsignModel(
            ApplicationDbContext context,
            IWebHostEnvironment webHostEnvironment,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        [BindProperty]
        public SellConsignment SellConsignment { get; set; }

        public async Task<IActionResult> OnPostAsync(IFormFile certificateFile, IFormFile imageFile)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Customer/SignIn");
            }

            // Xử lý upload file chứng nhận
            if (certificateFile != null)
            {
                string certificateFileName = await UploadFile(certificateFile, "certificates");
                SellConsignment.Certificate = certificateFileName;
            }

            // Xử lý upload hình ảnh
            if (imageFile != null)
            {
                string imageFileName = await UploadFile(imageFile, "images");
                SellConsignment.Image = imageFileName;
            }

            // Kiểm tra tính hợp lệ của dữ liệu sau khi các trường đã được gán giá trị
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SellConsignment.CreatedDate = DateTime.Now;
            SellConsignment.UserId = user.Id;

            _context.SellConsignments.Add(SellConsignment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


        private async Task<string> UploadFile(IFormFile file, string folderPath)
        {
            if (file == null || file.Length == 0)
                return null;

            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return uniqueFileName;
        }
    }
}


