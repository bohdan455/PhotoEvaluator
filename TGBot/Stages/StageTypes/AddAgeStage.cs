using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TGBot.Common.Interfaces;
using TGBot.Stages.Interfaces;

namespace TGBot.Stages.StageTypes
{
    public class AddAgeStage : IStage
    {
        private readonly ITelegramUserService _telegramUserService;
        private readonly ITelegramValidator _validator;

        public AddAgeStage(ITelegramUserService telegramUserService,ITelegramValidator validator)
        {
            _telegramUserService = telegramUserService;
            _validator = validator;
        }
        public async Task HandleAsync(ITelegramBotClient botClient, Update update)
        {
            var chatId = update.Message!.Chat.Id;
            var textMessage = update.Message.Text;
            if (await _validator.ValidateBotMessageTypeAsync(textMessage, botClient, chatId)) return;
            int age = await _validator.ValidateAge(textMessage, botClient,chatId);
            if(age == 0) return;

            await _telegramUserService.AddAgeAsync(chatId, age);
            await botClient.SendTextMessageAsync(chatId, $"Тепер надішліть фотографію на оцінку");
        }
    }
}
