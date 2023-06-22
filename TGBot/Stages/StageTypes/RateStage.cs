using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TGBot.Stages.Interfaces;
using BLL.Enums;
using TGBot.Common.Interfaces;
using TGBot.Buttons;

namespace TGBot.Stages.StageTypes
{
    public class RateStage : IStage
    {
        private readonly ITelegramUserService _telegramUserService;
        private readonly ITelegramValidator _validator;
        private readonly IUserInformation _userInformation;
        private readonly IRatingService _ratingService;

        public RateStage(ITelegramUserService telegramUserService,
            ITelegramValidator validator,
            IUserInformation userInformation,
            IRatingService ratingService)
        {
            _telegramUserService = telegramUserService;
            _validator = validator;
            _userInformation = userInformation;
            _ratingService = ratingService;
        }
        public async Task HandleAsync(ITelegramBotClient botClient, Update update)
        {
            var chatId = update.Message!.Chat.Id;
            var textMessage = update.Message!.Text;
            if (await _validator.ValidateBotMessageTypeAsync(textMessage, botClient, chatId)) return;

            if(textMessage == "Вернутись")
            {
                await _telegramUserService.SetStateAsync(chatId, (int)ChatStages.Menu);
                await botClient.SendTextMessageAsync(chatId, "Головне меню", replyMarkup: Keyboards.MainMenu);
                return;
            }
            if (textMessage != "Оцінювати")
            {
                int rating;
                if(int.TryParse(textMessage,out rating) && !(1<= rating && rating <= 10))
                {
                    await botClient.SendTextMessageAsync(chatId, "Для голосування використовуйте кнопки або цифри 1-10");
                    return;
                }
                var userToRateId = (await _telegramUserService.GetNextUserToVoteByIdAsync(chatId))?.TelegramId;
                if (userToRateId == null)
                {
                    await botClient.SendTextMessageAsync(chatId, "Це на даний момент все, попробуйте пізніше");
                    return;
                }
                await _ratingService.RateAsync(chatId, (long)userToRateId,rating);

            } 

            var userToRate = await _telegramUserService.GetNextUserToVoteByIdAsync(chatId);
            if (userToRate == null)
            {
                await botClient.SendTextMessageAsync(chatId, "Це на даний момент все, попробуйте пізніше");
                return;
            }
            await _userInformation.SendAsync(botClient,userToRate, chatId);


                
        }
    }
}
