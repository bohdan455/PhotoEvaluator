using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TGBot.Common.Interfaces;

namespace TGBot.Common
{
    public class UserInformation : IUserInformation
    {

        public async Task Send(ITelegramBotClient botClient, TelegramUser? telegramUser, long chatId)
        {
            if (telegramUser == null)
            {
                await botClient.SendTextMessageAsync(chatId, "Такого профілю не існує або ви пролайкали всіх юзерів");
                return;
            }
            decimal rate;
            if (telegramUser.Ratings!.Count == 0)
            {
                rate = 0;
            }
            else
            {
                rate = telegramUser.Ratings!.Sum(r => r.RatingNumber) / (decimal)telegramUser.Ratings.Count;
            }
            var photoDescription = $"Ім'я: {telegramUser.Name} \n Вік: {telegramUser.Age} \n Рейтинг: {rate}";
            await botClient.SendPhotoAsync(chatId: chatId, photo: InputFile.FromFileId(telegramUser.PhotoId), caption: photoDescription);

        }
    }
}
