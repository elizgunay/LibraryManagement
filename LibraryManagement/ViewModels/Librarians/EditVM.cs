﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels.Librarians
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

        [DisplayName("Username: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
