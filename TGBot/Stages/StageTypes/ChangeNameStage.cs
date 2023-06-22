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
    public class ChangeNameStage : IStage
    {
        private readonly ITelegramValidator _validator;
        private readonly ITelegramUserService _telegramUserService;

        public ChangeNameStage(ITelegramValidator validator,ITelegramUserService telegramUserService)
        {
            _validator = validator;
            _telegramUserService = telegramUserService;
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
            await _telegramUserService.ChangeNameAsync(chatId, textMessage);
            await botClient.SendTextMessageAsync(chatId, "Головне меню", replyMarkup: Keyboards.MainMenu);
        }
    }
}
