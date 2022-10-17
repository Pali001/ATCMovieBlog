﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ATCMovieBlog.Data;
using ATCMovieBlog.Model;

namespace ATCMovieBlog.Pages.Cast
{
    public class EditModel : PageModel
    {
        private readonly ATCMovieBlog.Data.ATCMovieBlogContext _context;

        public EditModel(ATCMovieBlog.Data.ATCMovieBlogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.Cast Cast { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Cast == null)
            {
                return NotFound();
            }

            var cast =  await _context.Cast.FirstOrDefaultAsync(m => m.Id == id);
            if (cast == null)
            {
                return NotFound();
            }
            Cast = cast;
           ViewData["Movieid"] = new SelectList(_context.Movie, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CastExists(Cast.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CastExists(Guid? id)
        {
          return _context.Cast.Any(e => e.Id == id);
        }
    }
}
