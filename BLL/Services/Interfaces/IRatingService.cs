namespace BLL.Services.Interfaces
{
    public interface IRatingService
    {
        Task<long?> RateAsync(long raterId, long userToRate, int value);
    }
}