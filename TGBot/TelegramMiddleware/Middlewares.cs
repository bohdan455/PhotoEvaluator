
using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TGBot.Stages.Interfaces;
using TGBot.Stages.StageTypes;
using TGBot.TelegramMiddleware.Interfaces;

namespace TGBot.TelegramMiddleware
{
    public class Middlewares : IMiddlewares
    {
        private readonly IChatStage _chatStage;
        private readonly ITelegramUserService _telegramUserService;
        private readonly IStageManager _stageManager;

        public Middlewares(IChatStage chatStage, ITelegramUserService telegramUserService, IStageManager stageManager)
        {
            _chatStage = chatStage;
            _telegramUserService = telegramUserService;
            _stageManager = stageManager;
        }
        public void EvaluateStage(long chatId)
        {
            var stageId = _telegramUserService.GetStage(chatId);
            if (stageId != null)
                _chatStage.SetStage(_stageManager.GetStageInstance((int)stageId));
        }
    }
}
