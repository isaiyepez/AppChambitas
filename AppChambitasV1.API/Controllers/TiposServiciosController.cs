using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AppChambitasV1.Domain;

namespace AppChambitasV1.API.Controllers
{
    public class TiposServiciosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/TiposServicios
        public IQueryable<TiposServicios> GetTiposServicios()
        {
            return db.TiposServicios;
        }

        // GET: api/TiposServicios/5
        [ResponseType(typeof(TiposServicios))]
        public async Task<IHttpActionResult> GetTiposServicios(int id)
        {
            TiposServicios tiposServicios = await db.TiposServicios.FindAsync(id);
            if (tiposServicios == null)
            {
                return NotFound();
            }

            return Ok(tiposServicios);
        }

        // PUT: api/TiposServicios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTiposServicios(int id, TiposServicios tiposServicios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tiposServicios.TipoServ_ID)
            {
                return BadRequest();
            }

            db.Entry(tiposServicios).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposServiciosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TiposServicios
        [ResponseType(typeof(TiposServicios))]
        public async Task<IHttpActionResult> PostTiposServicios(TiposServicios tiposServicios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TiposServicios.Add(tiposServicios);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tiposServicios.TipoServ_ID }, tiposServicios);
        }

        // DELETE: api/TiposServicios/5
        [ResponseType(typeof(TiposServicios))]
        public async Task<IHttpActionResult> DeleteTiposServicios(int id)
        {
            TiposServicios tiposServicios = await db.TiposServicios.FindAsync(id);
            if (tiposServicios == null)
            {
                return NotFound();
            }

            db.TiposServicios.Remove(tiposServicios);
            await db.SaveChangesAsync();

            return Ok(tiposServicios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TiposServiciosExists(int id)
        {
            return db.TiposServicios.Count(e => e.TipoServ_ID == id) > 0;
        }
    }
}