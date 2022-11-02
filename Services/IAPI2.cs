using ATCMovieBlog.DTO;

namespace ATCMovieBlog.Services
{
    public interface IAPI2
    {
        Task<Root> MovieAPI(string movieId);
    }
}