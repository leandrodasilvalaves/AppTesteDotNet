using AppTesteDotNet.Models.Context;
using AppTesteDotNet.Models.Entities;
using AppTesteDotNet.Models.Intefaces;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace AppTesteDotNet.Areas.Admin.Controllers.Api
{
    public class SubCategoriasController : ApiController
    {
        private IAppContext db;

        public SubCategoriasController()
        {
            db = new AppContext();
        }
        public SubCategoriasController(IAppContext context)
        {
            db = context;
        }

        // GET: api/SubCategorias
        public IQueryable<SubCategoria> GetSubCategorias()
        {
            return db.SubCategorias;
        }

        // GET: api/SubCategorias/5
        [ResponseType(typeof(SubCategoria))]
        public IHttpActionResult GetSubCategoria(int id)
        {
            SubCategoria subCategoria = db.SubCategorias.Find(id);
            if (subCategoria == null)
            {
                return NotFound();
            }

            return Ok(subCategoria);
        }

        // PUT: api/SubCategorias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubCategoria(int id, SubCategoria subCategoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subCategoria.Id)
            {
                return BadRequest();
            }

            db.Entry(subCategoria).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoriaExists(id))
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

        // POST: api/SubCategorias
        [ResponseType(typeof(SubCategoria))]
        public IHttpActionResult PostSubCategoria(SubCategoria subCategoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubCategorias.Add(subCategoria);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subCategoria.Id }, subCategoria);
        }

        // DELETE: api/SubCategorias/5
        [ResponseType(typeof(SubCategoria))]
        public IHttpActionResult DeleteSubCategoria(int id)
        {
            SubCategoria subCategoria = db.SubCategorias.Find(id);
            if (subCategoria == null)
            {
                return NotFound();
            }

            db.SubCategorias.Remove(subCategoria);
            db.SaveChanges();

            return Ok(subCategoria);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubCategoriaExists(int id)
        {
            return db.SubCategorias.Count(e => e.Id == id) > 0;
        }
    }
}