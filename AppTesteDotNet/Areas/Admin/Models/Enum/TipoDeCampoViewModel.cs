using AppTesteDotNet.Enum;

namespace AppTesteDotNet.Areas.Admin.Models.Enum
{
    public class TipoDeCampoViewModel : EnumViewModel
    {
        public override void SetEnum()
        {
            this.EnumValues = System.Enum.GetValues(typeof(HtmlCampo));
        }
    }
}