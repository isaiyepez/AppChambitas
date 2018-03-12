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
    public class TecnicosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Tecnicos
        public IQueryable<Tecnico> GetTecnicoes()
        {
            return db.Tecnicoes;
        }

        // GET: api/Tecnicos/5
        [ResponseType(typeof(Tecnico))]
        public async Task<IHttpActionResult> GetTecnico(int id)
        {
            Tecnico tecnico = await db.Tecnicoes.FindAsync(id);
            if (tecnico == null)
            {
                return NotFound();
            }

            return Ok(tecnico);
        }

        // PUT: api/Tecnicos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTecnico(int id, Tecnico tecnico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tecnico.Tecn_ID)
            {
                return BadRequest();
            }

            db.Entry(tecnico).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TecnicoExists(id))
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

        // POST: api/Tecnicos
        [ResponseType(typeof(Tecnico))]
        public async Task<IHttpActionResult> PostTecnico(Tecnico tecnico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tecnicoes.Add(tecnico);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tecnico.Tecn_ID }, tecnico);
        }

        // DELETE: api/Tecnicos/5
        [ResponseType(typeof(Tecnico))]
        public async Task<IHttpActionResult> DeleteTecnico(int id)
        {
            Tecnico tecnico = await db.Tecnicoes.FindAsync(id);
            if (tecnico == null)
            {
                return NotFound();
            }

            db.Tecnicoes.Remove(tecnico);
            await db.SaveChangesAsync();

            return Ok(tecnico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TecnicoExists(int id)
        {
            return db.Tecnicoes.Count(e => e.Tecn_ID == id) > 0;
        }
    }
}