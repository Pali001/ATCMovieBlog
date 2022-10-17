using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ATCMovieBlog.Model;

namespace ATCMovieBlog.Data
{
    public class ATCMovieBlogContext : DbContext
    {
        public ATCMovieBlogContext (DbContextOptions<ATCMovieBlogContext> options)
            : base(options)
        {
        }

        public DbSet<ATCMovieBlog.Model.Movie> Movie { get; set; } = default!;

        public DbSet<ATCMovieBlog.Model.Cast> Cast { get; set; }
    }
}
