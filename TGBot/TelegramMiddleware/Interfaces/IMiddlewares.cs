namespace TGBot.TelegramMiddleware.Interfaces
{
    public interface IMiddlewares
    {
        void EvaluateStage(long chatId);
    }
}