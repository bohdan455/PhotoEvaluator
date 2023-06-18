namespace BLL.Services.Interfaces
{
    public interface ITelegramUserService
    {
        Task CreateAsync(long chatId);
    }
}