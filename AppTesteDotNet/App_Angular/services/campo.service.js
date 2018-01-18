(function (app) {

    'use strict';
    function campoServices($http) {
        var serviceLocal = SERVICEBASE + 'campos';

        var vm = this;

        vm.listarTodos = function (subCategoriaId) {

            return $http.get(serviceLocal + '?subCategoriaId=' + subCategoriaId);
        }

        vm.pesquisarPorId = function (id) {
            return $http({
                method: 'GET',
                url: serviceLocal + '?id=' + id
            });
        }

        vm.getOrdemParaNovoCampo = function (_subCategoriaId) {

            return $http.get(serviceLocal + '?_subCategoriaId=' + _subCategoriaId);
        };

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

    app.service('campoServices', ['$http', campoServices]);

})(angular.module('appAdmin'));