namespace BLL.Services.Interfaces
{
    public interface ITelegramUserService
    {
        Task AddAgeAsync(long chatId, int age);
        Task AddNameAsync(long chatId, string name);
        Task AddPhotoAsync(long chatId, string photoId);
        Task CreateAsync(long chatId);
        Task SetStateAsync(long chatId, int stateId);
    }
}