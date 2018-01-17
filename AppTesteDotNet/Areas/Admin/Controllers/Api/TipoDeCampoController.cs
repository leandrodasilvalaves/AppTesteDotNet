using AppTesteDotNet.Areas.Admin.Models.Enum;
using System.Collections.Generic;
using System.Web.Http;

namespace AppTesteDotNet.Areas.Admin.Controllers.Api
{
    public class TipoDeCampoController : ApiController
    {
        public IEnumerable<EnumObj> GetTipoDeCampos()
        {
            var tipoDeCampo = new TipoDeCampoViewModel();
            return tipoDeCampo.GetLista();
        }
    }
}
