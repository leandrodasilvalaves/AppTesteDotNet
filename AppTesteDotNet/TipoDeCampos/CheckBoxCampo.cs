using System;

namespace AppTesteDotNet.TipoDeCampos
{
    public class CheckBoxCampo : ITipoDeCampo
    {
        private string[] _labels;

        public CheckBoxCampo(string []labels)
        {
            _labels = labels;
        }

        public string Renderizar()
        {
            return "<ul class='list-group' style='max-width:50 %;'>" +
                       PreencherLista() + 
                   "</ul>";
        }

        private string PreencherLista()
        {
            string lista = "";
            foreach(string label in _labels)
            {
                lista += "<li class='list-group-item'><input type = 'checkbox' value=''> - " + label + "</li>";
            }
            return lista;
        }
    }
}