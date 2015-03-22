using System;
using System.Linq;
using System.Web.Mvc;
using dancenew.Models;
using dancenew.Data;
using dancenew.Services;

namespace dancenew.Controllers
{
    public class HomeController : Controller
    {
        private IDanceRepository _dDb;
        private IMailService _mail;

        public HomeController(IDanceRepository dDb, IMailService mail)
        {
            _mail = mail;
            _dDb = dDb;
        }
         
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View(); 
                
            }
            
        }

        public ActionResult About()
        {
            var bios = _dDb.GetBios().ToList();
            return View(bios);
        }

        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var msg = string.Format("Comment From: {1}{0}Email:{2}{0}Message: {3}",
                Environment.NewLine,
                model.Name,
            model.Email,
            model.Message);

            if (_mail.SendMail("noreply@ymydancediscovery.com",
                "ddmail@mydancediscovery.com", "Sent from website", msg))
            {
                ViewBag.MailSent = true;
            }
            return View();
        }
        
    }
}
