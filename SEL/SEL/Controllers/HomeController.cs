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
                ViewBag.message = "Non valide Password or email";
            }
            else
            {
                ViewBag.message = "You are logged in";
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
            //list offer
            List<Offer> listOffer = sel.Set<Offer>().Where(m => m.endDate.Year >= DateTime.Now.Year && m.endDate.Month >= DateTime.Now.Month && m.endDate.Day >= DateTime.Now.Day).ToList();
            @ViewBag.offer = listOffer.Skip(Math.Max(0, listOffer.Count() - 5)).Take(5).OrderByDescending(o => o.ID);

            //map offer
            var tmp = sel.Set<Offer>().ToArray();
            List<Offer> validOffers = new List<Offer>();
            foreach (Offer o in tmp)
            {
                DateTime dt = o.endDate;
                if (DateTime.Compare(DateTime.Now, dt) < 0)
                {
                    validOffers.Add(o);
                }

            }
            List<double> longitude = new List<double>();
            List<double> latitude = new List<double>();
            foreach (Offer o in validOffers)
            {
                longitude.Add(o.longitude);
                latitude.Add(o.latitude);
            }
            @ViewBag.nbOffer = validOffers.Count;
            @ViewBag.longitude = longitude;
            @ViewBag.latitude = latitude;
        }
    }
}