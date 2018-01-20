using AppTesteDotNet.Enum;
using AppTesteDotNet.Models.Context;
using AppTesteDotNet.Models.Entities;
using AppTesteDotNet.Models.Intefaces;
using AppTesteDotNet.TipoDeCampos;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AppTesteDotNet.Controllers.Api
{
    public class FormulariosController : ApiController
    {
        private IAppContext db;

        public FormulariosController(IAppContext context)
        {
            db = context;
        }

        public FormulariosController()
        {
            db = new AppContext();
        }

        // GET: api/Categorias
        public IEnumerable<Categoria> GetFormularios()
        {
            return db.Categorias.ToList();
        }

        public Categoria GetFormulario(int id)
        {
            return db.Categorias.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<SubCategoria> GetSubCategoriasPorCategoria([FromUri]int idCategoria)
        {
            return db.SubCategorias.Where(s => s.CategoriaId == idCategoria);
        }

        public IEnumerable<Campo> GetCamposPorSubCategoria([FromUri]int idSubCategoria)
        {
            var campos = db.Campos.Where(c => c.SubCategoriaId == idSubCategoria).ToList();
            foreach(var cp in campos)
            {
                string[] array;
                switch (cp.Tipo)
                {
                    case (int)HtmlCampo.CHECKBOX:
                        array = GetListaOpcoes(cp.Lista);
                        cp.Renderizar(new CheckBoxCampo(array));
                        break;

                    case (int)HtmlCampo.SELECT:
                        array = GetListaOpcoes(cp.Lista);
                        cp.Renderizar(new SelectOptionCampo(array));
                        break;

                    case (int)HtmlCampo.TEXT:
                        cp.Renderizar(new TextCampo());
                        break;

                    case (int)HtmlCampo.TEXTAREA:
                        cp.Renderizar(new TextAreaCampo());
                        break;

                    default:
                        break;
                }
            }
            return campos;
        }

        public IEnumerable<Lista> GetListaOpcoesPorCampo([FromUri]int idCampo)
        {
            return db.Listas.Where(l => l.CampoId == idCampo).ToList();
        }

        private string[] GetListaOpcoes(ICollection<Lista> lista)
        {
               int i = 0;
               string[] array = new string[lista.Count];
               foreach(var l in lista)
               {
                    array[i] = l.Descricao;
                    i++;
               }
                return array;
        }
    }
}
