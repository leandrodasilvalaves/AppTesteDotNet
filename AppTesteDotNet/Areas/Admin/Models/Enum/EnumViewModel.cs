using System;
using System.Collections.Generic;

namespace AppTesteDotNet.Areas.Admin.Models.Enum
{
    public abstract class EnumViewModel
    {
        private ICollection<EnumObj> Lista { get; set; }
        public Array EnumValues { get; set; }


        #region [ Metodos Publicos ] 

        public ICollection<EnumObj> GetLista()
        {
            SetEnum();
            PopularLista();
            return Lista;
        }

        public abstract void SetEnum();

        #endregion


        #region [ Métodos Privados ]

        private void PopularLista()
        {
            Lista = new List<EnumObj>();
            foreach (var enValue in EnumValues)
            {
                Lista.Add(new EnumObj { Num = (int)enValue, Display = DisplayEnum.GetDisplayName((System.Enum)enValue) });
            }
        }

        #endregion
    }
}