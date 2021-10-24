using Microsoft.EntityFrameworkCore;
using MyEFProject_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEFProject_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<BookAuthor> BookAuthors{ get; set; }

        public DbSet<Fluent_BookDetail> FluentBookDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(b => new { b.Book_Id, b.Author_Id });

            #region FluentBookDetail

            modelBuilder.Entity<Fluent_BookDetail>().HasKey(b => b.BookDetail_Id);
            modelBuilder.Entity<Fluent_BookDetail>().Property(b => b.NumberOfChapters).IsRequired();

            #endregion
        }
    }
}
