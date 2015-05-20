using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class AdminController : Controller
    {
        SubscribersContext db = new SubscribersContext();
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [ValidateInput(false)] 
        public JsonResult SendEmails(string title, string content)
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("contact@nowpark.me", "ninja");
            MailMessage mailMessage;

            //foreach (var subscriber in db.Subscribers.ToList())
            //{
            //    mailMessage = new MailMessage();
            //    mailMessage.From = new MailAddress("contact@nowpark.me");
            //    mailMessage.IsBodyHtml = true;
            //    mailMessage.Subject = title;
            //    mailMessage.Body = content;
            //    mailMessage.To.Add(subscriber.Email);
            //    client.Send(mailMessage);
            //}

            mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("contact@nowpark.me");
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = title;
            mailMessage.Body = content;
            mailMessage.To.Add("wbountyhunter@gmail.com");
            client.Send(mailMessage);

            return Json("Done", JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string username, string password)
        {
            if (username == "admin" && password == "password")
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }
    }
}