using Telegram.Bot;

namespace TGBot.Common.Interfaces
{
    public interface ITelegramValidator
    {
        Task<int> ValidateAge(string textMessage, ITelegramBotClient botClient, long chatId);
        Task<bool> ValidateBotMessageTypeAsync(object? message, ITelegramBotClient botClient, long chatId);
    }
}