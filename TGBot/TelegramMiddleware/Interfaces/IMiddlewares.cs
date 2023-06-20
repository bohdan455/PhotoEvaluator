namespace TGBot.Middleware.Interfaces
{
    public interface IMiddlewares
    {
        void EvaluateStage(long chatId);
    }
}