(function (app) {

    'use strict';
    function tipoDeCampoServices($http) {
        var serviceLocal = SERVICEBASE + 'tipodecampo';
        var vm = this;

        vm.listarTodos = function () {
            return $http.get(serviceLocal);
        }
    }

    app.service('tipoDeCampoServices', ['$http', tipoDeCampoServices])

})(angular.module("appAdmin"));