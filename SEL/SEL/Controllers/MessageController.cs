using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEL.Models;
using SEL.DAL;

namespace SEL.Controllers
{   
    public class MessageController : Controller
    {
        private SelContext context = new SelContext();

        //
        // GET: /Message/

        public ViewResult Index()
        {
            return View(context.Message.Include(message => message.sender).Include(message => message.dest).ToList());
        }

        //
        // GET: /Message/Details/5

        public ViewResult Details(int id)
        {
            Message message = context.Message.Single(x => x.ID == id);
            return View(message);
        }

        //
        // GET: /Message/Create

        public ActionResult Create()
        {
            ViewBag.Possiblesender = context.User;
            ViewBag.Possibledest = context.User;
            return View();
        } 

        //
        // POST: /Message/Create

        [HttpPost]
        public ActionResult Create(Message message)
        {
            if (ModelState.IsValid)
            {
                context.Message.Add(message);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.Possiblesender = context.User;
            ViewBag.Possibledest = context.User;
            return View(message);
        }
        
        //
        // GET: /Message/Edit/5
 
        public ActionResult Edit(int id)
        {
            Message message = context.Message.Single(x => x.ID == id);
            ViewBag.Possiblesender = context.User;
            ViewBag.Possibledest = context.User;
            return View(message);
        }

        //
        // POST: /Message/Edit/5

        [HttpPost]
        public ActionResult Edit(Message message)
        {
            if (ModelState.IsValid)
            {
                context.Entry(message).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Possiblesender = context.User;
            ViewBag.Possibledest = context.User;
            return View(message);
        }

        //
        // GET: /Message/Delete/5
 
        public ActionResult Delete(int id)
        {
            Message message = context.Message.Single(x => x.ID == id);
            return View(message);
        }

        //
        // POST: /Message/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = context.Message.Single(x => x.ID == id);
            context.Message.Remove(message);
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