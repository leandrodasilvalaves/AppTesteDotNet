using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppTesteDotNet.Areas.Admin.Controllers.Mvc
{
    public class CategoriasController : Controller
    {
        // GET: Admin/Categorias
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Incluir()
        {
            return View();
        }

        public ActionResult Editar()
        {
            return View();
        }
    }
}