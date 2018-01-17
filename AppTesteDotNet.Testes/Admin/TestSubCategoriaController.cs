using AppTesteDotNet.Areas.Admin.Controllers.Api;
using AppTesteDotNet.Models.Entities;
using AppTesteDotNet.Models.Intefaces;
using AppTesteDotNet.Testes.Mock;
using AppTesteDotNet.Testes.Models.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;

namespace AppTesteDotNet.Testes.Admin
{
    [TestClass]
    public class TestSubCategoriaController
    {
        private IAppContext contextTest;
        private SubCategoriasController controller;

        [TestInitialize]
        public void IniciarlizarTeste()
        {
            contextTest = new AppContextTest();
            controller = new SubCategoriasController(contextTest);
            SubCategoriaMock.InserirSubCategoriasNoContextoSeVazio(contextTest);
        }

        [TestMethod]
        public void GetSubCategoria_DeveraRetornar_UmaSubCategoriaPorId()
        {
            var result = controller.GetSubCategoria(2) as OkNegotiatedContentResult<SubCategoria>;
            Assert.AreEqual(result.Content.Descricao, "SubCategoria Teste2");
        }

        [TestMethod]
        public void GetSubCategorias_DeveraRetornar_TodasAsSubCategorias()
        {
            var result = controller.GetSubCategorias() as TesteSubCategoriaDbSet;

            Assert.AreEqual(true, result.Local.Count == 4);
        }

        [TestMethod]
        public void PostSubCategoria_DeveraRetornar_A_MesmaSubCategoria_SePostar()
        {
            var item = SubCategoriaMock.SubCategoriaDemo();
            var result = controller.PostSubCategoria(item) as CreatedAtRouteNegotiatedContentResult<SubCategoria>;

            Assert.AreEqual(result.Content.Descricao, item.Descricao);
        }

        [TestMethod]
        public void PutSubCategoria_DeveraFalhar_SeIdNaoEncontrado()
        {
            var badResult = controller.PutSubCategoria(8, SubCategoriaMock.SubCategoriaDemo());
            Assert.IsInstanceOfType(badResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void DeleteSubCategoria_DeveraRetornarOk_AposExcluir()
        {
            var result = controller.DeleteSubCategoria(2) as OkNegotiatedContentResult<SubCategoria>;

            Assert.AreEqual(2, result.Content.Id);
        }
    }
}
