using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEL.Models;
using SEL.DAL;
using System.Data.Entity.SqlServer;

namespace SEL.Controllers
{
    public class OfferController : Controller
    {
        private SelContext context = new SelContext();

        //
        // GET: /Offer/

        public ViewResult Index()
        {
            return View(context.Offer.Include(offer => offer.owner).Include(offer => offer.tag).ToList());
        }

        //
        // GET: /Offer/Details/5

        public ViewResult Details(int id)
        {
            Offer offer = context.Offer.Single(x => x.ID == id);
            @ViewBag.ownerPseudo = context.User.Find(offer.ownerID).pseudo;
            List<OfferTag> otList = context.OfferTag.Where(m=>m.offerID==offer.ID).ToList();
            List<string> tagName = new List<string>();
            foreach(OfferTag ot in otList)
            {
                tagName.Add(context.Tag.Find(ot.tagID).tag);
            }
            @ViewBag.tagList = tagName;
            return View(offer);
        }
        
        //
        // GET: /Offer/Create

        public ActionResult Create()
        {
            ViewBag.Possibleowner = context.User;
            ViewBag.tagList = context.Tag.ToList().Select(m=>m.tag);
            return View();
        }

        //
        // POST: /Offer/Create

        [HttpPost]
        public ActionResult Create(Offer offer,string[] tagList)
        {
            User user = Session["login"] as User;
            offer.ownerID = user.ID;
            if (ModelState.IsValid)
            {

                context.Offer.Add(offer);
                context.SaveChanges();
                foreach (string strTag in tagList)
                {
                    if(strTag!="")
                    { 
                        Tag tag = context.Tag.Where(m => m.tag == strTag).First();
                        OfferTag newEntry = new OfferTag();
                        newEntry.tagID = tag.ID;
                        newEntry.offerID = offer.ID;
                        context.OfferTag.Add(newEntry);
                        context.SaveChanges();
                    }
                }
                return RedirectToAction("Index");  
            }

            ViewBag.Possibleowner = context.User;
            return View(offer);
        }

        //
        // GET: /Offer/Edit/5

        public ActionResult Edit(int id)
        {
            Offer offer = context.Offer.Single(x => x.ID == id);
            ViewBag.Possibleowner = context.User;
            return View(offer);
        }

        //
        // POST: /Offer/Edit/5

        [HttpPost]
        public ActionResult Edit(Offer offer)
        {
            if (ModelState.IsValid)
            {
                context.Entry(offer).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Possibleowner = context.User;
            return View(offer);
        }

        //
        // GET: /Offer/Delete/5

        public ActionResult Delete(int id)
        {
            Offer offer = context.Offer.Single(x => x.ID == id);
            return View(offer);
        }

        //
        // POST: /Offer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Offer offer = context.Offer.Single(x => x.ID == id);
            context.Offer.Remove(offer);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Search(string search)
        {
            List<Offer> offersSearch = context.Offer.Where(o => o.description.Contains(search) || o.name.Contains(search)).ToList();
            return View(offersSearch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}