using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6Movies.Models
{
    //Movie response model including data fields from spreadsheet
    public class MovieResponse
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
       
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1888, 2023)]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [StringLength(25)]
        public string Notes { get; set; }

        //fk relationship
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
