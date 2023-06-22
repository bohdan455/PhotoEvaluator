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
    public class ChangePhotoStage : IStage
    {
        private readonly ITelegramValidator _validator;
        private readonly ITelegramUserService _telegramUserService;

        public ChangePhotoStage(ITelegramValidator validator, ITelegramUserService telegramUserService)
        {
            _validator = validator;
            _telegramUserService = telegramUserService;
        }
        public async Task HandleAsync(ITelegramBotClient botClient, Update update)
        {

            var chatId = update.Message!.Chat.Id;
            var textMessage = update.Message.Text;
            if (textMessage == "Вернутись")
            {
                await _telegramUserService.SetStateAsync(chatId, (int)ChatStages.Menu);
                await botClient.SendTextMessageAsync(chatId, "Головне меню", replyMarkup: Keyboards.MainMenu);
                return;
            }
            var photoMessage = update.Message.Photo;
            if (await _validator.ValidateBotMessageTypeAsync(photoMessage, botClient, chatId)) return;
            await _telegramUserService.ChangePhotoAsync(chatId, photoMessage.First().FileId);
            await botClient.SendTextMessageAsync(chatId, "Головне меню", replyMarkup: Keyboards.MainMenu);
        }
    }
}
