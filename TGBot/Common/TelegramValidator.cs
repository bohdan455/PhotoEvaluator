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
        public async Task<int> ValidateAge(string textMessage, ITelegramBotClient botClient, long chatId)
        {
            int age;
            if (!int.TryParse(textMessage, out age) || !(1 <= age && age <= 140))
            {
                await botClient.SendTextMessageAsync(chatId, "Неправильний формат числа(має бути число в межах (1-140)");
                return 0;
            }
            return age;
        }
    }
}
