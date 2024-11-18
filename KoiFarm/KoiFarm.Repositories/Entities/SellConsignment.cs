using System;
using System.ComponentModel.DataAnnotations;

namespace KoiFarm.Repositories.Entities
{
    // Models/SellConsignment.cs
    public class SellConsignment
    {
        public int Id { get; set; }

        // Thuộc tính cho Giấy chứng nhận cá
        [Required(ErrorMessage = "Vui lòng chọn giấy chứng nhận")]
        public string Certificate { get; set; }  // Đường dẫn tới tệp đã upload

        // Thuộc tính cho Hình ảnh cá
        [Required(ErrorMessage = "Vui lòng chọn hình ảnh")]
        public string Image { get; set; }  // Đường dẫn tới tệp đã upload

        // Thuộc tính cho Giới tính của cá
        [Required(ErrorMessage = "Vui lòng nhập giới tính")]
        [StringLength(10, ErrorMessage = "Giới tính không hợp lệ")]
        public string Gender { get; set; }

        // Thuộc tính cho Năm sinh
        [Required(ErrorMessage = "Vui lòng nhập năm sinh")]
        [Range(1900, 2100, ErrorMessage = "Năm sinh không hợp lệ")]
        public int BirthYear { get; set; }

        // Thuộc tính cho Kích thước của cá
        [Required(ErrorMessage = "Vui lòng nhập kích thước")]
        [Range(1, 1000, ErrorMessage = "Kích thước không hợp lệ")]
        public decimal Size { get; set; }

        // Thuộc tính cho Giá bán cá
        [Required(ErrorMessage = "Vui lòng nhập giá bán")]
        [Range(1000, 1000000000, ErrorMessage = "Giá bán không hợp lệ")]
        public decimal Price { get; set; }

        // Ngày tạo thông tin ký gửi
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // ID người dùng đã đăng ký ký gửi
        public string UserId { get; set; }
    }
}


