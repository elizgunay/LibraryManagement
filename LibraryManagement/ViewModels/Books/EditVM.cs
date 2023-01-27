using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels.Books
{
    public class EditVM
    {
        public int Id { get; set; }

        [DisplayName("Title: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        public string Title { get; set; }

        [DisplayName("Serial Number: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        public string SerialNumber { get; set; }

        [DisplayName("Publisher: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        public string Publisher { get; set; }

        
    }
}
