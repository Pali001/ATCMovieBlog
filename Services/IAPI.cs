using ATCMovieBlog.MovieData;
using ATCMovieBlog.Model;

namespace ATCMovieBlog.Services
{
    public interface IAPI
    {
        Task<Root> MovieAPI();
    }
}