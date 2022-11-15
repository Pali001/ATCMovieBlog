using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ATCMovieBlog.Model;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ATCMovieBlog.Services;
using ATCMovieBlog.DTO;

namespace ATCMovieBlog.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly ATCMovieBlog.Data.ATCMovieBlogContext _context;
        private readonly IAPI _api;
        public Root Root;


        public DetailsModel(ATCMovieBlog.Data.ATCMovieBlogContext context, IAPI api)
        {
            _context = context;
            _api = api;
        }

      public Movie Movie { get; set; }

      public IEnumerable<Model.Cast> Cast { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            else 
            {
                Movie = movie;
                Cast = await _context.Cast.Where(c => c.Movieid == movie.Id).ToListAsync();
                // here
                Root = _api.MovieAPI(getMovieID(movie.Title)).Result;
            }
            return Page();
        }

        private string getMovieID(string name)
        {
            switch (name)
            {
                case "Star Trek":
                    return "13475";

                case "Don't look Up":
                    return "646380";
                case "Snowpiercer":
                    return "110415";

                case "Star Trek 2":
                    return "154";
                default:
                    // Fatal Error
                    return "55186";

            }
        }
    }
}
