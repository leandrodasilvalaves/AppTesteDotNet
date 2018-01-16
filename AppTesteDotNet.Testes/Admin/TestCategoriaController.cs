using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppTesteDotNet.Models.Intefaces;
using AppTesteDotNet.Testes.Models.Context;
using AppTesteDotNet.Areas.Admin.Controllers;
using System.Web.Http.Results;
using AppTesteDotNet.Models.Entities;
using AppTesteDotNet.Testes.Mock;
using System.Linq;
using System.Net;

namespace AppTesteDotNet.Testes.Admin
{
    [TestClass]
    public class TestCategoriaController
    {
        private IAppContext contextTest;
        private CategoriasController controller;

        [TestInitialize]
        public void IniciarlizarTeste()
        {
            contextTest = new AppContextTest();
            controller = new CategoriasController(contextTest);
            CategoriaMock.InserirCategoriasNoContextoSeVazio(contextTest);
        }
        

        [TestMethod]
        public void GetCategoria_DeveraRetornar_UmaCategoriaPorId()
        {
            var result = controller.GetCategoria(4) as OkNegotiatedContentResult<Categoria>;
            Assert.AreEqual(result.Content.Descricao, "Categoria Teste4");
        }

        [TestMethod]
        public void GetCategorias_DeveraRetornar_TodasAsCategorias()
        {
            var result = controller.GetCategorias() as TesteCategoriaDbSet;

            Assert.AreEqual(true, result.Local.Count == 4);
        }

        [TestMethod]
        public void PostCategoria_DeveraRetornar_A_MesmaCategoria_SePostar()
        {
            var item = CategoriaMock.CategoriaDemo();
            var result = controller.PostCategoria(item) as CreatedAtRouteNegotiatedContentResult<Categoria>;

            Assert.AreEqual(result.Content.Descricao, item.Descricao);
        }

        [TestMethod]
        public void PutCategoria_DeveraFalhar_SeIdNaoEncontrado()
        {
            var badResult = controller.PutCategoria(8, CategoriaMock.CategoriaDemo());
            Assert.IsInstanceOfType(badResult, typeof(BadRequestResult));
        } 
        

        [TestMethod]
        public void DeleteCategoria_DeveraRetornarOk_AposExcluir()
        {
            var result = controller.DeleteCategoria(2) as OkNegotiatedContentResult<Categoria>;

            Assert.AreEqual(2, result.Content.Id);
        }
    }
}
