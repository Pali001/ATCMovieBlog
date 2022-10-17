using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ATCMovieBlog.Data;
using ATCMovieBlog.Model;

namespace ATCMovieBlog.Pages.Cast
{
    public class IndexModel : PageModel
    {
        private readonly ATCMovieBlog.Data.ATCMovieBlogContext _context;

        public IndexModel(ATCMovieBlog.Data.ATCMovieBlogContext context)
        {
            _context = context;
        }

        public IList<Model.Cast> Cast { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cast != null)
            {
                Cast = await _context.Cast
                .Include(c => c.Movie).ToListAsync();
            }
        }
    }
}
