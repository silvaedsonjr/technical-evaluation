using AppMvc.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppMvc.Controllers
{
    [Authorize]
    public class CollaboratorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task<ActionResult> Index()
        {
            return View(await db.Collaborators.ToListAsync());
        }

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

        public ActionResult Create()
        {
            return View();
        }

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
