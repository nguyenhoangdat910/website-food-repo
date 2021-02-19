using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BT08.Models;


namespace BT08.Controllers
{
    public class HomeController : Controller

        
    {
        WatchShopDbContext db = new WatchShopDbContext();
        public ActionResult Index()
        {
            var model = db.Categories
                 .Where(c => c.Products.Count >= 4)
                 .OrderBy(c => Guid.NewGuid()).ToList();


            return View(model);
        }


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
        public ActionResult Search()
        {
            var name = Request["term"];// phần nhập kí tự tìm kiếm

            var data = db.Products
                .Where(p => p.Name.Contains(name)) // tìm tên tìm kiếm và chọn
                .Select(p => p.Name).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Category()
        {
            var model = db.Categories;
            return PartialView("_Categories", model);
        }
        public ActionResult Saleoff()
        {
            var model = db.Products.Where(p => p.Discount > 0).OrderBy(pro => Guid.NewGuid()).Take(2);
            return PartialView("_Saleoff", model);
        }
        public ActionResult Special()
        {
            var model = db.Products.Where(p => p.Special == true).Take(3);
            return PartialView("_BestSeller", model);
        }
    }
}