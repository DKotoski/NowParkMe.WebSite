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

        public JsonResult Subscribe(string email)
        {
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

        public JsonResult SendEmailTo(string email)
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("contact@nowpark.me", "ninja");
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("contact@nowpark.me");
            mailMessage.Subject = "test";
            mailMessage.Body = "test";

                mailMessage.To.Add(email);

            client.Send(mailMessage);
            return Json("True",JsonRequestBehavior.AllowGet);
        }
    }
}