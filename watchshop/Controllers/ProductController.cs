using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BT08.Models;

namespace BT08.Controllers
{
    public class ProductController : Controller
    {
        WatchShopDbContext db = new WatchShopDbContext();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IconCategory(int CateID)
        {
            if (CateID != 0)
            {
                var records = db.Products.Where(pro => pro.CategoryId == CateID);
                return View(records);
            }
            return View();
        }
        public ActionResult Search(String SupplierId = "", int CategoryId = 0, String Keywords = "")
        {
            if (SupplierId != "")
            {
                var model = db.Products
                    .Where(p => p.SupplierId == SupplierId);
                return View(model);
            }
            else if (CategoryId != 0)
            {
                var model = db.Products
                    .Where(p => p.CategoryId == CategoryId);
                return View(model);
            }
            else if (Keywords != "")
            {
                var model = db.Products
                    .Where(p => p.Name.Contains(Keywords));
                return View(model);
            }
            return View(db.Products);
        }
        public ActionResult Detail(int id)
        {
            var records = db.Products.Find(id);
            return View(records);
        }
    }
}