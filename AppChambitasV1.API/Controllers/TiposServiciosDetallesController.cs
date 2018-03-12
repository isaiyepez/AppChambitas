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
    public class TiposServiciosDetallesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/TiposServiciosDetalles
        public IQueryable<TiposServiciosDetalle> GetTiposServiciosDetalles()
        {
            return db.TiposServiciosDetalles;
        }

        // GET: api/TiposServiciosDetalles/5
        [ResponseType(typeof(TiposServiciosDetalle))]
        public async Task<IHttpActionResult> GetTiposServiciosDetalle(int id)
        {
            TiposServiciosDetalle tiposServiciosDetalle = await db.TiposServiciosDetalles.FindAsync(id);
            if (tiposServiciosDetalle == null)
            {
                return NotFound();
            }

            return Ok(tiposServiciosDetalle);
        }

        // PUT: api/TiposServiciosDetalles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTiposServiciosDetalle(int id, TiposServiciosDetalle tiposServiciosDetalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tiposServiciosDetalle.TipoServDeta_ID)
            {
                return BadRequest();
            }

            db.Entry(tiposServiciosDetalle).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposServiciosDetalleExists(id))
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

        // POST: api/TiposServiciosDetalles
        [ResponseType(typeof(TiposServiciosDetalle))]
        public async Task<IHttpActionResult> PostTiposServiciosDetalle(TiposServiciosDetalle tiposServiciosDetalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TiposServiciosDetalles.Add(tiposServiciosDetalle);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tiposServiciosDetalle.TipoServDeta_ID }, tiposServiciosDetalle);
        }

        // DELETE: api/TiposServiciosDetalles/5
        [ResponseType(typeof(TiposServiciosDetalle))]
        public async Task<IHttpActionResult> DeleteTiposServiciosDetalle(int id)
        {
            TiposServiciosDetalle tiposServiciosDetalle = await db.TiposServiciosDetalles.FindAsync(id);
            if (tiposServiciosDetalle == null)
            {
                return NotFound();
            }

            db.TiposServiciosDetalles.Remove(tiposServiciosDetalle);
            await db.SaveChangesAsync();

            return Ok(tiposServiciosDetalle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TiposServiciosDetalleExists(int id)
        {
            return db.TiposServiciosDetalles.Count(e => e.TipoServDeta_ID == id) > 0;
        }
    }
}