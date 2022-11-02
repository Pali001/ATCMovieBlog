using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ATCMovieBlog.MovieData;
using ATCMovieBlog.Services;
using static System.Net.WebRequestMethods;
using ATCMovieBlog.Model;
using System.Collections;

namespace ATCMovieBlog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IAPI _api;
        

        //  private readonly IAPI2 _api2;
        private string Base_image_url { get; set; } = "https://image.tmdb.org/t/p/";
        private string Size { get; set; } = "w300/";

        [BindProperty]
        public  Root Data { get; set; }
        [BindProperty]
        public List<Result> AllResults { get; set; }
        //public Root daata { get; set; }


        public IndexModel(ILogger<IndexModel> logger, IAPI api)
        {
            _logger = logger;
            _api = api;
         //   _api2 = API2;
        }

        public  void OnGet()
        {
            Data = _api.MovieAPI().Result;
            AllResults = Data.results.ToList();
            ViewData["poster_path"] = Data.results;
            //    ViewData["title"] = Data.title;

        }
        //public  ActionResult GetImagePath(int id)
        //{
            
         //   return $"{Base_image_url}{Size}{Root.Result}";
       //}
        //public string GetImagePath()
        //{
        //    return $"{Base_image_url}{Size}{Root.poster_path}";
        //}
        //One or more errors occurred. (Unable to cast object of type 'System.Collections.Generic.List`1[ATCMovieBlog.MovieData.Result]' to type 'System.Collections.Generic.IEnumerable`1[ATCMovieBlog.MovieData.Root]'.)'
        //'One or more errors occurred. (Unable to cast object of type 'ATCMovieBlog.MovieData.Root' to type 'System.Collections.Generic.IEnumerable`1[ATCMovieBlog.MovieData.Root]'.)'

    }
}