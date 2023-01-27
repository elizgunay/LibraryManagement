using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public virtual ICollection<BookToCategory> BookToCategory { get; set; } //many to many

    }
}
