using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string SerialNumber { get; set; }

        public string Publisher { get; set; }

        // Navigation property

        public virtual ICollection<AuthorToBook> AuthorToBook { get; set; } //many to many

        public virtual ICollection<BookToCategory> BookToCategory { get; set; } //many to many





    }
}
