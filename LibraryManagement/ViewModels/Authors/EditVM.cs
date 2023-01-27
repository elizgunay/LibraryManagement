using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels.Authors
{
    public class EditVM
    {
        public int Id { get; set; }

        [DisplayName("Firstname: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        public string FirstName { get; set; }

        [DisplayName("LastName: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        public string LastName { get; set; }

        // Navigation property
        [Required]
        public int? BookId { get; set; }
        public virtual Book Books { get; set; }// one to many


    }
}
