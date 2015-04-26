using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEL.Models;
using SEL.DAL;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace SEL.Controllers
{   
    public class UserController : Controller
    {
        private SelContext context = new SelContext();

        //
        // GET: /User/

        public ViewResult Index()
        {
            return View(context.User.ToList());
        }

        //
        // GET: /User/Details/5

        public ViewResult Details(int id)
        {
            User user = context.User.Single(x => x.ID == id);
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            
            {
                user.password = FormsAuthentication.HashPasswordForStoringInConfigFile(user.password,"SHA1");
                context.User.Add(user);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }
        
        //
        // GET: /User/Edit/5
 
        public ActionResult Edit(int id)
        {
            User user = context.User.Single(x => x.ID == id);
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /User/Delete/5
 
        public ActionResult Delete(int id)
        {
            User user = context.User.Single(x => x.ID == id);
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = context.User.Single(x => x.ID == id);
            List<Offer> offersToDelete = context.Offer.Where(m => m.ownerID == user.ID).ToList();
            foreach (Offer o in offersToDelete)
            {
                context.OfferTag.RemoveRange(o.tag);
            }
            context.SaveChanges();
            foreach (Offer o in context.Offer.Where(m => m.ownerID == user.ID))
            {
                context.Offer.Remove(o);
            }
            foreach (Message msg in context.Message.Where(m => m.senderID == user.ID || m.destID == user.ID))
            {
                context.Message.Remove(msg);
            }
            context.User.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

        
       
    }
}