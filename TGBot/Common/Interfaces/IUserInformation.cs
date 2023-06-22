using DataAccess.Entities;
using Telegram.Bot;

namespace TGBot.Common.Interfaces
{
    public interface IUserInformation
    {
        Task SendAsync(ITelegramBotClient botClient, TelegramUser? telegramUser, long chatId);
    }
}