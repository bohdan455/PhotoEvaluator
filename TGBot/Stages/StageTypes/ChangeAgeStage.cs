using BLL.Enums;
using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TGBot.Buttons;
using TGBot.Common.Interfaces;
using TGBot.Stages.Interfaces;

namespace TGBot.Stages.StageTypes
{
    public class ChangeAgeStage : IStage
    {
        private readonly ITelegramUserService _telegramUserService;
        private readonly ITelegramValidator _validator;

        public ChangeAgeStage(ITelegramUserService telegramUserService,ITelegramValidator validator)
        {
            _telegramUserService = telegramUserService;
            _validator = validator;
        }
        public async Task HandleAsync(ITelegramBotClient botClient, Update update)
        {
            var chatId = update.Message!.Chat.Id;
            var textMessage = update.Message!.Text;
            if (await _validator.ValidateBotMessageTypeAsync(textMessage, botClient, chatId)) return;

            if (textMessage == "Вернутись")
            {
                await _telegramUserService.SetStateAsync(chatId, (int)ChatStages.Menu);
                await botClient.SendTextMessageAsync(chatId, "Головне меню", replyMarkup: Keyboards.MainMenu);
                return;
            }
            int age = await _validator.ValidateAge(textMessage, botClient, chatId);
            if (age == 0) return;
            await _telegramUserService.ChangeAgeAsync(chatId, age);
            await botClient.SendTextMessageAsync(chatId, "Головне меню", replyMarkup: Keyboards.MainMenu);
        }
    }
}
