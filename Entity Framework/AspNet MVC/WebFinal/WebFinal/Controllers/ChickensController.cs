using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebFinal.Models;

namespace WebFinal.Controllers
{
    public class ChickensController : Controller
    {
        private FarmEntities db = new FarmEntities();

        // GET: Chickens
        public ActionResult Index()
        {
            var chickens = db.Chickens.Include(c => c.Breed).Include(c => c.Worker).Include(c => c.Workshop);
            return View(chickens.ToList());
        }

        // GET: Chickens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chicken chicken = db.Chickens.Find(id);
            if (chicken == null)
            {
                return HttpNotFound();
            }
            return View(chicken);
        }

        // GET: Chickens/Create
        public ActionResult Create()
        {
            ViewBag.IdBreed = new SelectList(db.Breeds, "id", "Name");
            ViewBag.IdWorker = new SelectList(db.Workers, "id", "SurnameNP");
            ViewBag.IdWorkshop = new SelectList(db.Workshops, "id", "id");
            return View();
        }

        // POST: Chickens/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Weight,Age,Eggs,IdBreed,IdWorkshop,IdWorker")] Chicken chicken)
        {
            if (ModelState.IsValid)
            {
                db.Chickens.Add(chicken);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdBreed = new SelectList(db.Breeds, "id", "Name", chicken.IdBreed);
            ViewBag.IdWorker = new SelectList(db.Workers, "id", "SurnameNP", chicken.IdWorker);
            ViewBag.IdWorkshop = new SelectList(db.Workshops, "id", "id", chicken.IdWorkshop);
            return View(chicken);
        }

        // GET: Chickens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chicken chicken = db.Chickens.Find(id);
            if (chicken == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdBreed = new SelectList(db.Breeds, "id", "Name", chicken.IdBreed);
            ViewBag.IdWorker = new SelectList(db.Workers, "id", "SurnameNP", chicken.IdWorker);
            ViewBag.IdWorkshop = new SelectList(db.Workshops, "id", "id", chicken.IdWorkshop);
            return View(chicken);
        }

        // POST: Chickens/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Weight,Age,Eggs,IdBreed,IdWorkshop,IdWorker")] Chicken chicken)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chicken).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdBreed = new SelectList(db.Breeds, "id", "Name", chicken.IdBreed);
            ViewBag.IdWorker = new SelectList(db.Workers, "id", "SurnameNP", chicken.IdWorker);
            ViewBag.IdWorkshop = new SelectList(db.Workshops, "id", "id", chicken.IdWorkshop);
            return View(chicken);
        }

        // GET: Chickens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chicken chicken = db.Chickens.Find(id);
            if (chicken == null)
            {
                return HttpNotFound();
            }
            return View(chicken);
        }

        // POST: Chickens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chicken chicken = db.Chickens.Find(id);
            db.Chickens.Remove(chicken);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
