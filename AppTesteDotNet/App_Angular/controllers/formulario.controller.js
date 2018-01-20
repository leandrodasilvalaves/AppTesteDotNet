(function (app) {

    'use strict';

    function formularioController($scope, formularioServices) {

        var vm = this;

        vm.listarFormularios = function () {
            var response = formularioServices.listarTodos();
            response.then(function (resp) {
                vm.listaCategoriasForms = resp.data;
            }, _error);
        };

        vm.pesquisarFormularioPorId = function (idCategoria) {
            idCategoria = idCategoria || getIdFromUrl();
            var response = formularioServices.getFormulario(idCategoria);
            response.then(function (resp) {
                vm.categoriaFormulario = resp.data;
            }, _error);
        };

        vm.listarSubCategoriasPorCategoria = function (idCategoria) {
            idCategoria = idCategoria || getIdFromUrl();
            var response = formularioServices.getSubCategoriasPorCategoria(idCategoria);
            response.then(function (resp) {
                vm.listaSubCategorias = resp.data;
            }, _error);
        };

        vm.listarCamposPorSubCategoria = function (idSubCategoria) {
            idSubCategoria = idSubCategoria || getIdFromUrl();
            var response = formularioServices.getCamposPorSubCategoria(idSubCategoria);
            response.then(function (resp) {
                vm.listaCamposSubcategoria = resp.data;
                criarFormNaDom(vm.listaCamposSubcategoria);
                _pegarDadosSubCategoria(resp.data);
            }, _error);
        };

        vm.inicializarSubCategoriasForms = function () {
            vm.pesquisarFormularioPorId();
            vm.listarSubCategoriasPorCategoria();
        }

        vm.iniciaizarTelaDeForms = function () {
            vm.listarCamposPorSubCategoria();
        }

        vm.criarFormulario = function () {
            criarFormNaDom(vm.listaCamposSubcategoria);
        }

        //Metodos Privados

        var _error = function (err) {
            console.log(err);
        };

        var _pegarDadosSubCategoria = function (data) {
            if (data == undefined || data == null)
                return;
            vm.subCategoria = data[0].SubCategoria;
            vm.pesquisarFormularioPorId(vm.subCategoria.CategoriaId);
        };
    }

    app.controller('formularioController', ['$scope', 'formularioServices', formularioController]);

})(angular.module('appAdmin'));