using BLL.Enums;
using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TGBot.Buttons;
using TGBot.Common;
using TGBot.Common.Interfaces;
using TGBot.Stages.Interfaces;

namespace TGBot.Stages.StageTypes
{
    public class SettingsStage : IStage
    {
        private readonly ITelegramUserService _telegramUserService;
        private readonly ITelegramValidator _validator;

        public SettingsStage(ITelegramUserService telegramUserService,ITelegramValidator validator)
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
            switch (textMessage)
            {
                case "Поміняти вік":
                    await _telegramUserService.SetStateAsync(chatId,(int)ChatStages.ChangeAge);
                    await botClient.SendTextMessageAsync(chatId, "Вкажіть новий вік",replyMarkup:Keyboards.Back);
                    break;
                case "Поміняти ім'я":
                    await _telegramUserService.SetStateAsync(chatId, (int)ChatStages.ChangeName);
                    await botClient.SendTextMessageAsync(chatId, "Вкажіть нове ім'я", replyMarkup: Keyboards.Back);
                    break;
                case "Поміняти фотографію":
                    await _telegramUserService.SetStateAsync(chatId, (int)ChatStages.ChangePhoto);
                    await botClient.SendTextMessageAsync(chatId, "Надішліть нову фотографію", replyMarkup: Keyboards.Back);
                    break;
                default:
                    await botClient.SendTextMessageAsync(chatId, "Невідома команда");
                    break;
            }
        }
    }
}
