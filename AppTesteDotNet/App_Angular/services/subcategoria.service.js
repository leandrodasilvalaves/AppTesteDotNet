(function (app) {

    'use strict';
    function subCategoriaServices($http) {
        var serviceLocal = SERVICEBASE + 'subcategorias';

        var vm = this;

        vm.listarTodos = function () {
            return $http.get(serviceLocal);
        }

        vm.pesquisarPorId = function (id) {
            return $http({
                method: 'GET',
                url: serviceLocal + '?id=' + id
            });
        };

        vm.incluir = function (subCategoria) {
            return $http({
                method: 'POST',
                url: serviceLocal,
                data: subCategoria
            });
        };

        vm.editar = function (subCategoria) {
            return $http({
                method: 'PUT',
                url: serviceLocal + '?id=' + subCategoria.Id,
                data: subCategoria
            });
        }

        vm.excluir = function (id) {
            return $http({
                method: 'DELETE',
                url: serviceLocal + '?id=' + id
            });
        };

    }

    app.service('subCategoriaServices', ['$http', subCategoriaServices]);

})(angular.module("appAdmin"));