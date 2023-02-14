using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6Movies.Models
{
    public class MovieRecordContext : DbContext
    {
        public MovieRecordContext (DbContextOptions<MovieRecordContext> options): base(options)
        {

        }

        public DbSet<MovieResponse> responses { get; set; }

        protected  override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieResponse>().HasData
                (
                    //database seeded with 3 movies
                    new MovieResponse
                    {
                        MovieID = 1,
                        Category = "Drama",
                        Title = "Hacksaw Ridge",
                        Year = 2016,
                        Director = "Mel Gibson",
                        Rating = "R",
                        Edited = false,
                        LentTo = "",
                        Notes = ""                   
                    },
                    new MovieResponse
                    {
                        MovieID = 2,
                        Category = "Horror/Suspense",
                        Title = "A Quite Place",
                        Year = 2018,
                        Director = "John Krasinski",
                        Rating = "PG-13",
                        Edited = false,
                        LentTo = "",
                        Notes = ""
                    },
                    new MovieResponse
                    {
                        MovieID = 3,
                        Category = "Comedy",
                        Title = "Hot Rod",
                        Year = 2007,
                        Director = "Akiva Schaffer",
                        Rating = "PG-13",
                        Edited = false,
                        LentTo = "",
                        Notes = ""
                    }
                );
        }
    }
}
