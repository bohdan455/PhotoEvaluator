namespace BLL.Services.Interfaces
{
    public interface IRatingService
    {
        Task<long?> Rate(long raterId, long userToRate, int value);
    }
}