using System;

namespace AppTesteDotNet.TipoDeCampos
{
    public class CheckBoxCampo : ITipoDeCampo
    {
        private string _label;

        public CheckBoxCampo(string label)
        {
            _label = label;
        }

        public string Renderizar()
        {
            return "<input type='checkbox' name='' value=''> " + _label;
        }
    }
}