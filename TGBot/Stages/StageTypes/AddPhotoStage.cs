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
    public class AddPhotoStage : IStage
    {
        private readonly ITelegramUserService _telegramUserService;
        private readonly ITelegramValidator _validator;

        public AddPhotoStage(ITelegramUserService telegramUserService,ITelegramValidator validator)
        {
            _telegramUserService = telegramUserService;
            _validator = validator;
        }
        public async Task HandleAsync(ITelegramBotClient botClient, Update update)
        {
            var chatId = update.Message!.Chat.Id;
            var photoMessage = update.Message!.Photo;
            if (await _validator.ValidateBotMessageTypeAsync(photoMessage, botClient, chatId)) return;
            var url = photoMessage.First().FileId;
            await _telegramUserService.AddPhotoAsync(chatId, url);
            await botClient.SendTextMessageAsync(chatId, "Головне меню",replyMarkup:Keyboards.MainMenu);
        }
    }
}
