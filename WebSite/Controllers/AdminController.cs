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
        public JsonResult SendEmails(string title, string content)
        {
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("contact@nowpark.me", "ninja");
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("contact@nowpark.me");
            mailMessage.Subject = title;
            mailMessage.Body = content;

            foreach (var subscriber in db.Subscribers)
            {
                mailMessage.To.Add(subscriber.Email);
            }

            client.Send(mailMessage);
            return Json("True");
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string username,string password)
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