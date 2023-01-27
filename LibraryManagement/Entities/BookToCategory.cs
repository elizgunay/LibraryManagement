using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class BookToCategory
    {
        [Key]
        public int Id { get; set; }

        public int? BookId { get; set; }
        public virtual Book Book { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
