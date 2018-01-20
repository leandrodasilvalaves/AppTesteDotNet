namespace AppTesteDotNet.TipoDeCampos
{
    public class TextCampo : ITipoDeCampo
    {
        public string Renderizar()
        {
            return "<input type='text' class='form-control' name='' value=''>";
        }
    }
}