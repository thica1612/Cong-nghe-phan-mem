using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<bool> AddFeedback(Feedback feedback);
        Task<List<Feedback>> GetAllFeedbacks();
        Task<List<Feedback>> GetFeedbacksByUser(string customerId);
        Task<bool> FeedbackExists(Feedback feedback);
    }
}
