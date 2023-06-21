using Telegram.Bot;

namespace TGBot.Common.Interfaces
{
    public interface ITelegramValidator
    {
        Task<bool> ValidateBotMessageTypeAsync(object? message, ITelegramBotClient botClient, long chatId);
    }
}