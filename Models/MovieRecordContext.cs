using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6Movies.Models
{
    public class MovieRecordContext : DbContext
    {
        //constructor
        public MovieRecordContext (DbContextOptions<MovieRecordContext> options): base(options)
        {

        }

        public DbSet<MovieResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected  override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category {CategoryId = 1, CategoryName = "Action/Adventure"},
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
                );

            mb.Entity<MovieResponse>().HasData
                (
                    //database seeded with 3 movies
                    new MovieResponse
                    {
                        MovieID = 1,
                        CategoryId = 3,
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
                        CategoryId = 5,
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
                        CategoryId = 2,
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
