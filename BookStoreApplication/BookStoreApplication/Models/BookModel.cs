using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 5)]
        [Required(ErrorMessage = "Please provide Book Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please provide Author Name")]
        public string Author { get; set; }

        [StringLength(100, MinimumLength =10, ErrorMessage = "Please provide Description not more than 100 character and not less than 5")]
        public string Description { get; set; }

        public string Category { get; set; }
        
        public int LanguageId { get; set; }
        public string Language { get; set; }

        [Required(ErrorMessage = "Please provide page number")]
        [Display(Name = "Total Number of Pages")]
        public int? Pages { get; set; }
    }
}
