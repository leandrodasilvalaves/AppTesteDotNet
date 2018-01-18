using AppTesteDotNet.Models.Context;
using AppTesteDotNet.Models.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace AppTesteDotNet.Areas.Admin.Controllers.Api
{
    public class CamposController : ApiController
    {
        private AppContext db = new AppContext();

        // GET: api/Campos
        public IEnumerable<Campo> GetCampos([FromUri]int subCategoriaId)
        {
            return db.Campos.Where(c => c.SubCategoriaId == subCategoriaId).ToList();
        }

        // GET: api/Campos/5
        [ResponseType(typeof(Campo))]
        public IHttpActionResult GetCampo([FromUri]int id)
        {
            Campo campo = db.Campos.Find(id);
            if (campo == null)
            {
                return NotFound();
            }

            return Ok(campo);
        }

        public int GetOrdemParaNovoCampo([FromUri]int _subCategoriaId)
        {
            var lista = (List<Campo>)GetCampos(_subCategoriaId);
            if(lista.Count >0)
                return lista.Max(c => c.Ordem) +1;

            return 1;
        }

        // PUT: api/Campos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCampo(int id, Campo campo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != campo.Id)
            {
                return BadRequest();
            }

            db.Entry(campo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampoExists(id))
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

        // POST: api/Campos
        [ResponseType(typeof(Campo))]
        public IHttpActionResult PostCampo(Campo campo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Campos.Add(campo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = campo.Id }, campo);
        }

        // DELETE: api/Campos/5
        [ResponseType(typeof(Campo))]
        public IHttpActionResult DeleteCampo(int id)
        {
            Campo campo = db.Campos.Find(id);
            if (campo == null)
            {
                return NotFound();
            }

            db.Campos.Remove(campo);
            db.SaveChanges();

            return Ok(campo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CampoExists(int id)
        {
            return db.Campos.Count(e => e.Id == id) > 0;
        }
    }
}