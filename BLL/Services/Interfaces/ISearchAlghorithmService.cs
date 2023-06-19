namespace BLL.Services.Interfaces
{
    public interface ISearchAlghorithmService
    {
        long? GetNextUserIdToRate(long raterId);
    }
}