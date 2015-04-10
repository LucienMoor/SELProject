using SEL.DAL;
using SEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEL.Controllers
{
    public class HomeController : Controller
    {
        private SelContext sel = new SelContext();

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

        public ActionResult Login(string password, string email)
        {
            User user = sel.User.Where(u => u.password == password && u.email == email).FirstOrDefault();
            if(user == null)
            {
                ViewBag.Message = "Non valide Password or email";
            }
            else
            {
                ViewBag.Message = "You are logged in";
                Session["login"] = user;
            }
            return View("Index");
            
        }

        public ActionResult Logout()
        {
            Session["login"] = null;
            return View("Index");

        }
    }
}