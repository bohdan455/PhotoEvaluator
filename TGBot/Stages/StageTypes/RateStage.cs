using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TGBot.Stages.Interfaces;

namespace TGBot.Stages.StageTypes
{
    public class RateStage : IStage
    {
        public Task HandleAsync(ITelegramBotClient botClient, Update update)
        {
            throw new NotImplementedException();
        }
    }
}
