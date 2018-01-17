﻿(function (app) {

    'use strict';
    function categoriaController($scope, categoriaServices) {
        
        var vm = this;
        vm.listaCategorias = [];

        vm.listarTodos = function () {
            var response = categoriaServices.listarTodos();
            response.then(function (resp) {
                vm.listaCategorias = resp.data;
            }, function (err) {
                console.log(err);
            });
        }

        vm.pesquisarPorId = function () {
            var response = categoriaServices.pesquisarPorId(getIdFromUrl());
            response.then(function (resp) {
                vm.categoria =resp.data;
            }, function (err) {
                console.log(err);
            });
        }

        vm.incluir = function (categoria) {
            var response = categoriaServices.incluir(categoria);
            _executarResponseNonQuery(response);
        }

        vm.editar = function (categoria) {
            var response = categoriaServices.editar(categoria);
            _executarResponseNonQuery(response);
        }

        vm.confirmarExclusao = function (id) {

            swal({
                title: "Deseja realmente excluir esta categoria ?",
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
                        _excluirCategoria(id);
                    }
                });

        };


        //Metodos Privados

        var _excluirCategoria = function(id){
            var response = categoriaServices.excluir(id);
            _executarResponseNonQuery(response);
        };

        var _executarResponseNonQuery = function (response) {
            response.then(function (resp) {
                location = "/Admin/Categorias";
            }, function (err) {
                console.log(err);
            });
        };

    }

    app.controller('categoriaController', ['$scope', 'categoriaServices', categoriaController]);

})(angular.module('appAdmin'));