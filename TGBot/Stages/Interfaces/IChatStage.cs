using Telegram.Bot;
using Telegram.Bot.Types;

namespace TGBot.Stages.Interfaces
{
    public interface IChatStage
    {
        Task HandleAsync(ITelegramBotClient botClient, Update update);
        void SetStage(IStage stage);
    }
}