using ATCMovieBlog.DTO;
using Newtonsoft.Json;

namespace ATCMovieBlog.Services
{
    public class API2 : IAPI2
    {

        public async Task<Root> MovieAPI(string movieId)

        {

            HttpClient client = new HttpClient();

            string responseBody = null;

            string apiKey = "d817fd94e001c3b41fa48d7b2d4be5e7";

            string URL = "https://api.themoviedb.org/3/trending/movie/week?api_key=d817fd94e001c3b41fa48d7b2d4be5e7" + movieId + "?api_key=" + apiKey;

            responseBody = await client.GetStringAsync(URL);

            Root root = JsonConvert.DeserializeObject<Root>(responseBody);



            return root;
        }

    }
}
