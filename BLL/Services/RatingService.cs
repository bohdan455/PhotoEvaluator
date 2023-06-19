using BLL.Services.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;

namespace BLL.Services
{
    public class RatingService
    {
        private readonly ITelegramUserRepository _userRepository;
        private readonly ISearchAlghorithmService _searchAlghorithmService;

        public RatingService(ITelegramUserRepository userRepository, ISearchAlghorithmService searchAlghorithmService)
        {
            _userRepository = userRepository;
            _searchAlghorithmService = searchAlghorithmService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="raterId"></param>
        /// <param name="userToRate"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<long?> Rate(long raterId, long userToRate, int value)
        {
            var newRating = new Rating
            {
                RaterId = raterId,
                UserToRateId = userToRate,
                RatingNumber = value
            };

            var RatedUser = _userRepository.GetFirstByExpression(u => u.TelegramId == userToRate);
            RatedUser.Ratings.Add(newRating);
            await _userRepository.SaveAsync();
            var rator = _userRepository.GetFirstByExpression(u => u.TelegramId == raterId);
            var nextUserToRate = _searchAlghorithmService.GetNextUserIdToRate(raterId);
            rator.NextUserToRateId = nextUserToRate ?? 0;
            await _userRepository.SaveAsync();
            return nextUserToRate;
        }
    }
}
