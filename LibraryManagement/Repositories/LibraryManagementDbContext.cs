using LibraryManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Repositories
{
    public class LibraryManagementDbContext:DbContext
    {
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorToBook> AuthorToBooks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookToCategory> BookToCategories { get; set; }

        public LibraryManagementDbContext()
        {
            this.Librarians = this.Set<Librarian>();
            this.Authors = this.Set<Author>();
            this.Books = this.Set<Book>();
            this.AuthorToBooks = this.Set<AuthorToBook>();
            this.Categories = this.Set<Category>();
            this.BookToCategories = this.Set<BookToCategory>();


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=localhost;Database=LibraryManagementtDb;Trusted_Connection=True;")
                .UseLazyLoadingProxies();
              
  
        }
      
        
    }
}
