using System.Web.Mvc;

namespace AppTesteDotNet.Areas.Admin.Controllers.Mvc
{
    public class BaseController : Controller
    {
        public ActionResult Index() { return View(); }

        public ActionResult Incluir() { return View(); }

        public ActionResult Editar() { return View(); }
    }
}