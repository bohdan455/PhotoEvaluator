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
    public class AddNameStage : IStage
    {
        public async Task HandleAsync(ITelegramBotClient botClient, Update update)
        {
            var chatId = update.Message.Chat.Id;
            await botClient.SendTextMessageAsync(chatId, $"I'm in addName stage with message {update.Message.Text}");
        }
    }
}
