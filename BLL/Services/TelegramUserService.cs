using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using BLL.Services.Interfaces;
using System.Xml.Linq;

namespace BLL.Services
{
enum States
    {
        SetName = 1,
        SetAge = 2,
        SetPhoto = 3,
        Menu = 4,
        Rate = 5,
        Settings = 6,
        ChangeName = 7,
        ChangePhoto = 8 
        
    }
    public class TelegramUserService : ITelegramUserService
    {
        private readonly ITelegramUserRepository _userRepository;

        private async Task setNameAsync(long chatId,string name,int? stateId = null)
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
        private async Task setPhotoAsync(long chatId,string photoId, int? stateId = null)
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
    }
}
