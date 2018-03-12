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
    public class TecnicosController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Tecnicos
        public async Task<ActionResult> Index()
        {
            return View(await db.Tecnicoes.ToListAsync());
        }

        // GET: Tecnicos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = await db.Tecnicoes.FindAsync(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        // GET: Tecnicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tecnicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Tecn_ID,Tecn_Nombre,Tecn_Correo,Tecn_Contrasenia,Tecn_Domicilio,Tecn_Promedio,Tecn_Activo,Tecn_FechaHora,Tecn_ModificadoPor")] Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                db.Tecnicoes.Add(tecnico);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tecnico);
        }

        // GET: Tecnicos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = await db.Tecnicoes.FindAsync(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        // POST: Tecnicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Tecn_ID,Tecn_Nombre,Tecn_Correo,Tecn_Contrasenia,Tecn_Domicilio,Tecn_Promedio,Tecn_Activo,Tecn_FechaHora,Tecn_ModificadoPor")] Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tecnico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tecnico);
        }

        // GET: Tecnicos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = await db.Tecnicoes.FindAsync(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        // POST: Tecnicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tecnico tecnico = await db.Tecnicoes.FindAsync(id);
            db.Tecnicoes.Remove(tecnico);
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
