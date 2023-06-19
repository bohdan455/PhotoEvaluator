namespace TGBot.Middleware.Interfaces
{
    public interface IMiddlewares
    {
        Task EvaluateStage(long chatId);
    }
}