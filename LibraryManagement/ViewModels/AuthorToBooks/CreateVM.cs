﻿using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels.AuthorToBooks
{
    public class CreateVM
    {
      
        public int Id { get; set; }

        [Required]
        public int? BookId { get; set; }
        public virtual Book Book { get; set; }

        [Required]
        public int? AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
