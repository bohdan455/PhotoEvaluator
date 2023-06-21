using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TGBot.Common.Interfaces;

namespace TGBot.Common
{
    public class TelegramValidator : ITelegramValidator
    {
        public async Task<bool> ValidateBotMessageTypeAsync(object? message, ITelegramBotClient botClient, long chatId)
        {
            if (message == null)
                await botClient!.SendTextMessageAsync(chatId, "Неправильний тип повідомлення");

            return message == null;

        }
    }
}
