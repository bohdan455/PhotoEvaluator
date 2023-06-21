using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TGBot.Buttons;
using TGBot.Stages.Interfaces;

namespace TGBot.Stages.StageTypes
{
    public class AddPhotoStage : IStage
    {
        private readonly ITelegramUserService _telegramUserService;

        public AddPhotoStage(ITelegramUserService telegramUserService)
        {
            _telegramUserService = telegramUserService;
        }
        public async Task HandleAsync(ITelegramBotClient botClient, Update update)
        {
            var chatId = update.Message!.Chat.Id;
            var photoMessage = update.Message!.Photo;
            if (photoMessage is null)
            {
                await botClient.SendTextMessageAsync(chatId, "Неправильний тип повідомлення");
                return;
            }
            var url = photoMessage.First().FileId;
            await _telegramUserService.AddPhotoAsync(chatId, url);
            await botClient.SendTextMessageAsync(chatId, "Головне меню",replyMarkup:Keyboards.MainMenu);
        }
    }
}
