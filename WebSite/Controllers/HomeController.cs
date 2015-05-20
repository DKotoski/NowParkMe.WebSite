using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {

        private SubscribersContext db = new SubscribersContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Subscribe(string email)
        {
            if (db.Subscribers.SingleOrDefault(x=>x.Email==email)!=null)
            {
                return Json("False", JsonRequestBehavior.AllowGet); ;
            }
            db.Subscribers.Add(new Subscriber() { Email = email });
            try
            {
                db.SaveChanges();
                return Json("True",JsonRequestBehavior.AllowGet);
            }catch
            {
                return Json("False",JsonRequestBehavior.AllowGet);
            }            
        }        
    }
}