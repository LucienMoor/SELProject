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
            List<Message> messages= new List<Message>();
            User user = Session["login"] as User;
            return View(context.Message.Where(m=>m.destID==user.ID).ToList());
            //return View(context.Message.Include(message => message.sender).Include(message => message.dest).ToList());
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
        public ActionResult Create(Message msg,string dest)
        {
            User destUser = context.User.Where(m=>m.pseudo==dest).First();
            User user = Session["login"] as User;
            msg.senderID = user.ID;
            msg.destID = destUser.ID;
            if(msg.title !=null && msg.message!=null && msg.senderID !=0 && msg.destID!= 0)
            {
                context.Message.Add(msg);
                context.SaveChanges();
                return RedirectToAction("Index"); 
            }
 
            /*if (ModelState.IsValid)
            {
                context.Message.Add(msg);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }*/
            
            ViewBag.Possiblesender = context.User;
            ViewBag.Possibledest = context.User;
            return View(msg);
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
        public ActionResult Edit(Message msg)
        {
            if (ModelState.IsValid)
            {
                context.Entry(msg).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Possiblesender = context.User;
            ViewBag.Possibledest = context.User;
            return View(msg);
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