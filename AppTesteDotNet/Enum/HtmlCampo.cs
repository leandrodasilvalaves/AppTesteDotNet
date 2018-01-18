using System.ComponentModel.DataAnnotations;

namespace AppTesteDotNet.Enum
{
    public enum HtmlCampo
    {
        [Display(Name = "Checkbox")]
        CHECKBOX = 1,

        [Display(Name = "Select")]
        SELECT = 2,

        [Display(Name = "Text")]
        TEXT = 3,

        [Display(Name = "Textarea")]
        TEXTAREA = 4
    }
}