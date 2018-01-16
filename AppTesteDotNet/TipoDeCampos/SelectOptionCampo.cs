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
            return "<select>" + RenderizarOptions() + "</select>";
        }

        private string RenderizarOptions()
        {
            string options = "";
            foreach(var opt in _options)
            {
                options += "<option value=''>" + opt + "</option>";
            }
            return options;
        }
    }
}