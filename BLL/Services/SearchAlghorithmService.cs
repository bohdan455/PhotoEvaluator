using BLL.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class SearchAlghorithmService : ISearchAlghorithmService
    {
        private readonly ITelegramUserRepository _userRepository;

        public SearchAlghorithmService(ITelegramUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public long? GetNextUserIdToRate(long raterId)
        {
            var id = _userRepository
                .GetRandomElement(
                    filter: user => !user.Ratings.Any(r => r.RaterId == raterId),
                    includes: ur => ur.Include(u => u.Ratings))
                ?.TelegramId;
            return id;
        }
    }
}
