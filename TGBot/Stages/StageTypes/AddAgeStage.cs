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
    public class AddAgeStage : IStage
    {
        private readonly ITelegramUserService _telegramUserService;

        public AddAgeStage(ITelegramUserService telegramUserService)
        {
            _telegramUserService = telegramUserService;
        }
        public async Task HandleAsync(ITelegramBotClient botClient, Update update)
        {
            var chatId = update.Message!.Chat.Id;
            var textMessage = update.Message.Text;
            int age;
            if (textMessage is null)
            {
                await botClient.SendTextMessageAsync(chatId, "Неправильний тип повідомлення");
                return;
            }
            if(!int.TryParse(textMessage,out age) || !(1 <= age && age <= 140))
            {
                await botClient.SendTextMessageAsync(chatId, "Неправильний формат числа(має бути число в межах (1-140)");
                return;
            }
            await _telegramUserService.AddAgeAsync(chatId, age);
            await botClient.SendTextMessageAsync(chatId, $"Тепер надішліть фотографію на оцінку");
        }
    }
}
