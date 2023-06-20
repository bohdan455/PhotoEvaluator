using BLL.Services.Interfaces;
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
        private readonly ITelegramUserService _telegramUserService;

        public AddNameStage(ITelegramUserService telegramUserService)
        {
            _telegramUserService = telegramUserService;
        }
        public async Task HandleAsync(ITelegramBotClient botClient, Update update)
        {
            var chatId = update.Message!.Chat.Id;
            var textMessage = update.Message.Text;
            if(textMessage is null)
            {
                await botClient.SendTextMessageAsync(chatId, "Неправильний тип повідомлення");
                return;
            }
            if(textMessage!.Length > 255)
            {
                await botClient.SendTextMessageAsync(chatId, "Задовге ім'я");
                return;
            }
                

            await _telegramUserService.AddNameAsync(chatId, textMessage);
            await botClient.SendTextMessageAsync(chatId, "Введіть ваш вік");
        }
    }
}
