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
    public class TiposServiciosController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: TiposServicios
        public async Task<ActionResult> Index()
        {
            return View(await db.TiposServicios.ToListAsync());
        }

        // GET: TiposServicios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposServicios tiposServicios = await db.TiposServicios.FindAsync(id);
            if (tiposServicios == null)
            {
                return HttpNotFound();
            }
            return View(tiposServicios);
        }

        // GET: TiposServicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposServicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TipoServ_ID,TipoServ_Nombre,TipoServ_Descripcion")] TiposServicios tiposServicios)
        {
            if (ModelState.IsValid)
            {
                db.TiposServicios.Add(tiposServicios);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tiposServicios);
        }

        // GET: TiposServicios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposServicios tiposServicios = await db.TiposServicios.FindAsync(id);
            if (tiposServicios == null)
            {
                return HttpNotFound();
            }
            return View(tiposServicios);
        }

        // POST: TiposServicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TipoServ_ID,TipoServ_Nombre,TipoServ_Descripcion")] TiposServicios tiposServicios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposServicios).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tiposServicios);
        }

        // GET: TiposServicios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposServicios tiposServicios = await db.TiposServicios.FindAsync(id);
            if (tiposServicios == null)
            {
                return HttpNotFound();
            }
            return View(tiposServicios);
        }

        // POST: TiposServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TiposServicios tiposServicios = await db.TiposServicios.FindAsync(id);
            db.TiposServicios.Remove(tiposServicios);
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
