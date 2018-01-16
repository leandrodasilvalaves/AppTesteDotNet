namespace AppTesteDotNet.TipoDeCampos
{
    public class TextAreaCampo : ITipoDeCampo
    {
        private int _rows =5;

        public TextAreaCampo(){ }

        public TextAreaCampo(int rows)
        {
            _rows = rows;
        }

        public string Renderizar()
        {
            return "<textarea rows='" + _rows +"' cols=''></textarea>";
        }
    }
}