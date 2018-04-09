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
    public class ServiciosTecnicosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/ServiciosTecnicos
        public IQueryable<ServiciosTecnicos> GetServiciosTecnicos()
        {
            return db.ServiciosTecnicos;
        }

        // GET: api/ServiciosTecnicos/5
        [ResponseType(typeof(ServiciosTecnicos))]
        public async Task<IHttpActionResult> GetServiciosTecnicos(int id)
        {
            ServiciosTecnicos serviciosTecnicos = await db.ServiciosTecnicos.FindAsync(id);
            if (serviciosTecnicos == null)
            {
                return NotFound();
            }

            return Ok(serviciosTecnicos);
        }

        // PUT: api/ServiciosTecnicos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutServiciosTecnicos(int id, ServiciosTecnicos serviciosTecnicos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviciosTecnicos.ServTecn_ID)
            {
                return BadRequest();
            }

            db.Entry(serviciosTecnicos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciosTecnicosExists(id))
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

        // POST: api/ServiciosTecnicos
        [ResponseType(typeof(ServiciosTecnicos))]
        public async Task<IHttpActionResult> PostServiciosTecnicos(ServiciosTecnicos serviciosTecnicos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiciosTecnicos.Add(serviciosTecnicos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = serviciosTecnicos.ServTecn_ID }, serviciosTecnicos);
        }

        // DELETE: api/ServiciosTecnicos/5
        [ResponseType(typeof(ServiciosTecnicos))]
        public async Task<IHttpActionResult> DeleteServiciosTecnicos(int id)
        {
            ServiciosTecnicos serviciosTecnicos = await db.ServiciosTecnicos.FindAsync(id);
            if (serviciosTecnicos == null)
            {
                return NotFound();
            }

            db.ServiciosTecnicos.Remove(serviciosTecnicos);
            await db.SaveChangesAsync();

            return Ok(serviciosTecnicos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiciosTecnicosExists(int id)
        {
            return db.ServiciosTecnicos.Count(e => e.ServTecn_ID == id) > 0;
        }
    }
}