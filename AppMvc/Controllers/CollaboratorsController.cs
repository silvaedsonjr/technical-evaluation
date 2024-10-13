using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppMvc.Models;

namespace AppMvc.Controllers
{
    public class CollaboratorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Collaborators
        public async Task<ActionResult> Index()
        {
            return View(await db.Collaborators.ToListAsync());
        }

        // GET: Collaborators/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collaborator collaborator = await db.Collaborators.FindAsync(id);
            if (collaborator == null)
            {
                return HttpNotFound();
            }
            return View(collaborator);
        }

        // GET: Collaborators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Collaborators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,CodigoUnidade,IdUnidade,Ativo")] Collaborator collaborator)
        {
            if (ModelState.IsValid)
            {
                db.Collaborators.Add(collaborator);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(collaborator);
        }

        // GET: Collaborators/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collaborator collaborator = await db.Collaborators.FindAsync(id);
            if (collaborator == null)
            {
                return HttpNotFound();
            }
            return View(collaborator);
        }

        // POST: Collaborators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,CodigoUnidade,IdUnidade,Ativo")] Collaborator collaborator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collaborator).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(collaborator);
        }

        // GET: Collaborators/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collaborator collaborator = await db.Collaborators.FindAsync(id);
            if (collaborator == null)
            {
                return HttpNotFound();
            }
            return View(collaborator);
        }

        // POST: Collaborators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Collaborator collaborator = await db.Collaborators.FindAsync(id);
            db.Collaborators.Remove(collaborator);
            await db.SaveChangesAsync();
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
