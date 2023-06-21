using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TGBot.Stages.Interfaces;

namespace TGBot.Stages
{
    public class ChatStage : IChatStage
    {
        private IStage _stage;
        public async Task HandleAsync(ITelegramBotClient botClient, Update update)
        {
            if(_stage !=  null) 
                await _stage.HandleAsync(botClient, update);
        }
        public void SetStage(IStage stage)
        {
            _stage = stage;
        }
    }
}
