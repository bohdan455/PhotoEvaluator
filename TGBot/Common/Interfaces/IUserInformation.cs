using DataAccess.Entities;
using Telegram.Bot;

namespace TGBot.Common.Interfaces
{
    public interface IUserInformation
    {
        Task Send(ITelegramBotClient botClient, TelegramUser? telegramUser, long chatId);
    }
}