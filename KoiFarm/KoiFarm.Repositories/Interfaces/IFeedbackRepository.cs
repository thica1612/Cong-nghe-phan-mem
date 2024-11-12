using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<bool> AddFeedback(Feedback feedback);                 // Thêm phản hồi mới
        Task<List<Feedback>> GetAllFeedback();                     // Lấy tất cả phản hồi
        Task<List<Feedback>> GetFeedbacksByUser(string customerId); // Lấy phản hồi của một người dùng cụ thể
        Task<bool> FeedbackExists(Feedback feedback);              // Kiểm tra phản hồi có tồn tại không
    }
}
