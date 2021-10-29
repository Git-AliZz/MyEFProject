using Microsoft.EntityFrameworkCore;
using MyEFProject_DataAccess.FluentConfig;
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

        public DbSet<Fluent_Book> FluentBooks { get; set; }
        public DbSet<Fluent_BookDetail> FluentBookDetails { get; set; }
        public DbSet<Fluent_Author> FluentAuthors { get; set; }
        public DbSet<Fluent_BookAuthor> FluentBookAuthors { get; set; }
        public DbSet<Fluent_Publisher> FluentPublishers { get; set; }
        public DbSet<Fluent_Category> FluentCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.Author_Id, ba.Book_Id });

            #region FluentAuthor

            modelBuilder.Entity<Fluent_Author>().HasKey(b => b.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(b => b.FirstName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(b => b.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(b => b.FullName);

            #endregion
            #region FluentBookDetail

            modelBuilder.Entity<Fluent_BookDetail>().HasKey(b => b.BookDetail_Id);
            modelBuilder.Entity<Fluent_BookDetail>().Property(b => b.NumberOfChapters).IsRequired();

            #endregion

            modelBuilder.ApplyConfiguration(new FluentBookCfg());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorCfg());
            modelBuilder.ApplyConfiguration(new FluentCategoryCfg());
            modelBuilder.ApplyConfiguration(new FluentPublisherCfg());
        }
    }
}
