using BLL.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TGBot.Middleware.Interfaces;
using TGBot.Stages;
using TGBot.Stages.Interfaces;
using TGBot.Stages.StageTypes;

namespace TGBot.Telegram
{
    public class Bot
    {
        private readonly IMiddlewares _middleware;
        private readonly IChatStage _chatStage;
        private readonly ITelegramUserService _telegramUserService;

        public Bot(IMiddlewares middleware,IChatStage chatStage,ITelegramUserService telegramUserService)
        {;
            _middleware = middleware;
            _chatStage = chatStage;
            _telegramUserService = telegramUserService;
        }
        public void StartReceivingUpdates()
        {
            var botClient = new TelegramBotClient(TelegramSettings.Token);

            using CancellationTokenSource cts = new();

            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = new UpdateType[] 
                {
                    UpdateType.Message
                } 
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );
            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                //TODO Delete it
                var chatId = update.Message.Chat.Id;
                await _telegramUserService.CreateAsync(chatId);
                _middleware.EvaluateStage(chatId);
                await _chatStage.HandleAsync(botClient,update);
            }

            Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
            {
                var ErrorMessage = exception switch
                {
                    ApiRequestException apiRequestException
                        => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                    _ => exception.ToString()
                };

                Console.WriteLine(ErrorMessage);
                return Task.CompletedTask;
            }

        }
    }
}
