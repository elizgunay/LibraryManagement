using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels.Categories
{
    public class EditVM
    {
        public int Id { get; set; }

        [DisplayName("CategoryName: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        public string CategoryName { get; set; }
    }
}
