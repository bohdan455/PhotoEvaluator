using DataAccess.Entities;

namespace BLL.Services.Interfaces
{
    public interface ITelegramUserService
    {
        Task AddAgeAsync(long chatId, int age);
        Task AddNameAsync(long chatId, string name);
        Task AddPhotoAsync(long chatId, string photoId);
        Task CreateAsync(long chatId);
        TelegramUser? GetById(long chatId);
        TelegramUser? GetNextUserToVoteById(long chatId);
        int GetStage(long chatId);
        Task SetStateAsync(long chatId, int stateId);
    }
}