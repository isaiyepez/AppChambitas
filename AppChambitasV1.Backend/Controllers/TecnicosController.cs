using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using AppChambitasV1.Backend.Models;
using AppChambitasV1.Domain;
using AppChambitasV1.Backend.Helper;
using System;

namespace AppChambitasV1.Backend.Controllers
{
    [Authorize]
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
        public async Task<ActionResult> Create(TecnicoView view)
        {
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/Images";

                if (view.ImageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                var tecnico = ToTecnico(view);
                tecnico.Tecn_Imagen = pic;
                db.Tecnicoes.Add(tecnico);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View(view);
        }

        private Tecnico ToTecnico(TecnicoView view)
        {
            return new Tecnico
            {
                Tecn_ID = view.Tecn_ID,
                Tecn_Nombre = view.Tecn_Nombre,
                Tecn_Correo = view.Tecn_Correo,
                Tecn_Contrasenia = view.Tecn_Contrasenia,
                Tecn_Domicilio = view.Tecn_Domicilio,
                Tecn_Activo = view.Tecn_Activo,
                Tecn_Promedio = view.Tecn_Promedio,
                Tecn_Imagen = view.Tecn_Imagen,
                Tecn_FechaHora = view.Tecn_FechaHora,
                Tecn_ModificadoPor = view.Tecn_ModificadoPor
            };
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
            var view = ToView(tecnico);
            return View(view);
        }

        private TecnicoView ToView(Tecnico tecnico)
        {
            return new TecnicoView
            {
                Tecn_ID = tecnico.Tecn_ID,
                Tecn_Nombre = tecnico.Tecn_Nombre,
                Tecn_Correo = tecnico.Tecn_Correo,
                Tecn_Contrasenia = tecnico.Tecn_Contrasenia,
                Tecn_Domicilio = tecnico.Tecn_Domicilio,
                Tecn_Activo = tecnico.Tecn_Activo,
                Tecn_Promedio = tecnico.Tecn_Promedio,
                Tecn_Imagen = tecnico.Tecn_Imagen,
                Tecn_FechaHora = tecnico.Tecn_FechaHora,
                Tecn_ModificadoPor = tecnico.Tecn_ModificadoPor
            };
        }

        // POST: Tecnicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TecnicoView view)
        {
            if (ModelState.IsValid)
            {
                var pic = view.Tecn_Imagen;
                var folder = "~/Content/Images";

                if (view.ImageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }
                var tecnico = ToTecnico(view);
                tecnico.Tecn_Imagen = pic;

                db.Entry(tecnico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(view);
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
