using SEL.DAL;
using SEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SEL.Controllers
{
    public class HomeController : Controller
    {
        private SelContext sel = new SelContext();
        public ActionResult Index()
        {
            setOffersViewBag();
            List<Offer> listOffer = sel.Set<Offer>().ToList();

            @ViewBag.offer = listOffer.Skip(Math.Max(0, listOffer.Count() - 5)).Take(5).OrderByDescending(o=>o.ID);
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
            password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
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
            setOffersViewBag();
            List<Offer> listOffer = sel.Set<Offer>().ToList();
            @ViewBag.offer = listOffer.Skip(Math.Max(0, listOffer.Count() - 5)).Take(5).OrderByDescending(o => o.ID);
            return View("Index");
            
        }

        public ActionResult Logout()
        {
            Session["login"] = null;
            setOffersViewBag();
            List<Offer> listOffer = sel.Set<Offer>().ToList();
            @ViewBag.offer = listOffer.Skip(Math.Max(0, listOffer.Count() - 5)).Take(5).OrderByDescending(o => o.ID);
            return View("Index");

        }

        private void setOffersViewBag()
        {
            var tmp = sel.Set<Offer>().ToArray();
            List<double> longitude = new List<double>();
            List<double> latitude = new List<double>();
            foreach (Offer o in tmp)
            {
                longitude.Add(o.longitude);
                latitude.Add(o.latitude);
            }
            @ViewBag.nbOffer = sel.Set<Offer>().ToList().Count;
            @ViewBag.longitude = longitude;
            @ViewBag.latitude = latitude;
        }
    }
}