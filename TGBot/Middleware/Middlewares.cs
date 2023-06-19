
using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TGBot.Middleware.Interfaces;
using TGBot.Stages.Interfaces;
using TGBot.Stages.StageTypes;

namespace TGBot.Middleware
{
    public class Middlewares : IMiddlewares
    {
        private readonly IChatStage _chatStage;
        private readonly ITelegramUserService _telegramUserService;

        public Middlewares(IChatStage chatStage,ITelegramUserService telegramUserService)
        {
            _chatStage = chatStage;
            _telegramUserService = telegramUserService;
        }
        public async Task EvaluateStage(long chatId)
        {
            var stageId = _telegramUserService.GetById(chatId)!.StateId;
            _chatStage.SetStage(stageId switch
            {
                1 => new AddNameStage(),
                2 => new AddAgeStage(),
                3 => new AddPhotoStage(),
                4 => new MenuStage(),
                5 => new RateStage(),
                6 => new SettingsStage(),
                7 => new ChangeNameStage(),
                8 => new ChangePhotoStage(),
                _ => throw new InvalidDataException($"Could not find {stageId}"),
            });
        }
    }
}
