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
    [Authorize]
    public class TiposServiciosDetallesController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: TiposServiciosDetalles
        public async Task<ActionResult> Index()
        {
            var tiposServiciosDetalles = db.TiposServiciosDetalles.Include(t => t.TiposServicios);
            return View(await tiposServiciosDetalles.ToListAsync());
        }

        // GET: TiposServiciosDetalles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposServiciosDetalle tiposServiciosDetalle = await db.TiposServiciosDetalles.FindAsync(id);
            if (tiposServiciosDetalle == null)
            {
                return HttpNotFound();
            }
            return View(tiposServiciosDetalle);
        }

        // GET: TiposServiciosDetalles/Create
        public ActionResult Create()
        {
            ViewBag.TipoServ_ID = new SelectList(db.TiposServicios, "TipoServ_ID", "TipoServ_Nombre");
            return View();
        }

        // POST: TiposServiciosDetalles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TiposServiciosDetalle tiposServiciosDetalle)
        {
            if (ModelState.IsValid)
            {
                db.TiposServiciosDetalles.Add(tiposServiciosDetalle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TipoServ_ID = new SelectList(db.TiposServicios, "TipoServ_ID", "TipoServ_Nombre", tiposServiciosDetalle.TipoServ_ID);
            return View(tiposServiciosDetalle);
        }

        // GET: TiposServiciosDetalles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposServiciosDetalle tiposServiciosDetalle = await db.TiposServiciosDetalles.FindAsync(id);
            if (tiposServiciosDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoServ_ID = new SelectList(db.TiposServicios, "TipoServ_ID", "TipoServ_Nombre", tiposServiciosDetalle.TipoServ_ID);
            return View(tiposServiciosDetalle);
        }

        // POST: TiposServiciosDetalles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TiposServiciosDetalle tiposServiciosDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposServiciosDetalle).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TipoServ_ID = new SelectList(db.TiposServicios, "TipoServ_ID", "TipoServ_Nombre", tiposServiciosDetalle.TipoServ_ID);
            return View(tiposServiciosDetalle);
        }

        // GET: TiposServiciosDetalles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposServiciosDetalle tiposServiciosDetalle = await db.TiposServiciosDetalles.FindAsync(id);
            if (tiposServiciosDetalle == null)
            {
                return HttpNotFound();
            }
            return View(tiposServiciosDetalle);
        }

        // POST: TiposServiciosDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TiposServiciosDetalle tiposServiciosDetalle = await db.TiposServiciosDetalles.FindAsync(id);
            db.TiposServiciosDetalles.Remove(tiposServiciosDetalle);
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
