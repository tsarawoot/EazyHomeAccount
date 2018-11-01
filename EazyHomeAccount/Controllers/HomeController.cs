using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EazyHomeAccount.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EazyHomeAccount.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Login()
        {
            ViewBag.Message = "Please Login.";
            return View();
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "Please Sign Up.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                //build message
                var body = "<p>Email From: {0} ({1})</p>" +
                    "<p>Message:</p>" +
                    "<p>{2}</p>";
                var message = new MailMessage();
                message.From = new MailAddress("t.sarawoot@gmail.com");//sender
                message.To.Add(new MailAddress("t.sarawoot@jcm-thai.co.th"));//receiver
                message.Subject = "Test email MVC";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                //smtp client - sender mail server setup
                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "t.sarawoot@gmail.com",
                        Password = "$@Ra2014gmail"
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("EmailSent");                    
                }
            }
            return View(model);
        }

        public ActionResult EmailSent()
        {
            return View();
        }
    }
}