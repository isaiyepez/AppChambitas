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
    public class ServiciosController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Servicios
        public async Task<ActionResult> Index()
        {
            var servicios = db.Servicios.Include(s => s.Tecnico).Include(s => s.Usuario);
            return View(await servicios.ToListAsync());
        }

        // GET: Servicios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = await db.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            ViewBag.Tecn_ID = new SelectList(db.Tecnicoes, "Tecn_ID", "Tecn_Nombre");
            ViewBag.Usua_ID = new SelectList(db.Usuarios, "Usua_ID", "Usua_Nombre");
            return View();
        }

        // POST: Servicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Serv_ID,Usua_ID,Tecn_ID,Serv_FechaHoraSolicitud,Serv_FechaSolicitada,Serv_Latitud,Serv_Longitud,Serv_FechaHoraCumplida,Serv_Evaluacion,Serv_Domicilio,Serv_Comentarios,Serv_FechaHora,Serv_ModificadoPor")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Servicios.Add(servicio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Tecn_ID = new SelectList(db.Tecnicoes, "Tecn_ID", "Tecn_Nombre", servicio.Tecn_ID);
            ViewBag.Usua_ID = new SelectList(db.Usuarios, "Usua_ID", "Usua_Nombre", servicio.Usua_ID);
            return View(servicio);
        }

        // GET: Servicios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = await db.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tecn_ID = new SelectList(db.Tecnicoes, "Tecn_ID", "Tecn_Nombre", servicio.Tecn_ID);
            ViewBag.Usua_ID = new SelectList(db.Usuarios, "Usua_ID", "Usua_Nombre", servicio.Usua_ID);
            return View(servicio);
        }

        // POST: Servicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Serv_ID,Usua_ID,Tecn_ID,Serv_FechaHoraSolicitud,Serv_FechaSolicitada,Serv_Latitud,Serv_Longitud,Serv_FechaHoraCumplida,Serv_Evaluacion,Serv_Domicilio,Serv_Comentarios,Serv_FechaHora,Serv_ModificadoPor")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicio).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Tecn_ID = new SelectList(db.Tecnicoes, "Tecn_ID", "Tecn_Nombre", servicio.Tecn_ID);
            ViewBag.Usua_ID = new SelectList(db.Usuarios, "Usua_ID", "Usua_Nombre", servicio.Usua_ID);
            return View(servicio);
        }

        // GET: Servicios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = await db.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Servicio servicio = await db.Servicios.FindAsync(id);
            db.Servicios.Remove(servicio);
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
