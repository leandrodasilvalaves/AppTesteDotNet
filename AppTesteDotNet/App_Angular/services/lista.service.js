(function (app) {

    'use strict';
    function listaServices() {

        var vm = this;
        vm.listaOpcoes = [];
        var Opcao = function (descricao) {
            this.Descricao = descricao;
        }
       
        vm.opcao = new Opcao("");
        
        //Metodos Privados 
        var _seExistiNaLista = function (descricao) {
            var existeOpcao = vm.listaOpcoes.find(function (op) {
                return op.Descricao == descricao;
            });
            if (existeOpcao != undefined) {
                alert('essa opção já existe na lista.');
                return true;
            }
            return false;
        }

        var _seForValida = function (descricao) {
            return (descricao != null && !_seExistiNaLista(descricao));
        };


        var _getPosicao = function (descricao) {
            var posicao = vm.listaOpcoes.map(function (e) {
                return e.Descricao;
            }).indexOf(descricao);
            return posicao;
        }

        var _removerOpcaoDaLista = function (opcao) {
            vm.listaOpcoes.splice(_getPosicao(opcao.Descricao), 1);
        }



        //Metodos Publicos
        vm.incluirOpcao = function (descricao) {
            if (_seForValida(descricao)) {
                vm.listaOpcoes.push(new Opcao(descricao));
            }
        }

        vm.removerOpcao = function (opcao) {
            _removerOpcaoDaLista(opcao);
        }

    }

    app.service('listaServices', listaServices)

})(angular.module("appAdmin"));