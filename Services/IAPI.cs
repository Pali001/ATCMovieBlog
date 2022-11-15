using ATCMovieBlog.DTO;
using ATCMovieBlog.MovieData;
using ATCMovieBlog.Model;

namespace ATCMovieBlog.Services
{
    public interface IAPI
    {
        Task<MovieData.Root> MovieAPI();

        Task<DTO.Root> MovieAPI(string movieID);
    }
}