using KoiFarm.Repositories.Entities;
using KoiFarm.Repositories.Interfaces;
using KoiFarm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarm.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _repository;

        public FeedbackService(IFeedbackRepository repository)
        {
            _repository = repository;
        }


        public async Task<bool> AddFeedback(Feedback feedback)
        {
            if (await _repository.FeedbackExists(feedback))
                return false;

            return await _repository.AddFeedback(feedback);
        }


        public Task<List<Feedback>> GetAllFeedbacks()
        {
            return _repository.GetAllFeedback();
        }


        public Task<List<Feedback>> GetFeedbacksByUser(string customerId)
        {
            return _repository.GetFeedbacksByUser(customerId);
        }


        public Task<bool> FeedbackExists(Feedback feedback)
        {
            return _repository.FeedbackExists(feedback);
        }
    }
}
