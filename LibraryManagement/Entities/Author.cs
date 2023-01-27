using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigation property
        public int? BookId { get; set; }
        public virtual Book Books { get; set; }// one to many

        public virtual ICollection<AuthorToBook> AuthorToBook { get; set; } //many to many
    }
}
