(function (app) {

    'use strict';
    function categoriaServices($http) {
        var serviceLocal = SERVICEBASE + 'categorias';

        var vm = this;

        vm.listarTodos = function () {

           return  $http.get(serviceLocal);
        }

        vm.pesquisarPorId = function (id) {
            return $http({
                method: 'GET',
                url: serviceLocal + '?id=' + id
            });
        }

        vm.incluir = function (categoria) {
            return $http({
                method: 'POST',
                url: serviceLocal,
                data: categoria
            });
        };

        vm.editar = function (categoria) {
            return $http({
                method: 'PUT',
                url: serviceLocal + '?id=' + categoria.Id,
                data: categoria
            });
        }

        vm.excluir = function (id) {
            return $http({
                method: 'DELETE',
                url: serviceLocal + '?id=' + id
            });
        };


    }

    app.service('categoriaServices', ['$http', categoriaServices]);

})(angular.module('appAdmin'));