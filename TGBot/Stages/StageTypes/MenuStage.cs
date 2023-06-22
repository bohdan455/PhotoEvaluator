using BLL.Services;
using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TGBot.Common.Interfaces;
using TGBot.Stages.Interfaces;
using BLL.Enums;
using DataAccess.Entities;
using TGBot.Buttons;

namespace TGBot.Stages.StageTypes
{
    public class MenuStage : IStage
    {
        private readonly ITelegramUserService _telegramUserService;
        private readonly ITelegramValidator _validator;
        private readonly IUserInformation _userInformation;
        private readonly RateStage _rateStage;

        public MenuStage(ITelegramUserService telegramUserService,
            ITelegramValidator validator,
            IUserInformation userInformation,
            RateStage rateStage)
        {
            _telegramUserService = telegramUserService;
            _validator = validator;
            _userInformation = userInformation;
            _rateStage = rateStage;
        }
        public async Task HandleAsync(ITelegramBotClient botClient, Update update)
        {
            var chatId = update.Message.Chat.Id;
            var textMessage = update.Message.Text;
            if (await _validator.ValidateBotMessageTypeAsync(textMessage, botClient, chatId)) return;
            switch (textMessage)
            {
                case "Мій профіль":
                    var user = _telegramUserService.GetById(chatId);
                    await _userInformation.SendAsync(botClient, user,chatId);
                    break;
                case "Оцінювати":
                    await _telegramUserService.SetStateAsync(chatId,(int)ChatStages.Rate);
                    await botClient.SendTextMessageAsync(chatId, "Пошук", replyMarkup: Keyboards.RateButtons);
                    await _rateStage.HandleAsync(botClient, update);
                    break;
                case "Налаштування":
                    await _telegramUserService.SetStateAsync(chatId, (int)ChatStages.Settings);
                    await botClient.SendTextMessageAsync(chatId, "Налаштування", replyMarkup: Keyboards.SettingButtons);
                    break;
                default:
                    await botClient.SendTextMessageAsync(chatId, "Невідома команда");
                    break;
            }
        }
    }
}
