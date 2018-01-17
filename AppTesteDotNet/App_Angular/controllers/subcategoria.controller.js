(function (app) {

    'use strict';
    function subCategoriaController($scope, subCategoriaServices, categoriaServices, tipoDeCampoServices) {

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

        vm.listarTiposDeCampos = function () {
            var response = tipoDeCampoServices.listarTodos();
            response.then(function (resp) {
                vm.listaTipoDeCampos = resp.data;
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
            _executarResponseNonQuery(response);
        }

        vm.editar = function (subcategoria) {
            var response = subCategoriaServices.editar(subcategoria);
            _executarResponseNonQuery(response);
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

        vm.IniciarFormularioInclusao = function () {
            vm.listarCategorias();
            vm.listarTiposDeCampos();
        }

        vm.IniciarFormularioEdicao = function () {            
            vm.pesquisarPorId();
            vm.listarCategorias();
            vm.listarTiposDeCampos();
        }

        //Metodos Privados

        var _excluirSubCategoria = function (id) {
            var response = subCategoriaServices.excluir(id);
            _executarResponseNonQuery(response);
        };

        var _executarResponseNonQuery = function (response) {
            response.then(function (resp) {
                location = "/Admin/SubCategorias";
            }, function (err) {
                console.log(err);
            });
        };
    }

    app.controller('subCategoriaController',
        ['$scope', 'subCategoriaServices', 'categoriaServices', 'tipoDeCampoServices', subCategoriaController]);

})(angular.module('appAdmin'));