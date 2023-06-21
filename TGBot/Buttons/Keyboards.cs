using Telegram.Bot.Types.ReplyMarkups;

namespace TGBot.Buttons
{
    public static class Keyboards
    {
        public static ReplyKeyboardMarkup MainMenu { get; set; } = new(new[]
        {
            new KeyboardButton[]{ "Мій профіль","Оцінювати" },
            new KeyboardButton[]{ "Налаштування"}
        })
        {
            ResizeKeyboard = true
        };
        public static ReplyKeyboardMarkup Back { get; set; } = new(new[]
{
            new KeyboardButton[]{ "Назад"}
        })
        {
            ResizeKeyboard = true
        };
    }
}
