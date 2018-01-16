using AppTesteDotNet.TipoDeCampos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppTesteDotNet.Testes.TipoDeCampos
{
    [TestClass]
    public class TipoDeCamposTeste
    {
        [TestMethod]
        public void DeveraRetornarUmElementoHTML_doTipoSelect()
        {
            string[] options = new string[3] {"Option1", "Option2", "Option3"};            
            ITipoDeCampo campo = new SelectOptionCampo(options);

            string actual = "<select><option value=''>Option1</option><option value=''>Option2</option><option value=''>Option3</option></select>";
            string expected = campo.Renderizar();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeveraRetornarUmElementoHtml_doTipoCheckBox()
        {
            ITipoDeCampo campo = new CheckBoxCampo("Option1");
            string actual = "<input type='checkbox' name='' value=''> Option1";
            string expected = campo.Renderizar();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeveraRetornarUmElementoHtml_doTipoText()
        {
            ITipoDeCampo campo = new TextCampo();
            string actual = "<input type='text' name='' value=''>";
            string expected = campo.Renderizar();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeveraRetornarUmElementoHtml_doTipoTextArea_SemInformarNumeroDeRows()
        {
            ITipoDeCampo campo = new TextAreaCampo();
            string actual = "<textarea rows='5' cols=''></textarea>";
            string expected = campo.Renderizar();

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void DeveraRetornarUmElementoHtml_doTipoTextArea_Com_10rows()
        {
            ITipoDeCampo campo = new TextAreaCampo(10);
            string actual = "<textarea rows='10' cols=''></textarea>";
            string expected = campo.Renderizar();

            Assert.AreEqual(actual, expected);
        }
    }

}
