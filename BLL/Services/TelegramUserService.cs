using BLL.Enums;
using BLL.Services.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class TelegramUserService : ITelegramUserService
    {
        private readonly ITelegramUserRepository _userRepository;

        private async Task setNameAsync(long chatId, string name, int? stateId = null)
        {
            var user = _userRepository.GetFirstByExpression(u => u.TelegramId == chatId);
            user.Name = name;
            if (stateId is not null)
                user.StateId = (int)stateId;
            _userRepository.Update(user);
            await _userRepository.SaveAsync();
        }
        private async Task setAgeAsync(long chatId, int age, int? stateId = null)
        {
            var user = _userRepository.GetFirstByExpression(u => u.TelegramId == chatId);
            user.Age = age;
            if (stateId is not null)
                user.StateId = (int)stateId;
            _userRepository.Update(user);
            await _userRepository.SaveAsync();
        }
        private async Task setPhotoAsync(long chatId, string photoId, int? stateId = null)
        {
            var user = _userRepository.GetFirstByExpression(u => u.TelegramId == chatId);
            user.PhotoId = photoId;
            if (stateId is not null)
                user.StateId = (int)stateId;
            _userRepository.Update(user);
            await _userRepository.SaveAsync();
        }
        public TelegramUserService(ITelegramUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task CreateAsync(long chatId)
        {
            if (_userRepository.GetFirstByExpression(u => u.TelegramId == chatId) is null)
            {
                _userRepository.Add(new TelegramUser
                {
                    TelegramId = chatId,
                    StateId = (int)States.SetName
                });
                await _userRepository.SaveAsync();
            }
        }
        public async Task AddNameAsync(long chatId, string name)
        {
            await setNameAsync(chatId, name, (int)States.SetAge);
        }
        public async Task AddAgeAsync(long chatId, int age)
        {
            await setAgeAsync(chatId, age, (int)States.SetPhoto);
        }
        public async Task AddPhotoAsync(long chatId, string photoId)
        {
            await setPhotoAsync(chatId, photoId, (int)States.Menu);
        }
        public async Task SetStateAsync(long chatId, int stateId)
        {
            var user = _userRepository.GetFirstByExpression(u => u.TelegramId == chatId);
            user.StateId = stateId;
            _userRepository.Update(user);
            await _userRepository.SaveAsync();
        }
        public int? GetStage(long chatId)
        {
            var user = _userRepository.GetFirstByExpression(u => u.TelegramId == chatId);
            return user?.StateId;
        }
        public TelegramUser? GetById(long chatId)
        {
            var user = _userRepository.GetFirstByExpression(u => u.TelegramId == chatId,includes: ur => ur.Include(u => u.Ratings));
            return user;
        }
        public TelegramUser? GetNextUserToVoteById(long chatId)
        {
            var user = _userRepository.
                GetFirstByExpression(u => u.TelegramId == chatId, 
                includes: ur => ur.Include(u => u.NextUserToRate).ThenInclude(u => u.Ratings))
                ?.NextUserToRate;
            return user;
        }
    }
}
