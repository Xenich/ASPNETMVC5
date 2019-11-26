using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BooksWebApplication.Models
{
    public class BookContext : DbContext
    {
        public BookContext() : base("BookContext")
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }

        // инициализация базы данных - пересоздаём бд при каждом запуске
    public class BookDBInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "Война и мир", Author = "Толстой", Price = 220 });
            db.Books.Add(new Book { Name = "Отцы и дети", Author = "Тургенев", Price = 180 });
            db.Books.Add(new Book { Name = "Чайка", Author = "Чехов", Price =150});
            base.Seed(db);
        }
    }
}