using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TGBot.Stages.Interfaces
{
    public interface IStage
    {
        Task HandleAsync(ITelegramBotClient botClient, Update update);
    }
}
