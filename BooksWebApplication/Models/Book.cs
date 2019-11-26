using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksWebApplication.Models
{
    public class Book
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
    }
}