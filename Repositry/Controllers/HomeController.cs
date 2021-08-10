using Repositry.Models;
using Repositry.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repositry.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository interfaceobj;

        public HomeController()
        {
            this.interfaceobj = new BookRepository(new DataContext());
        }
        // GET: Home
        public ActionResult Index()
        {
            var data = from m in interfaceobj.GetBooks() select m;
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            interfaceobj.InsertBook(book);
            interfaceobj.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Book b = interfaceobj.GetBookByID(id);
            return View(b);
        }

        public ActionResult Delete(int id)
        {
            Book b = interfaceobj.GetBookByID(id);
            return View(b);
        }

        [HttpPost]
        public ActionResult Delete(int id, Book b)
        {
            interfaceobj.DeleteBook(id);
            interfaceobj.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Book b = interfaceobj.GetBookByID(id);
            return View(b);
        }

        [HttpPost]

        public ActionResult Edit(int id, Book book)
        {
            interfaceobj.UpdateBook(book);
            interfaceobj.Save();
            return RedirectToAction("Index");
        }
    }
}