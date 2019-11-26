using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using BooksWebApplication.Models;

namespace BooksWebApplication.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        // тут будем выводить все книги из БД на веб-страницу
        public ActionResult Index() // в view - это Views/Home/index.cshtml. Метод возвращает представление
        {
            DbSet<Models.Book> books = db.Books;        // получаем все книги из бд и передаем в представление
            ViewBag.Books = books;      // в view это будет @ViewBag.Books
            return View();
        }

        // тут можно поставить [HttpGet]
        public ActionResult Buy(int id) // в view - это Views/Home/Buy.cshtml - покупатель переходит на покупка книги
        {
            ViewBag.BookId = id;      // в view это будет @ViewBag.id
            return View();      // представление для метода Buy, для создания - ПКМ по View->Add View 
        }

        [HttpPost]      // данный атрибут указывает, что этот метод будет обрабатывать post-запросы
        public string Buy(Purchase purchase) // после того, как покупатель оформил покупку, метод возвращает string!!!
        {
            purchase.Date = DateTime.Now;
                // добавляем инфу о покупке в базу данных
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Спасибо, " + purchase.Person + ", за покупку!";
        }

        public string Hello() // после того, как покупатель оформил покупку, метод возвращает string!!!
        {
            return "Hello World!";
        }

        /*      это стандартные методы они нам не нужны
                public ActionResult About()
                {
                    ViewBag.Message = "Your application description page.";

                    return View();
                }

                public ActionResult Contact()
                {
                    ViewBag.Message = "Your contact page.";

                    return View();
                }
                */
    }
}