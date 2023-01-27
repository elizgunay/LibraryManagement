using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class AuthorToBook
    {
        [Key]
        public int Id { get; set; }

        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public int? BookId { get; set; }

        public virtual Book Book { get; set; }

    }
}
