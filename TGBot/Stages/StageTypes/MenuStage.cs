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

namespace TGBot.Stages.StageTypes
{
    public class MenuStage : IStage
    {
        private readonly ITelegramUserService _telegramUserService;
        private readonly ITelegramValidator _validator;
        private readonly IUserInformation _userInformation;

        public MenuStage(ITelegramUserService telegramUserService,ITelegramValidator validator, IUserInformation userInformation)
        {
            _telegramUserService = telegramUserService;
            _validator = validator;
            _userInformation = userInformation;
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
                    await _userInformation.Send(botClient, user,chatId);
                    break;
                case "Оцінювати":
                    break;
                case "Налаштування":
                    break;
                default:
                    await botClient.SendTextMessageAsync(chatId, "Невідома команда");
                    break;
            }
        }
    }
}
