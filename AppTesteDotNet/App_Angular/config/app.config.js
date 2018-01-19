angular.module('appAdmin').config(function ($httpProvider) {
    $httpProvider.interceptors.push('loadingInterceptor');
});