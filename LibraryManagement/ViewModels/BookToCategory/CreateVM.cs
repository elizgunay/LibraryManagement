using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels.BookToCategory
{
    public class CreateVM
    {
        public int Id { get; set; }

        [Required]
        public int? BookId { get; set; }
        public virtual Book Book { get; set; }

        [Display]
        [Range(typeof(bool), "true", "true")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
