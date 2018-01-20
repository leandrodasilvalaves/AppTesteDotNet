namespace AppTesteDotNet.TipoDeCampos
{
    public class SelectOptionCampo : ITipoDeCampo
    {
        private string[] _options;

        public SelectOptionCampo(string[] options)
        {
            _options = options;
        }

        public string Renderizar()
        {
            return "<select class='form-control'>" + RenderizarOptions() + "</select>";
        }

        private string RenderizarOptions()
        {
            string options = "";
            var i = 1;
            foreach(var opt in _options)
            {
                options += "<option value='"+ i +"'>" + opt + "</option>";
                i++;
            }
            return options;
        }
    }
}