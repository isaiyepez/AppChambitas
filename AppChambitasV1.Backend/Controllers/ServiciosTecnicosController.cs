using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppChambitasV1.Backend.Models;
using AppChambitasV1.Domain;

namespace AppChambitasV1.Backend.Controllers
{
    public class ServiciosTecnicosController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: ServiciosTecnicos
        public async Task<ActionResult> Index()
        {
            return View(await db.ServiciosTecnicos.ToListAsync());
        }

        // GET: ServiciosTecnicos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiciosTecnicos serviciosTecnicos = await db.ServiciosTecnicos.FindAsync(id);
            if (serviciosTecnicos == null)
            {
                return HttpNotFound();
            }
            return View(serviciosTecnicos);
        }

        // GET: ServiciosTecnicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiciosTecnicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ServTecn_ID,ServTecn_Activo")] ServiciosTecnicos serviciosTecnicos)
        {
            if (ModelState.IsValid)
            {
                db.ServiciosTecnicos.Add(serviciosTecnicos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(serviciosTecnicos);
        }

        // GET: ServiciosTecnicos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiciosTecnicos serviciosTecnicos = await db.ServiciosTecnicos.FindAsync(id);
            if (serviciosTecnicos == null)
            {
                return HttpNotFound();
            }
            return View(serviciosTecnicos);
        }

        // POST: ServiciosTecnicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ServTecn_ID,ServTecn_Activo")] ServiciosTecnicos serviciosTecnicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviciosTecnicos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(serviciosTecnicos);
        }

        // GET: ServiciosTecnicos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiciosTecnicos serviciosTecnicos = await db.ServiciosTecnicos.FindAsync(id);
            if (serviciosTecnicos == null)
            {
                return HttpNotFound();
            }
            return View(serviciosTecnicos);
        }

        // POST: ServiciosTecnicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ServiciosTecnicos serviciosTecnicos = await db.ServiciosTecnicos.FindAsync(id);
            db.ServiciosTecnicos.Remove(serviciosTecnicos);
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
