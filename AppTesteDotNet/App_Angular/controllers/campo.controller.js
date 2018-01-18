(function (app) {

    'use strict';
    function campoController($scope, campoServices, tipoDeCampoServices, listaServices) {
        var _location = "/Admin/Campos?idSubCategoria=" + getIdFromUrl();
        var vm = this;
        vm.listaCampos = [];
        vm.listaTipoDeCampos = [];
        vm.idSubCategoria = "";
        vm.ordem = 0;

        vm.listarTodosPorSubCategoria = function () {
            vm.idSubCategoria = getIdFromUrl();
            var response = campoServices.listarTodos(vm.idSubCategoria);
            response.then(function (resp) {
                vm.listaCampos = _configurarListaDeCampos(resp.data);
                _getNomeSubCategoria();
            }, function (err) {
                console.log(err);
            });
        };

        vm.listarTiposDeCampos = function () {
            var response = tipoDeCampoServices.listarTodos();
            response.then(function (resp) {
                vm.listaTipoDeCampos = resp.data;
            }, function (err) {
                console.log(err);
            });
        };
                
        vm.inicializarLista = function () {
            vm.listarTiposDeCampos();
            vm.listarTodosPorSubCategoria();
        }

        //Metodos herdados de Lista services
        vm.listaOpcoes = listaServices.listaOpcoes;
        vm.incluirOpcao = listaServices.incluirOpcao;
        vm.removerOpcao = listaServices.removerOpcao;

        vm.incluir = function (campo) {
            
            _obterOrdemParaNovoCampo();

            setTimeout(function () {
                campo.Lista = vm.listaOpcoes;
                campo.SubCategoriaId = getIdFromUrl();
                campo.ordem = vm.ordem;
                var response = campoServices.incluir(campo);
                executarResponseNonQuery(response, _location);

            }, 2000);
        };

        //metodos privados
        var _getNomeTipoDeCampo = function (campo) {
            var _tipoNome = vm.listaTipoDeCampos.find(function (tp) {
                return tp.Num == campo.Tipo;
            });
            return _tipoNome.Display;
        };

        var _configurarListaDeCampos = function (listaCampo) {
            var novaLisa = [];
            listaCampo.forEach(function (campo) {
                campo.Tipo = _getNomeTipoDeCampo(campo);
                novaLisa.push(campo);
            });
            return novaLisa;
        };

        var _getNomeSubCategoria = function () {
            if (vm.listaCampos.length > 0) {
                vm.nomeSubCategoria = vm.listaCampos[0].SubCategoria.Descricao               
            }
        }

        var _obterOrdemParaNovoCampo = function () {
            var response = campoServices.getOrdemParaNovoCampo(getIdFromUrl());
            response.then(function (resp) {
                vm.ordem = resp.data;
            }, function (err) {
                console.log(err);
            });
        }

       
    }

    app.controller('campoController',
        ['$scope', 'campoServices', 'tipoDeCampoServices', 'listaServices', campoController]);

})(angular.module("appAdmin"));