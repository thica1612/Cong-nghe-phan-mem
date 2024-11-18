using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using KoiFarm.Services.Interfaces;
using KoiFarm.Repositories.Entities;
using KoiFarm.WebApplication.Models;

namespace KoiFarm.WebApplication.Pages
{
    public class FeedConsignModel : PageModel
    {
        private readonly IFeedConsignmentService _feedConsignmentService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public FeedConsignModel(
            IFeedConsignmentService feedConsignmentService,
            IWebHostEnvironment webHostEnvironment,
            UserManager<ApplicationUser> userManager)
        {
            _feedConsignmentService = feedConsignmentService;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        [BindProperty]
        public FeedConsignment FeedConsignment { get; set; }

        public async Task<IActionResult> OnPostAsync(IFormFile certificateFile, IFormFile imageFile)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Customer/SignIn");
            }

            string certificateFileName = null;
            string imageFileName = null;

            // Upload certificate file
            if (certificateFile != null)
            {
                certificateFileName = await UploadFile(certificateFile, "certificates");
            }

            // Upload image file
            if (imageFile != null)
            {
                imageFileName = await UploadFile(imageFile, "images");
            }

            FeedConsignment.UserId = user.Id;

            var success = await _feedConsignmentService.AddAsync(FeedConsignment, certificateFileName, imageFileName);

            if (!success)
            {
                ModelState.AddModelError("", "Failed to save feed consignment");
                return Page();
            }

            return RedirectToPage("./Index");
        }

        private async Task<string> UploadFile(IFormFile file, string folderPath)
        {
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


