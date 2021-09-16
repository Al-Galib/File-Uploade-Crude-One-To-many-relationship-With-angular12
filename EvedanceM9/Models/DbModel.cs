using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EvedanceM9.Models
{
    public class Publisher
    {
        public Publisher()
        {
            this.Book = new HashSet<Book>();
        }

        public int PublisherId { get; set; }
        [Required, StringLength(60), Display(Name = "Publisher Name")]
        public string PublisherName { get; set; }
        [Required, StringLength(20)]
        public string Phone { get; set; }


        public virtual ICollection<Book> Book { get; set; }
    }
    public enum CurentLevel { Master,Star,Pro,Medicore}
   
    public class Book
    {

        public int BookId { get; set; }
        [Required, StringLength(60), Display(Name = "Book Name")]
        public string BookName { get; set; }
        [Required, Column(TypeName = "date"), Display(Name = "Release Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PublishDate { get; set; }
        [Required, StringLength(200)]
        public string Picture { get; set; }
        [Required, ForeignKey("Publishers")]
        public int PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }
    }
    public class PublisherDbContext : DbContext
    {
        public PublisherDbContext(DbContextOptions<PublisherDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

    }
}
