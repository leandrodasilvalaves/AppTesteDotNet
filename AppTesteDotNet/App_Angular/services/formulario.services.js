(function (app) {

    'use strict';
    function formularioSerivces($http) {
        var serviceLocal = SERVICEBASE + 'formularios';

        var vm = this;

        vm.listarTodos = function () {

            return $http.get(serviceLocal);
        };

        vm.getFormulario = function (id) {
            return $http({
                method: 'GET',
                url: serviceLocal + '?id=' + id
            });
        };

        vm.getSubCategoriasPorCategoria = function (idCategoria) {
            return $http({
                method: 'GET',
                url: serviceLocal + '?idCategoria=' + idCategoria
            });
        };

        vm.getCamposPorSubCategoria = function (idSubCategoria) {
            return $http({
                method: 'GET',
                url: serviceLocal + '?idSubCategoria=' + idSubCategoria
            });
        };

        vm.getListaOpcoesPorCampo = function (idCampo) {
            return $http({
                method: 'GET',
                url: serviceLocal + '?idCampo=' + idCampo
            });
        };

    }

    app.service('formularioServices', ['$http', formularioSerivces]);

})(angular.module('appAdmin'));