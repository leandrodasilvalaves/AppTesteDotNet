(function (app) {

    'use strict';
    function subCategoriaController($scope, subCategoriaServices, categoriaServices) {

        //variaveis
        var _location = "/Admin/SubCategorias";
        var vm = this;
        vm.listaSubCategorias = [];
        vm.listaCategorias = [];

        vm.listarTodos = function () {
            var response = subCategoriaServices.listarTodos();
            response.then(function (resp) {
                vm.listaSubCategorias = resp.data;                
            }, function (err) {
                console.log(err);
            });
        }

        vm.listarCategorias = function () {
            var response = categoriaServices.listarTodos();
            response.then(function (resp) {
                vm.listaCategorias = resp.data;
            }, function (err) {
                console.log(err);
            });
        }       

        vm.pesquisarPorId = function () {
            var response = subCategoriaServices.pesquisarPorId(getIdFromUrl());
            response.then(function (resp) {
                vm.subCategoria = resp.data;
            }, function (err) {
                console.log(err);
            });
        }

        vm.incluir = function (subcategoria) {
            var response = subCategoriaServices.incluir(subcategoria);
            executarResponseNonQuery(response, _location);
        }

        vm.editar = function (subcategoria) {
            var response = subCategoriaServices.editar(subcategoria);
            executarResponseNonQuery(response, _location);
        }

        vm.confirmarExclusao = function (id) {

            swal({
                title: "Deseja realmente excluir esta subcategoria ?",
                text: "ATENÇÃO! Esta operação é irreversível!",
                icon: "error",
                buttons: {
                    cancel: "Cancelar",
                    confirm: "Excluir"
                },
                dangerMode: true,
            })
                .then(function (willDelete) {
                    if (willDelete) {
                        _excluirSubCategoria(id);
                    }
                });

        };       

        vm.IniciarFormularioEdicao = function () {            
            vm.pesquisarPorId();
            vm.listarCategorias();
        }


        //Metodos Privados

        var _excluirSubCategoria = function (id) {
            var response = subCategoriaServices.excluir(id);
            executarResponseNonQuery(response, _location);
        };
        
               
    }

    app.controller('subCategoriaController',
        ['$scope', 'subCategoriaServices', 'categoriaServices', subCategoriaController]);

})(angular.module('appAdmin'));