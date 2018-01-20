using System.Web.Mvc;

namespace AppTesteDotNet.Controllers
{
    public class FormulariosController : Controller
    {

        // GET: Categorias
        public ActionResult CategoriasForms()
        {
            return View();
        }

        public ActionResult SubCategoriasForms()
        {
            return View();
        }

        public ActionResult Forms()
        {
            return View();
        }

    }
}
