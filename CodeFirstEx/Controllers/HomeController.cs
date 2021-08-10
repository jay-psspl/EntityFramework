using CodeFirstEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstEx.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        DataContext db = new DataContext();
        public ActionResult Index()
        {
            var data = db.Products.SqlQuery("select *from products").ToList();

            return View(data);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {

            var data = db.Products.SqlQuery("select *from products where productid=@p0", id).SingleOrDefault();

            return View(data);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Product collection)
        {
            try
            {
                // TODO: Add insert logic here
                List<object> lst = new List<object>();

                lst.Add(collection.ProductName);
                lst.Add(collection.SerialNumber);
                lst.Add(collection.Company);

                object[] allitems = lst.ToArray();

                int output = db.Database.ExecuteSqlCommand("insert into products(productname, serialnumber, company) values(@p0,@p1,@p2)", allitems);

                if (output > 0)
                {
                    ViewBag.msg = "Product is added";
                }

                return View();


                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {

            var data = db.Products.SqlQuery("select *from products where productid=@p0", id).SingleOrDefault();

            return View(data);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product obj)
        {
            try
            {
                // TODO: Add update logic here

                List<object> parameters = new List<object>();
                parameters.Add(obj.ProductName);
                parameters.Add(obj.SerialNumber);
                parameters.Add(obj.Company);
                parameters.Add(obj.ProductId);

                object[] objectarray = parameters.ToArray();

                int output = db.Database.ExecuteSqlCommand("update Products set ProductName=@p0,SerialNumber=@p1,Company=@p2 where ProductId=@p3", objectarray);

                if (output > 0)
                {
                    ViewBag.Itemmsg = "Your Product id " + obj.ProductId + " is updated succussfully";

                }
                return View();


               // return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.Products.SqlQuery("select * from products where productid=@p0", id).SingleOrDefault();

            return View(data);

        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product collection)
        {
            try
            {
                // TODO: Add delete logic here

                var productlist = db.Database.ExecuteSqlCommand("delete from Products where ProductId=@p0", id);

                if (productlist != 0)
                { 
                return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
