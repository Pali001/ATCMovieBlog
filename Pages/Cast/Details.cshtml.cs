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
    public class DetailsModel : PageModel
    {
        private readonly ATCMovieBlog.Data.ATCMovieBlogContext _context;

        public DetailsModel(ATCMovieBlog.Data.ATCMovieBlogContext context)
        {
            _context = context;
        }

      public Model.Cast Cast { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Cast == null)
            {
                return NotFound();
            }

            var cast = await _context.Cast.FirstOrDefaultAsync(m => m.Id == id);
            if (cast == null)
            {
                return NotFound();
            }
            else 
            {
                Cast = cast;
            }
            return Page();
        }
    }
}
