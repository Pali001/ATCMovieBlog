using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ATCMovieBlog.Data;
using ATCMovieBlog.Model;

namespace ATCMovieBlog.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly ATCMovieBlog.Data.ATCMovieBlogContext _context;

        public IndexModel(ATCMovieBlog.Data.ATCMovieBlogContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync();
            }
        }
    }
}
